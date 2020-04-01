using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class SideItem : InitializeFoodItem, IFoodItem
    {
        public string Size { get; set; }

        public double CalculateCalories()
        {
            throw new NotImplementedException();
        }

        public double CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
