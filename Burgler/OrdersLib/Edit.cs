using FluentValidation;
using OrderEntitiesLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderServicesLib
{
    public class EditCommand
    {
        public string Id { get; set; }
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
    }
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FoodOrders).NotEmpty();
        }
    }
    public partial class OrderServices : IOrderServices
    {
        public async Task<bool> EditOrder(EditCommand command)
        {

            var order = await _dbContext.Orders.FindAsync(command.Id);

            if (order == null) return false;

            order.FoodOrders = command.FoodOrders;

            bool success = await _dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
