using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Buns
    {
        public static List<Bun> BunsList = new List<Bun>
            {
                new Bun { Name = "White", Calories = 50, Price = 1 },
                new Bun { Name = "Wheat", Calories = 45, Price = 1 }
            };
    }
}
