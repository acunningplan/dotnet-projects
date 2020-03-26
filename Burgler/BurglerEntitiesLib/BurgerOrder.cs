using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerEntitiesLib
{
    public class BurgerOrder
    {
        public int Quantity { get; set; }
        public string BunType { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }

    }
}
