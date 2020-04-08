
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using BurglerContextLib;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class CreateCommand
    {
        public IEnumerable<BurgerItem> BurgerItems { get; set; }
    }
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.BurgerItems).NotEmpty();
        }
    }
    public static class Create
    {
        public static async Task CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices)
        {
            string username = userServices.GetCurrentUsername();

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

            // Create order (will be changed soon)
            var order = new Order
            {
                OrderedAt = DateTime.Now,
                BurgerItems = command.BurgerItems,
                User = user
            };

            dbContext.Orders.Add(order);

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order.");
        }
    }
}
