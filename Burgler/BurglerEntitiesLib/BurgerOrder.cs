using System;
using System.Collections.Generic;
using System.Text;
using FoodEntitiesLib;

namespace BurglerEntitiesLib
{
    public class BurgerOrder
    {
        public int Quantity { get; set; }
        public string BunType { get; set; }
        public Patty Patty { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }
        public double CalculatePrice()
        {
            double burgerPrice = 0;
            foreach (Topping topping in Toppings)
            {
                burgerPrice += topping.Price;
            }
            return burgerPrice;
        }
    }
}
