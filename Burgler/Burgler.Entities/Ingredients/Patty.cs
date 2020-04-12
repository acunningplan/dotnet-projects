using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Patty : Ingredient
    {
        public Patty()
        {
            Type = "Patty";
        }
    }

    public static class Patties
    {
        public static List<Ingredient> PattyList = new List<Ingredient>
            {
                new Patty { Name = "Beef", Size="Single", Calories = 250, Price = 2 },
                new Patty { Name = "Beef", Size="Double",  Calories = 500, Price = 3.5 } ,
                new Patty { Name = "Chicken", Size="Single",  Calories = 200, Price = 1.5 },
                new Patty { Name = "Chicken", Size="Double",  Calories = 400, Price = 3 } ,
                new Patty { Name = "Fish", Size="Single",  Calories = 150, Price = 2 } ,
                new Patty { Name = "Fish", Size="Double",  Calories = 300, Price = 3.5 } ,
                new Patty { Name = "Veggie", Size="Single",  Calories = 100, Price = 1.0 } ,
                new Patty { Name = "Veggie", Size="Double", Calories = 200, Price = 2.0 } ,
            };
    }
}
