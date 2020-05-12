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
                new Burger { Name = "Classic Burgler", Type ="Beef", Size="Single", Price=0, Calories=0 },
                new Burger { Name = "Classic Burgler", Type ="Beef", Size="Double", Price=0, Calories=0 },
                new Burger { Name = "Bacon Burgler", Type ="Beef", BurgerToppings = "Tomato+Lettuce+Bacon", Size="Single", Price=0, Calories=0  },
                new Burger { Name = "Bacon Burgler", Type ="Beef", BurgerToppings = "Tomato+Lettuce+Bacon", Size="Double", Price=0, Calories=0  },
                new Burger { Name = "Mushroom Swiss", Type ="Beef", BurgerToppings = "Swiss Cheese+Mushrooms", Size="Single", Price=0, Calories=0},
                new Burger { Name = "Mushroom Swiss", Type ="Beef", BurgerToppings = "Swiss Cheese+Mushrooms", Size="Double", Price=0, Calories=0},
                new Burger { Name = "Grilled Chicken", Type ="Chicken", BurgerPatty = "Chicken", Size="Single", Price=0, Calories=0 },
                new Burger { Name = "Grilled Chicken", Type ="Chicken", BurgerPatty = "Chicken", Size="Double", Price=0, Calories=0 },
                new Burger { Name = "Tofu Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Single", Price=0, Calories=0 },
                new Burger { Name = "Tofu Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Double", Price=0, Calories=0 },
                new Burger { Name = "Black Bean Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Single", Price=0, Calories=0 },
                new Burger { Name = "Black Bean Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Double", Price=0, Calories=0 },
            };
    }
}
