using Burgler.BusinessLogic.ErrorHandlingLogic;
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
        public static async Task<Order> GetMethod(Guid id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            return order;
        }
        public static async Task<List<Order>> GetManyMethod(string username, BurglerContext dbContext)
        {
            var orders = await dbContext.Orders.Where(order => order.User.UserName == username).ToListAsync();

            return orders;
        }
    }
}
