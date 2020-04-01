using Burgler.Entities.FoodItem;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class EditCommand
    {
        public string Id { get; set; }
        public IEnumerable<IFoodItem> FoodItems { get; set; }
    }
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FoodItems).NotEmpty();
        }
    }
    public partial class Edit : OrderMethod
    {
        public async Task<bool> EditOrder(EditCommand command)
        {

            var order = await DbContext.Orders.FindAsync(command.Id);

            if (order == null) return false;

            order.FoodItems = command.FoodItems;

            bool success = await DbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
