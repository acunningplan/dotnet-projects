using Burgler.Entities.FoodItem;
using BurglerContextLib;
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
    public static class Edit
    {
        public static async Task<bool> EditMethod(EditCommand command, BurglerContext dbContext)
        {

            var order = await dbContext.Orders.FindAsync(command.Id);

            if (order == null) return false;

            order.FoodItems = command.FoodItems;

            bool success = await dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
