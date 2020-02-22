using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class FactorialCalculator
    {
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }
    }
}
