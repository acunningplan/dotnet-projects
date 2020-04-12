using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class SideItemExtensions
    {
        public static Side FindSide(SideItem si) => (Side)Sides.SidesList.SelectByNameAndSize(si.Name, si.Size);
        public static double CalculateCalories(this SideItem si) => FindSide(si).Calories;
        public static double CalculatePrice(this SideItem si) => FindSide(si).Price;
    }
}
