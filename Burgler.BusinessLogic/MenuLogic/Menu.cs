using AutoMapper;
using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
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
        public List<BurgerDto> BurgersList { get; set; }
        public List<BunDto> BunsList { get; set; }
        public List<ToppingDto> ToppingsList { get; set; }
        public List<PattyDto> PattiesList { get; set; }
        public List<SideDto> SidesList { get; set; }
        public List<DrinkDto> DrinksList { get; set; }
    }
}
