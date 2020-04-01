using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class Cancel : OrderMethod
    {
        public async Task<bool> CancelOrder(Guid id)
        {
            var order = await DbContext.Orders.FindAsync(id);

            if (order == null) return false;

            order.Cancelled = true;

            bool success = await DbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
