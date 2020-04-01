using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Bun : Ingredient
    {
        public Bun()
        {
            Type = "Bun";
        }
    }

    public class Buns : SelectableIngredientList
    {
        public Buns()
        {
            IngredientList = new List<Ingredient>
            {
                new Bun { Name = "White", Calories = 50, Price = 1 },
                new Bun { Name = "Wheat", Calories = 45, Price = 1 }
            };
        }
    }
}
