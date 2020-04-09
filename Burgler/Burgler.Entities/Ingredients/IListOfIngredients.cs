using Burgler.Entities.IngredientsNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Ingredients
{
    public interface IListOfIngredients
    {
        Ingredient SelectDefault();
        Ingredient SelectByName(string ingName);
    }
}
