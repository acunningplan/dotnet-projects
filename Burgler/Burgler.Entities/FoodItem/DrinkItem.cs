using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class DrinkItem : InitializeFoodItem, IFoodItem
    {
        public Guid DrinkItemId { get; set; }
        public double Volume { get; set; }
        public virtual OrderNS.Order Order { get; set; }

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
