using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class DrinkItem : InitializeFoodItem, IFoodItem
    {
        public double Volume { get; set; }

        public double CalculateCalories()
        {
            return 100;
        }

        public double CalculatePrice()
        {
            return 3;
        }
    }
}
