using System;
using System.Collections.Generic;

namespace PrimeCalculatorLib
{
    // Finds prime factors of a number between 2 and 1000
    public class PrimeCalculator
    {
        int[] PrimeNumberList = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 39 };
        List<int> FactorsList = new List<int>();
        string FactorString;
        public string PrimeFactors(int num)
        {
            int input_num = num;
            foreach (int i in PrimeNumberList)
            {
                while (num % i == 0)
                {
                    FactorsList.Add(i);
                    num = num / i;
                }
            }

            // If input is a prime number larger than 39:
            if (num == input_num)
            {
                FactorsList.Add(num);
            }


            // Make a string showing all the prime factors from the list of factors
            FactorString = FactorsList[0].ToString();
            FactorsList.RemoveAt(0);

            foreach (int i in FactorsList)
            {
                FactorString += $" x {i}";
            }

            return $"Prime factors of {input_num} are: {FactorString}";
        }
    }
}
