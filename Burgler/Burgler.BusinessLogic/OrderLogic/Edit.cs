using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Burgler.BusinessLogic.MenuLogic;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class EditCommand : OrderDto { }
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator(IMenuServices menuServices)
        {
            RuleForEach(o => o.BurgerItems).MustAsync(async (bi, cancellation) =>
                (await menuServices.GetMenu()).Validate(bi));
            RuleForEach(o => o.SideItems).MustAsync(async (si, cancellation) =>
                (await menuServices.GetMenu()).Validate(si));
            RuleForEach(o => o.DrinkItems).MustAsync(async (di, cancellation) =>
                (await menuServices.GetMenu()).Validate(di));
        }
    }
    public static class Edit
    {
        public static async Task EditMethod(EditCommand command, BurglerContext dbContext, IMapper mapper)
        {
            var newOrder = mapper.Map<OrderDto, Order>(command);

            // Even with lazy loading, we need to include all relevant tables to keep track of changes
            var order = await dbContext.Orders
                .Include(o => o.BurgerItems)
                .ThenInclude(bi => bi.BurgerToppings)
                .Include(o => o.SideItems)
                .Include(o => o.DrinkItems)
                .SingleOrDefaultAsync(o => o.OrderId == command.OrderId) ??
                    throw new RestException(HttpStatusCode.NotFound, "No order with given id.");

            order.BurgerItems = newOrder.BurgerItems;
            order.SideItems = newOrder.SideItems;
            order.DrinkItems = newOrder.DrinkItems;

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem editing order");
        }
    }
}
