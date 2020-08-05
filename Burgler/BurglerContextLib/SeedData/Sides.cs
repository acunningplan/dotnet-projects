using Burgler.Entities.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Sides
    {
        public static List<Side> SidesList = new List<Side>
            {
                new Side { Type="Chips", Name = "Hot Chips", Size="Small", Calories = 180, Price = 1 },
                new Side { Type="Chips", Name = "Hot Chips", Size="Large", Calories = 300, Price = 1.5 },
                new Side { Type="Chips", Name = "Extra Seasoned Chips", Size="Small", Calories = 210, Price = 1.2, Description = "Seasoned with olive oil and paprika" },
                new Side { Type="Chips", Name = "Extra Seasoned Chips", Size="Large", Calories = 330, Price = 1.7, Description = "Seasoned with olive oil and paprika"},
                new Side { Type="Salad", Name = "Slaw", Size="Small", Calories = 100, Price = 1.5 },
                new Side { Type="Salad", Name = "Garden Salad", Size="Small", Calories = 80, Price = 1.5 },
                new Side { Type="Other", Name = "Mac And CheeseBites", Size="Small", Calories = 130, Price = 1 },
            };
    }
}
