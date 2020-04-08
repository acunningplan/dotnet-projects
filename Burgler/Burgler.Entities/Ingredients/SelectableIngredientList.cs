using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class SelectableIngredientList
    {
        public List<Ingredient> IngredientList { get; set; }
        public Ingredient SelectDefault()
        {
            return IngredientList[0];
        }

        public Ingredient SelectByName(string ingName)
        {
            return IngredientList.Find(ing => ing.Name == ingName) ?? IngredientList[0];
        }
    }
}
