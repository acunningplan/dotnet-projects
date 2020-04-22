using Burgler.Entities.IngredientsNS;
using System.Collections.Generic;

namespace BurglerContextLib.SeedData
{

    public class PattyCooked
    {
        public static List<DonenessLevel> DonenessLevels = new List<DonenessLevel>
        {
            new DonenessLevel{ Doneness = "Medium" },
            new DonenessLevel{ Doneness = "Well Done" },
            new DonenessLevel{ Doneness = "Medium Rare" }
        };
    }
}
