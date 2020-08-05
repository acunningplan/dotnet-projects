using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Drinks
    {
        public static List<Drink> DrinksList = new List<Drink>
            {
                new Drink { Name = "Coke", Size="Small", Type="Fizzy Drinks", Calories = 50, Price = 1, Volume = 200 },
                new Drink { Name = "Coke", Size="Large", Type="Fizzy Drinks", Calories = 80, Price = 1.5, Volume = 300 },
                new Drink { Name = "Strawberry Milkshake", Size="Small", Type="Other", Calories = 60, Price = 2, Volume = 200 },
                new Drink { Name = "Strawberry Milkshake", Size="Large", Type="Other", Calories = 100, Price = 3, Volume = 300 },
                new Drink { Name = "Orange Juice", Type="Other", Calories = 30, Price = 1, Volume = 180 },
                new Drink { Name = "Tea", Type="Tea and Coffee", Calories = 10, Price = 1, Volume = 120 }
            };
    }
}
