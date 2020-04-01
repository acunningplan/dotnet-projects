using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : InitializeFoodItem, IFoodItem
    {
        public string BurgerBun { get; set; }
        public string BurgerPatty { get; set; }
        public PattyDoneness BurgerPattyCooked { get; set; }
        public IEnumerable<string> BurgerToppings { get; set; }
        public BurgerItem()
        {
            BurgerBun = Ingredients.Buns.SelectDefault().Name;
            BurgerPatty = Ingredients.Patties.SelectDefault().Name;
            BurgerPattyCooked = PattyCooked.SelectDefault();
            BurgerToppings = new string[] { Ingredients.Toppings.SelectDefault().Name };
        }

        public double CalculatePrice()
        {
            // null checks?
            double basePrice = 1;
            double burgerPrice = basePrice;

            double burgerBunPrice = Ingredients.Buns.SelectByName(BurgerBun).Price;
            double burgerPattyPrice = Ingredients.Patties.SelectByName(BurgerPatty).Price;
            burgerPrice += burgerBunPrice + burgerPattyPrice;

            foreach (string toppingName in BurgerToppings)
            {
                double toppingPrice = Ingredients.Toppings.SelectByName(toppingName).Price;
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

            foreach (string toppingName in BurgerToppings)
            {
                double toppingCalories = Ingredients.Toppings.SelectByName(toppingName).Calories;
                burgerCalories += toppingCalories;
            }
            burgerCalories *= Quantity;
            return burgerCalories;
        }
    }
}
