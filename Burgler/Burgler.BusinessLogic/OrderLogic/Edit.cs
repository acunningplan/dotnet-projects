using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.Entities.FoodItem;
using BurglerContextLib;
using FluentValidation;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class EditCommand
    {
        public string Id { get; set; }
        public IEnumerable<BurgerItem> BurgerItems { get; set; }
    }
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.BurgerItems).NotEmpty();
        }
    }
    public static class Edit
    {
        public static async Task EditMethod(EditCommand command, BurglerContext dbContext)
        {

            var order = await dbContext.Orders.FindAsync(command.Id) ??
                throw new RestException(HttpStatusCode.NotFound, "No order with given id.");

            order.BurgerItems = command.BurgerItems;

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem cancelling order");
        }
    }
}
