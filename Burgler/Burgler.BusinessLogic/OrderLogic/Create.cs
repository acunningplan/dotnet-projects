
using Burgler.Entities.FoodItem;
using Burgler.Entities.Order;
using Burgler.Entities.User;
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
    public class Create : OrderMethod
    {
        public async Task<bool> CreateOrder(CreateCommand command)
        {
            var order = new Order
            {
                UserId = "1"
            };

            DbContext.Orders.Add(order);

            string username = UserServices.GetCurrentUsername();

            var user = await DbContext.Users.SingleOrDefaultAsync(x => x.UserName == username);

            var userOrder = new UserOrder
            {
                AppUser = user,
                DateOrdered = DateTime.Now
            };

            DbContext.UserOrders.Add(userOrder);

            bool success = await DbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
