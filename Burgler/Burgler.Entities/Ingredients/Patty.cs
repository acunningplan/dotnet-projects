using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public class Patty : Ingredient
    {
        public Patty()
        {
            Type = "Patty";
        }
    }

    public class Patties : SelectableIngredientList
    {
        public Patties()
        {
            IngredientList = new List<Ingredient>
            {
                new Patty { Name = "BeefSingle", Calories = 250, Price = 2 },
                new Patty { Name = "BeefDouble", Calories = 500, Price = 3.5 } ,
                new Patty { Name = "ChickenSingle", Calories = 200, Price = 1.5 },
                new Patty { Name = "ChickenDouble", Calories = 400, Price = 3 } ,
                new Patty { Name = "FishSingle", Calories = 150, Price = 2 } ,
                new Patty { Name = "FishDouble", Calories = 300, Price = 3.5 } ,
                new Patty { Name = "VeggieSingle", Calories = 100, Price = 1.0 } ,
                new Patty { Name = "VeggieDouble", Calories = 200, Price = 2.0 } ,
            };
        }
    }
}
