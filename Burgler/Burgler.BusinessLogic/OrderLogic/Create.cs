
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.IngredientsNS;
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
    public class BurgerItemJson
    {
        public string BurgerBun { get; set; } = Ingredients.Buns.SelectDefault().Name;
        public string BurgerPatty { get; set; } = Ingredients.Patties.SelectDefault().Name;
        public int BurgerPattyCooked { get; set; } = (int)PattyCooked.SelectDefault();
        public List<string> BurgerToppings { get; set; } = new List<string>();
    }
    public class CreateCommand
    {
        public List<string> SideItems { get; set; } = new List<string>();
        public List<string> DrinkItems { get; set; } = new List<string>();
        public List<BurgerItemJson> BurgerItems { get; set; } = new List<BurgerItemJson>();
    }
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            //RuleFor(x => x.BurgerItems).NotEmpty();
        }
    }
    public static class Create
    {
        public static async Task CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices)
        {
            string username = userServices.GetCurrentUsername();

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

            // Create order
            var order = new Order
            {
                OrderedAt = DateTime.Now,
                User = user
            };

            //foreach (var di in command.DrinkItems)
            //{
            //    var drinkItem = new DrinkItem();
            //}

            foreach (var bi in command.BurgerItems)
            {
                var burgerItem = new BurgerItem();
                burgerItem.BurgerBun = Ingredients.Buns.SelectByName(bi.BurgerBun).Name;
                burgerItem.BurgerPatty = Ingredients.Patties.SelectByName(bi.BurgerPatty).Name;
                burgerItem.BurgerPattyCooked = (PattyDoneness)bi.BurgerPattyCooked;
                foreach (string bt in bi.BurgerToppings)
                {
                    string toppingName = Ingredients.Toppings.SelectByName(bt).Name;
                    burgerItem.BurgerToppings.Add(new BurgerTopping { Name = toppingName });
                }
                order.BurgerItems.Add(burgerItem);
            }
            dbContext.Orders.Add(order);

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order.");
        }
    }
}
