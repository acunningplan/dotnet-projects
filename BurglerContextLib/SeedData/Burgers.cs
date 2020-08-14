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
                new Burger { Name = "Classic Burgler", Type ="Beef", Size="Single", ImageUrl="https://imgur.com/oCsL8P1" },
                new Burger { Name = "Classic Burgler", Type ="Beef", Size="Double", ImageUrl="https://imgur.com/oCsL8P1" },
                new Burger { Name = "Bacon Burgler", Type ="Beef", BurgerToppings = "Tomato+Lettuce+Bacon", Size="Single", ImageUrl="https://imgur.com/LjGdBJW"  },
                new Burger { Name = "Bacon Burgler", Type ="Beef", BurgerToppings = "Tomato+Lettuce+Bacon", Size="Double", ImageUrl="https://imgur.com/LjGdBJW"  },
                new Burger { Name = "Mushroom Swiss", Type ="Beef", BurgerToppings = "Swiss Cheese+Mushrooms", Size="Single", ImageUrl="https://imgur.com/Wp8olcs"},
                new Burger { Name = "Mushroom Swiss", Type ="Beef", BurgerToppings = "Swiss Cheese+Mushrooms", Size="Double", ImageUrl="https://imgur.com/Wp8olcs"},
                new Burger { Name = "Grilled Chicken", Type ="Chicken", BurgerPatty = "Chicken", Size="Single", ImageUrl="https://imgur.com/7tTQpB0" },
                new Burger { Name = "Grilled Chicken", Type ="Chicken", BurgerPatty = "Chicken", Size="Double", ImageUrl="https://imgur.com/7tTQpB0" },
                new Burger { Name = "Tofu Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Single", ImageUrl="" },
                new Burger { Name = "Tofu Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Double", ImageUrl="" },
                new Burger { Name = "Black Bean Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Single", ImageUrl="" },
                new Burger { Name = "Black Bean Burgler", Type ="Veggie", BurgerPatty = "Veggie", Size="Double", ImageUrl="" },
            };
    }
}
