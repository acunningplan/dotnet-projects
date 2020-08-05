using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        // Find pending order; make a new one if none is found
        public static async Task<List<OrderDto>> GetManyMethod(OrderType orderType, BurglerContext dbContext, IUserServices userServices, IMapper _mapper)
        {
            string username = userServices.GetCurrentUsername();

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

            var orders = new List<Order>();

            if (orderType == OrderType.PendingOrders)
            {
                orders = await dbContext.Orders.Where(
                   order => order.User.UserName == username
                   & DateTime.MinValue == order.CancelledAt
                       & DateTime.MinValue == order.OrderedAt
               ).ToListAsync();

                if (orders.Count == 0)
                {
                    var order = new Order();
                    order.User = user;
                    dbContext.Orders.Add(order);
                    orders.Add(order);
                    _ = await dbContext.SaveChangesAsync() > 0 ? true :
                        throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order");
                }
            }
            else if (orderType == OrderType.PlacedOrders)
            {
                orders = await dbContext.Orders.Where(
                      order => order.User.UserName == username
                    & DateTime.MinValue != order.OrderedAt
                    & DateTime.MinValue == order.FoodTakenAt
                  ).ToListAsync();
            }
            var maxLength = 20;
            orders.Sort((x, y) => y.OrderedAt.CompareTo(x.OrderedAt));
            orders = orders.Count < maxLength ? orders : orders.GetRange(0, maxLength);
            var ordersToReturn = _mapper.Map<List<Order>, List<OrderDto>>(orders);
            return ordersToReturn;
        }
    }
}
