using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Net;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class IngredientListExtensions
    {
        public static Ingredient SelectByName(this List<Ingredient> ingList, string ingName)
        {
            if (string.IsNullOrEmpty(ingName)) return null;
            return ingList.Find(ing => ing.Name == ingName.ConvertToTitleCase());
        }
        public static Ingredient SelectByNameAndSize(this List<Ingredient> ingList, string name, string size)
        {
            if (string.IsNullOrEmpty(name) | string.IsNullOrEmpty(size)) return null;
            return ingList.Find(ing => ing.Name == name.ConvertToTitleCase() & ing.Size == size.ConvertToTitleCase());
        }
        public static Ingredient SelectDefault(this List<Ingredient> ingList)
        {
            return ingList[0];
        }
    }
}
