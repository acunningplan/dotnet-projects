using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public static class Ingredients
    {
        public static Buns Buns => new Buns();
        public static Patties Patties => new Patties();
        public static Toppings Toppings => new Toppings();
    }
}
