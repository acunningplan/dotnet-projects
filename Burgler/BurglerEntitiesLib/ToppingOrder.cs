using System;
using System.Collections.Generic;
using System.Text;

namespace OrderEntitiesLib
{
    public class ToppingOrder
    {
        [Flags]
        public enum Toppings : short
        {
            None = 0,
            Tomato = 1,
            Cheddar = 2,
            Pickle = 4,
            TruffleSauce = 8,
            Mushrooms = 16,
            Bacon = 32
        }
    }
}
