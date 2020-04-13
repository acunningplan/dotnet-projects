using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class OrderExtensions
    {
        public static double CalculateCalories(this Order order)
        {
            double calories = 0;
            foreach (BurgerItem bi in order.BurgerItems) calories += bi.CalculateCalories();
            foreach (SideItem si in order.SideItems) calories += si.CalculateCalories();
            foreach (DrinkItem di in order.DrinkItems) calories += di.CalculateCalories();
            return calories;
        }
        public static double CalculatePrice(this Order order)
        {
            double price = 0;
            foreach (BurgerItem bi in order.BurgerItems) price += bi.CalculatePrice();
            foreach (SideItem si in order.SideItems) price += si.CalculatePrice();
            foreach (DrinkItem di in order.DrinkItems) price += di.CalculatePrice();
            return price;
        }
    }
}
