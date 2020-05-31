using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Burgler.Entities.FoodItem
{
    public class BurgerItem : FoodItem
    {
        public BurgerItem()
        {
            Size = "Small";
        }
        public Guid BurgerItemId { get; set; }
        public int CustomId { get; set; }
        public string BurgerBun { get; set; } = "White";
        public string BurgerPatty { get; set; } = "Beef";
        public string BurgerPattyCooked { get; set; } = "Medium";
        public string BurgerToppings { get; set; } = "Tomato+Lettuce";
        //public int PattyDoneness { get; set; } = 0;
        public Guid OrderId { get; set; }
        public virtual OrderNS.Order Order { get; set; }
    }
}
