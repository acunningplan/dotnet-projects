using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class CommandValidation
    {
        public static bool Validate(this BurgerItemDto bi)
        {
            if (Buns.BunList.SelectByName(bi.BurgerBun) == null) return false;
            if (Patties.PattyList.SelectByNameAndSize(bi.BurgerPatty, bi.Size) == null) return false;
            foreach (BurgerToppingDto topping in bi.BurgerToppings)
                if (Toppings.ToppingList.SelectByName(topping.Name) == null) return false;
            return true;
        }
        public static bool Validate(this DrinkItemDto di)
        {
            return (Drinks.DrinksList.SelectByName(di.Name) == null) ? false : true;
        }
        public static bool Validate(this SideItemDto si)
        {
            return (Sides.SidesList.SelectByName(si.Name) == null) ? false : true;
        }
    }
}
