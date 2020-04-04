using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public interface IFoodItem
    {
        public double Quantity { get; set; }
        public string Name { get; set; }
        public double CalculatePrice();
        public double CalculateCalories();
    }
}
