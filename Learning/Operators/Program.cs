using System;
using static System.Console;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            bool b = false;
            WriteLine($"a & DoStuff() = { a & DoStuff()}");
            WriteLine($"b & DoStuff() = { b & DoStuff()}");

            int age = 47;
            char firstDigit = age.ToString()[0];
            WriteLine($"The first digit of {age} is {firstDigit}");
        }

        private static bool DoStuff()
        {
            WriteLine("I am doing something");
            return true;
        }
    }
}
