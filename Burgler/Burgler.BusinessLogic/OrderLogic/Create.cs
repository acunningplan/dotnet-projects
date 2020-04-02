
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using BurglerContextLib;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class CreateCommand
    {
        public string UserId { get; set; }
        public IEnumerable<IFoodItem> FoodItems { get; set; }
    }
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
    public static class Create
    {
        public static async Task<bool> CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices)
        {
            var order = new Order
            {
                UserId = "1"
            };

            dbContext.Orders.Add(order);

            string username = userServices.GetCurrentUsername();

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username);

            var userOrder = new UserOrder
            {
                AppUser = user,
                DateOrdered = DateTime.Now
            };

            dbContext.UserOrders.Add(userOrder);

            bool success = await dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
