using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : InitializeFoodItem, IFoodItem
    {
        public BurgerItem()
        {
            string defaultTopping = Toppings.ToppingList.SelectDefault().Name;

            BurgerToppings = new List<BurgerTopping>
            {
                new BurgerTopping { Name = defaultTopping }
            };
        }
        public Guid BurgerItemId { get; set; }
        public string BurgerBun { get; set; } = Buns.BunList.SelectDefault().Name;
        public string BurgerPatty { get; set; } = Patties.PattyList.SelectDefault().Name;
        public PattyDoneness BurgerPattyCooked { get; set; } = PattyCooked.SelectDefault();
        public virtual ICollection<BurgerTopping> BurgerToppings { get; set; }
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }

        public double CalculatePrice()
        {
            // null checks?
            double basePrice = 1;
            double burgerPrice = basePrice;

            double burgerBunPrice = Buns.BunList.SelectByName(BurgerBun).Price;
            double burgerPattyPrice = Patties.PattyList.SelectByName(BurgerPatty).Price;
            burgerPrice += burgerBunPrice + burgerPattyPrice;

            foreach (BurgerTopping topping in BurgerToppings)
            {
                double toppingPrice = Toppings.ToppingList.SelectByName(topping.Name).Price;
                burgerPrice += toppingPrice;
            }
            burgerPrice *= Quantity;
            return burgerPrice;
        }

        public double CalculateCalories()
        {
            // null checks?
            double baseCalories = 1;
            double burgerCalories = baseCalories;

            double burgerBunCalories = Buns.BunList.SelectByName(BurgerBun).Calories;
            double burgerPattyCalories = Patties.PattyList.SelectByName(BurgerPatty).Calories;
            burgerCalories += burgerBunCalories + burgerPattyCalories;

            foreach (BurgerTopping topping in BurgerToppings)
            {
                double toppingCalories = Toppings.ToppingList.SelectByName(topping.Name).Calories;
                burgerCalories += toppingCalories;
            }
            burgerCalories *= Quantity;
            return burgerCalories;
        }
    }
}
