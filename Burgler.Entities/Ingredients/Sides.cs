using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Ingredients
{
    public class Side : Ingredient
    {
        public string Type { get; set; }
        public string Size { get; set; } = "Small";
        public string ImageUrl { get; set; }
    }
}
