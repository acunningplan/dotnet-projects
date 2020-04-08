using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Cancel
    {
        public static async Task CancelMethod(string id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            order.Cancelled = true;

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem cancelling order");
        }
    }
}
