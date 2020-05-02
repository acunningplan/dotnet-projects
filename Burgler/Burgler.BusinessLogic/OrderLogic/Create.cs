using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.MenuLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class CreateCommand : OrderDto { }
    //public class CreateCommandValidator : AbstractValidator<CreateCommand>
    //{
    //    public CreateCommandValidator(IMenuServices menuServices)
    //    {
    //        RuleForEach(o => o.BurgerItems).MustAsync(async (bi, cancellation) =>
    //            (await menuServices.GetMenu()).Validate(bi));
    //        RuleForEach(o => o.SideItems).MustAsync(async (si, cancellation) =>
    //            (await menuServices.GetMenu()).Validate(si));
    //        RuleForEach(o => o.DrinkItems).MustAsync(async (di, cancellation) =>
    //            (await menuServices.GetMenu()).Validate(di));
    //    }
    //}
    public static class Create
    {
        // Create empty order
        public static async Task CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices, IMapper mapper, IMenuServices menuServices)
        {
            //var order = mapper.Map<OrderDto, Order>(command);
            //var menu = await menuServices.GetMenu();

            //// Make sure client isn't lying about the price
            //order.Price = menu.CalculateTotalPrice(order);
            //order.Calories = menu.CalculateTotalCalories(order);



            string username = userServices.GetCurrentUsername();

            // Check if there's already a pending order. If yes, do not create empty order
            var orders = await dbContext.Orders.Where(
                   order => order.User.UserName == username
                   & DateTime.MinValue == order.CancelledAt
                       & DateTime.MinValue == order.OrderedAt
               ).ToListAsync();

            if (orders.Count > 0) return;

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

            var order = new Order();
            order.User = user;
            dbContext.Orders.Add(order);

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order.");
        }
    }
}
