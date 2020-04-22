using Burgler.BusinessLogic.MenuLogic;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class CommandValidation
    {
        public static bool Validate(this Menu menu, BurgerItemDto bi)
        {
            if (menu.BunsList.Find(bun => bun.Name == bi.BurgerBun) == null)
                return false;
            if (menu.PattiesList.Find(patty => patty.Name == bi.BurgerPatty & patty.Size == bi.Size) == null)
                return false;
            foreach (BurgerToppingDto bt in bi.BurgerToppings)
                if (menu.ToppingsList.Find(topping => topping.Name == bt.Name) == null)
                    return false;
            return true;
        }
        public static bool Validate(this Menu menu, DrinkItemDto di)
        {
            return (menu.DrinksList.Find(d => d.Name == di.Name) == null) ? false : true;
        }
        public static bool Validate(this Menu menu, SideItemDto si)
        {
            return (menu.SidesList.Find(s => s.Name == si.Name) == null) ? false : true;
        }
    }
}
