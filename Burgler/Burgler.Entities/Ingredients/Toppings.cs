using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Topping : Ingredient
    {
        public Topping()
        {
            Type = "Topping";
        }
    }

    public class Toppings : SelectableIngredientList
    {
        public Toppings()
        {
            IngredientList = new List<Ingredient>
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
}
