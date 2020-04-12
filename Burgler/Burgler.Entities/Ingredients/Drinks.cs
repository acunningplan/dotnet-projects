using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Ingredients
{
    public class Drink : Ingredient
    {
        public Drink()
        {
            Type = "Drink";
        }
        public int Volume { get; set; } = -1;
    }

    public class Drinks
    {
        public static List<Ingredient> DrinksList = new List<Ingredient>
            {
                new Drink { Name = "Coke", Size="Small", Calories = 50, Price = 1, Volume = 200 },
                new Drink { Name = "Coke", Size="Large", Calories = 80, Price = 1.5, Volume = 300 },
                new Drink { Name = "Strawberry Milkshake", Size="Small", Calories = 60, Price = 2, Volume = 200 },
                new Drink { Name = "Strawberry Milkshake", Size="Large", Calories = 100, Price = 3, Volume = 300 },
                new Drink { Name = "Orange Juice", Calories = 30, Price = 1, Volume = 180 },
                new Drink { Name = "Tea", Calories = 10, Price = 1, Volume = 120 }
            };
    }
}
