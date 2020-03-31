
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderServices
{
    public partial class OrderServices : IOrderServices
    {
        public async Task<bool> CancelOrder(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order == null) return false;

            order.Cancelled = true;

            bool success = await _dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
