using System;
using System.Collections.Generic;
using System.Text;
using FoodEntitiesLib;

namespace OrderEntitiesLib
{
    public class BurgerOrder : FoodOrder
    {
        public string BurgerBun { get; set; }
        public string BurgerPatty { get; set; }
        public PattyDoneness BurgerPattyCooked { get; set; }
        public IEnumerable<string> BurgerToppings { get; set; }
        public BurgerOrder()
        {
            Quantity = 1;
            BurgerBun = Buns.GetDefaultBun().Name;
            BurgerPatty = Patties.GetDefaultPatty().Name;
            BurgerPattyCooked = PattyCooked.GetDefaultDoneness();
            BurgerToppings = new string[] { Toppings.GetDefaultTopping().Name };
        }


        public double CalculatePrice()
        {
            // null checks?
            double basePrice = 1;
            double burgerPrice = basePrice;
            burgerPrice += Buns.GetBun(BurgerBun).Price;
            burgerPrice += Patties.GetPatty(BurgerPatty).Price;
            foreach (string topping in BurgerToppings)
            {
                burgerPrice += Toppings.GetTopping(topping).Price;
            }
            burgerPrice *= Quantity;
            return burgerPrice;
        }

        public double CalculateCalories()
        {
            double burgerCalories = 0;
            burgerCalories += Buns.GetBun(BurgerBun).Calories;
            burgerCalories += Patties.GetPatty(BurgerPatty).Calories;
            foreach (string topping in BurgerToppings)
            {
                burgerCalories += Toppings.GetTopping(topping).Calories;
            }
            burgerCalories *= Quantity;
            return burgerCalories;
        }
    }
}
