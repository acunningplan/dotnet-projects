using Burgler.Entities.Ingredients;
using System.Collections.Generic;

namespace Burgler.Entities.IngredientsNS
{
    public class Bun : Ingredient
    {
        public Bun()
        {
            Type = "Bun";
        }
    }
    public static class Buns
    {
        public static List<Ingredient> BunList = new List<Ingredient>
            {
                new Bun { Name = "White", Calories = 50, Price = 1 },
                new Bun { Name = "Wheat", Calories = 45, Price = 1 }
            };
    }
}
