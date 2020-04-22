using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Toppings
    {
        public static List<Topping> ToppingList = new List<Topping>
            {
                new Topping { Name = "Tomato", Calories = 50, Price = 1 },
                new Topping { Name = "Gherkin", Calories = 25, Price = 1 },
                new Topping { Name = "Lettuce", Calories = 20, Price = 1 },
                new Topping { Name = "Mayonnaise", Calories = 65, Price = 1 },
                new Topping { Name = "Bacon", Calories = 80, Price = 2.0 },
                new Topping { Name = "Egg", Calories = 50, Price = 1.5 },
            };
    }
}
