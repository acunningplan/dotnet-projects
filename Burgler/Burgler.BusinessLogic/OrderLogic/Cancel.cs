using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Cancel
    {
        public static async Task<bool> CancelMethod(Guid id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order == null) return false;

            order.Cancelled = true;

            bool success = await dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
