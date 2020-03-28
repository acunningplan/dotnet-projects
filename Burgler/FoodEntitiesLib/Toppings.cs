using System;
using System.Collections.Generic;
using System.Text;

namespace FoodEntitiesLib
{
    public class Topping
    {
        public double Calories;
        public double Price;
    }

    public class Toppings
    {
        public Topping Tomato
        {
            get { return new Topping { Calories = 30, Price = 1 }; }
        }
        public Topping Pickle
        {
            get { return new Topping { Calories = 20, Price = 0.8 }; }
        }
    }
}
