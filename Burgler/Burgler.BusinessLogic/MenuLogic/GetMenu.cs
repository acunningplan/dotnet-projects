using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using BurglerContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.MenuLogic
{
    public class Menu
    {
        public List<BurgerItem> MyProperty { get; set; }
        public List<Side> SidesList { get; set; } = Sides.SidesList.Cast<Side>().ToList();
        public List<Drink> DrinksList { get; set; } = Sides.SidesList.Cast<Drink>().ToList();
    }
    public static class GetMenu
    {
        public static Menu GetMenuMethod(BurglerContext dbContext)
        {
            var menu = new Menu();


            return new Menu();
        }
    }
}
