using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.IngredientsNS
{
    public enum PattyDoneness
    {
        WellDone,
        MediumWell,
        Medium,
        MediumRare
    }
    public static class PattyCooked
    {
        public static PattyDoneness Select(int doneness)
        {
            return doneness switch
            {
                0 => PattyDoneness.WellDone,
                1 => PattyDoneness.MediumWell,
                2 => PattyDoneness.Medium,
                3 => PattyDoneness.MediumRare,
                _ => PattyDoneness.Medium,  // should throw exception
            };

        }
        public static PattyDoneness SelectDefault()
        {
            return PattyDoneness.Medium;
        }
    }
}
