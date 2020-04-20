using Burgler.Entities.FoodItem;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Burgler.Entities.Ingredients
{

    public class Burger : BurgerItem
    {
        public new string[] BurgerToppings { get; set; } = { "Tomato", "Lettuce" };
    }

    public class Burgers
    {
        public static List<Burger> BurgerList => new List<Burger>
        {
            new Burger { Name = "Classic Burgler" },
            new Burger { Name = "Bacon Burgler", BurgerToppings = new string[] { "Tomato", "Lettuce", "Bacon" } },
            new Burger { Name = "Mushroom Swiss", BurgerToppings = new string[] { "Swiss Cheese", "Mushrooms" } },
            new Burger { Name = "Grilled Chicken", BurgerPatty = "Chicken" },
            new Burger { Name = "Tofu Burgler", BurgerPatty = "Veggie" },
        };
    }
}
