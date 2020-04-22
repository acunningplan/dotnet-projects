using Burgler.Entities.FoodItem;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Burgler.Entities.Ingredients
{

    public class Burger
    {
        // Override burger topping items
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string BurgerBun { get; set; } = "White";
        public string BurgerPatty { get; set; } = "Beef";
        public string BurgerPattyCooked { get; set; } = "Medium";
        public string BurgerToppings { get; set; } = "Tomato+Lettuce";
    }
}
