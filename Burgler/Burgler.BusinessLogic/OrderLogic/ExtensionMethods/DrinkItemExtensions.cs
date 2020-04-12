using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class DrinkItemExtensions
    {
        public static Drink FindDrink(DrinkItem di) => (Drink)Drinks.DrinksList.SelectByNameAndSize(di.Name, di.Size);
        public static double CalculateCalories(this DrinkItem di) => FindDrink(di).Calories;
        public static double CalculatePrice(this DrinkItem di) => FindDrink(di).Price;
    }
}
