using System;
using System.Collections.Generic;
using System.Text;

namespace FoodEntitiesLib
{
    public class Patty : Food
    {
        public Patty()
        {
            FoodType = "Patty";
        }
    }

    public static class Patties
    {
        private static List<Patty> pattiesList = new List<Patty>()
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
        public static Patty GetPatty(string pattyName)
        {
            if (pattyName == "default") return pattiesList[0];
            // should throw error if patty is not in pattiesList
            return pattiesList.Find(patty => patty.Name == pattyName) ?? pattiesList[0];
        }
        public static Patty GetDefaultPatty()
        {
            return  pattiesList[0];
        }
    }
}
