using Burgler.BusinessLogic.MenuLogic;
using Burgler.Entities.FoodItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class MenuExtensions
    {
        public static double CalculateCalories(this Menu menu, BurgerItem bi) =>
            BurgerItemMethods.CalculateCalories(menu, bi);
        public static double CalculateCalories(this Menu menu, DrinkItem di) =>
            menu.DrinksList.Find(d => d.Name == di.Name & d.Size == di.Size).Calories;
        public static double CalculateCalories(this Menu menu, SideItem si) =>
            menu.SidesList.Find(s => s.Name == si.Name & s.Size == si.Size).Calories;

        public static double CalculatePrice(this Menu menu, BurgerItem bi) =>
            BurgerItemMethods.CalculatePrice(menu, bi);
        public static double CalculatePrice(this Menu menu, DrinkItem di) =>
            menu.DrinksList.Find(d => d.Name == di.Name & d.Size == di.Size).Price;
        public static double CalculatePrice(this Menu menu, SideItem si) =>
            menu.SidesList.Find(s => s.Name == si.Name & s.Size == si.Size).Price;
    }
}
