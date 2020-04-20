using AutoMapper;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public enum OrderType
    {
        PendingOrders,
        PlacedOrders,
        ReadyOrders,
        FoodTakenOrders
    }
    public static class GetMany
    {
        public static async Task<List<OrderDto>> GetManyMethod(OrderType orderType, BurglerContext dbContext, IUserServices userServices, IMapper _mapper)
        {
            string username = userServices.GetCurrentUsername();

            var orders = await dbContext.Orders.Where(
                order => order.User.UserName == username & OrderCondition(order, orderType)
            ).ToListAsync();

            var ordersToReturn = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return ordersToReturn;
        }

        public static bool OrderCondition(Order order, OrderType orderType)
        {
            return orderType switch
            {
                OrderType.PendingOrders =>
                    DateTime.MinValue == order.CancelledAt
                        & DateTime.MinValue == order.OrderedAt,
                OrderType.PlacedOrders =>
                    DateTime.MinValue != order.OrderedAt
                        & DateTime.MinValue == order.FoodTakenAt,
                _ => false
            };
        }
    }
}
