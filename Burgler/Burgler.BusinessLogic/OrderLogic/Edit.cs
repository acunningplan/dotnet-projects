using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using FluentValidation;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class EditCommand : OrderDto { }
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator()
        {
            RuleForEach(o => o.BurgerItems).Must(bi => bi.Validate());
            RuleForEach(o => o.SideItems).Must(si => si.Validate());
            RuleForEach(o => o.DrinkItems).Must(bi => bi.Validate());
        }
    }
    public static class Edit
    {
        public static async Task EditMethod(EditCommand command, BurglerContext dbContext, IMapper mapper)
        {
            var newOrder = mapper.Map<OrderDto, Order>(command);

            var order = await dbContext.Orders.FindAsync(newOrder.OrderId) ??
                throw new RestException(HttpStatusCode.NotFound, "No order with given id.");

            order.BurgerItems = newOrder.BurgerItems;
            order.SideItems = newOrder.SideItems;
            order.DrinkItems = newOrder.DrinkItems;

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem cancelling order");
        }
    }
}
