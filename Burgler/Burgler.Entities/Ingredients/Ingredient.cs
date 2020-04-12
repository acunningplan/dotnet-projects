using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Ingredient
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Size { get; set; } = "Small";
        public double Calories { get; set; }
        public double Price { get; set; }
    }
}
