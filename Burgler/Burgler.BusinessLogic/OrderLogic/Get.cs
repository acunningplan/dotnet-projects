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
    public static class Get
    {
        public static async Task<Order> GetMethod(string id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            return order;
        }
        public static async Task<List<Order>> GetManyMethod(BurglerContext dbContext, IUserServices userServices)
        {
            string username = userServices.GetCurrentUsername();

            var orders = await dbContext.Orders.Where(order => order.User.UserName == username).ToListAsync();

            return orders;
        }
    }
}
