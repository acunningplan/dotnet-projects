using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.Entities.Food
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
        public static PattyDoneness GetDoneness(string doneness)
        {
            return doneness switch
            {
                "WellDone" => PattyDoneness.WellDone,
                "MediumWell" => PattyDoneness.MediumWell,
                "Medium" => PattyDoneness.Medium,
                "MediumRare" => PattyDoneness.MediumRare,
                _ => PattyDoneness.Medium,  // should throw exception
            };

        }
        public static PattyDoneness GetDefaultDoneness()
        {
            return PattyDoneness.Medium;
        }
    }
}
