using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
