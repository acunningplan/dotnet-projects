using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : InitializeFoodItem, IFoodItem
    {
        public Guid BurgerItemId { get; set; }
        public string BurgerBun { get; set; }
        public string BurgerPatty { get; set; }
        public PattyDoneness BurgerPattyCooked { get; set; }
        public virtual IEnumerable<BurgerTopping> BurgerToppings { get; set; }
        public virtual OrderNS.Order Order { get; set; }
        public BurgerItem()
        {
            BurgerBun = Ingredients.Buns.SelectDefault().Name;
            BurgerPatty = Ingredients.Patties.SelectDefault().Name;
            BurgerPattyCooked = PattyCooked.SelectDefault();

            string defaultTopping = Ingredients.Toppings.SelectDefault().Name;

            BurgerToppings = new List<BurgerTopping>
            {
                new BurgerTopping { Name = defaultTopping }
            };
        }

        public double CalculatePrice()
        {
            // null checks?
            double basePrice = 1;
            double burgerPrice = basePrice;

            double burgerBunPrice = Ingredients.Buns.SelectByName(BurgerBun).Price;
            double burgerPattyPrice = Ingredients.Patties.SelectByName(BurgerPatty).Price;
            burgerPrice += burgerBunPrice + burgerPattyPrice;

            foreach (BurgerTopping topping in BurgerToppings)
            {
                double toppingPrice = Ingredients.Toppings.SelectByName(topping.Name).Price;
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

            double burgerBunCalories = Ingredients.Buns.SelectByName(BurgerBun).Calories;
            double burgerPattyCalories = Ingredients.Patties.SelectByName(BurgerPatty).Calories;
            burgerCalories += burgerBunCalories + burgerPattyCalories;

            foreach (BurgerTopping topping in BurgerToppings)
            {
                double toppingCalories = Ingredients.Toppings.SelectByName(topping.Name).Calories;
                burgerCalories += toppingCalories;
            }
            burgerCalories *= Quantity;
            return burgerCalories;
        }
    }
}
