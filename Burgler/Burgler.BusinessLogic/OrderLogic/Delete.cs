
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public partial class Delete : OrderMethod
    {
        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await DbContext.Orders.FindAsync(id);

            if (order == null) return false;

            DbContext.Remove(order);

            bool success = await DbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
