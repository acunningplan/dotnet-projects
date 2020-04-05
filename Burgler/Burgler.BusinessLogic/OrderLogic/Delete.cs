
using Burgler.BusinessLogic.ErrorHandlingLogic;
using BurglerContextLib;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Delete
    {
        public static async Task DeleteMethod(Guid id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            dbContext.Remove(order);

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem deleting order");
        }
    }
}
