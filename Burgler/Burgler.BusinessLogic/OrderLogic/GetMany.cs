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

            var orders = new List<Order>();

            if (orderType == OrderType.PendingOrders)
            {
                orders = await dbContext.Orders.Where(
                   order => order.User.UserName == username
                   & DateTime.MinValue == order.CancelledAt
                       & DateTime.MinValue == order.OrderedAt
               ).ToListAsync();
            }
            else if (orderType == OrderType.PlacedOrders)
            {
                orders = await dbContext.Orders.Where(
                      order => order.User.UserName == username
                & DateTime.MinValue != order.OrderedAt
                & DateTime.MinValue == order.FoodTakenAt
                  ).ToListAsync();
            }
            var ordersToReturn = _mapper.Map<List<Order>, List<OrderDto>>(orders);
            return ordersToReturn;
        }
    }
}
