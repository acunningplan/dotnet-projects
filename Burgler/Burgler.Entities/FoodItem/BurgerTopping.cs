using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.FoodItem
{
    public class BurgerTopping
    {
        public Guid BurgerToppingId { get; set; }
        public string Name { get; set; }
        public Guid BurgerItemId { get; set; }
        public virtual BurgerItem BurgerItem { get; set; }
    }
}
