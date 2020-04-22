using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.MenuLogic
{
    public class BurgerDto
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string BurgerBun { get; set; }
        public string BurgerPatty { get; set; }
        public string BurgerToppings { get; set; }
        public string Description { get; set; }
    }
    public class BunDto : IngredientDto { }
    public class ToppingDto : IngredientDto { }
    public class PattyDto : IngredientDto
    {
        public string Size { get; set; }
    }

    public class SideDto : IngredientDto
    {
        public string Type { get; set; }
        public string Size { get; set; }
    }
    public class DrinkDto : IngredientDto
    {
        public string Type { get; set; }
        public string Size { get; set; }
        public double Volume { get; set; }
    }

    public class IngredientDto
    {
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
