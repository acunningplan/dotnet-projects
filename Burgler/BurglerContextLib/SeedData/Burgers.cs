using Burgler.Entities.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Burgers
    {
        public static List<Burger> BurgersList => new List<Burger>
            {
                new Burger { Name = "Classic Burgler", Type ="Beef" },
                new Burger { Name = "Bacon Burgler", Type ="Beef", BurgerToppings = "Tomato+Lettuce+Bacon"  },
                new Burger { Name = "Mushroom Swiss", Type ="Beef", BurgerToppings = "Swiss Cheese+Mushrooms"},
                new Burger { Name = "Grilled Chicken", Type ="Chicken", BurgerPatty = "Chicken" },
                new Burger { Name = "Tofu Burgler", Type ="Veggie", BurgerPatty = "Veggie" },
                new Burger { Name = "Black Bean Burgler", Type ="Veggie", BurgerPatty = "Veggie" },
            };
    }
}
