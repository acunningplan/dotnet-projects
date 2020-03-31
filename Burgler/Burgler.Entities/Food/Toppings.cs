using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Food
{
    public class Topping : Food
    {
        public Topping()
        {
            FoodType = "Topping";
        }
    }

    public static class Toppings
    {
        private static List<Topping> toppingsList = new List<Topping>()
        {
            new Topping { Name = "Tomato", Calories = 50, Price = 1 },
            new Topping { Name = "Gherkin", Calories = 25, Price = 1 },
            new Topping { Name = "Lettuce", Calories = 20, Price = 1 },
            new Topping { Name = "Mayonnaise", Calories = 65, Price = 1 },
            new Topping { Name = "Bacon", Calories = 80, Price = 2.0 },
            new Topping { Name = "Egg", Calories = 50, Price = 1.5 },
        };
        public static Topping GetTopping(string toppingName)
        {
            // should throw error if topping is not in toppingsList
            return toppingsList.Find(topping => topping.Name == toppingName) ?? toppingsList[0];
        }
        public static Topping GetDefaultTopping()
        {
            return toppingsList[0];
        }
    }
}
