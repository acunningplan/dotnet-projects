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
            return ingList.Find(ing => ing.Name == ingName.ConvertToTitleCase()) ??
                throw new RestException(HttpStatusCode.BadRequest, "Food item not found");
        }
        public static Ingredient SelectByNameAndSize(this List<Ingredient> ingList, string name, string size)
        {
            return ingList.Find(ing => ing.Name == name.ConvertToTitleCase() & ing.Size == size.ConvertToTitleCase()) ??
                throw new RestException(HttpStatusCode.BadRequest, "Food item not found");
        }
        public static Ingredient SelectDefault(this List<Ingredient> ingList)
        {
            return ingList[0];
        }
    }
}
