
using BurglerContextLib;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Delete
    {
        public static async Task<bool> DeleteMethod(Guid id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order == null) return false;

            dbContext.Remove(order);

            bool success = await dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
