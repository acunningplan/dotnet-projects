using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Ingredients
{
    public static class IngredientListExtensionMethods
    {
        public static Ingredient SelectByName(this List<Ingredient> ingList, string ingName)
        {
            return ingList.Find(ing => ing.Name == ingName) ?? ingList[0];
        }
        public static Ingredient SelectDefault(this List<Ingredient> ingList)
        {
            return ingList[0];
        }
    }
}
