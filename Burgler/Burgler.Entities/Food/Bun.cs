using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Food
{
    public class Bun : Food
    {
        public Bun()
        {
            FoodType = "Bun";
        }
    }

    public static class Buns
    {
        private static List<Bun> bunsList = new List<Bun>()
        {
            new Bun { Name = "White", Calories = 50, Price = 1 },
            new Bun { Name = "Wheat", Calories = 45, Price = 1 }
        };
        public static Bun GetBun(string bunName)
        {
            // should throw error if bun is not in bunsList
            return bunsList.Find(bun => bun.Name == bunName) ?? bunsList[0];
        }
        public static Bun GetDefaultBun()
        {
            return bunsList[0];
        }
    }
}
