using Burgler.BusinessLogic.MenuLogic;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class OrderExtensions
    {
        public static double CalculateTotalCalories(this Menu menu, Order order)
        {
            double calories = 0;
            foreach (BurgerItem bi in order.BurgerItems) calories += menu.CalculateCalories(bi);
            foreach (SideItem si in order.SideItems) calories += menu.CalculateCalories(si);
            foreach (DrinkItem di in order.DrinkItems) calories += menu.CalculateCalories(di);
            return calories;
        }
        public static double CalculateTotalPrice(this Menu menu, Order order)
        {
            double price = 0;
            foreach (BurgerItem bi in order.BurgerItems) price += menu.CalculatePrice(bi);
            foreach (SideItem si in order.SideItems) price += menu.CalculatePrice(si);
            foreach (DrinkItem di in order.DrinkItems) price += menu.CalculatePrice(di);
            return price;
        }
    }
}
