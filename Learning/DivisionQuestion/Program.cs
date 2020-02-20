using System;
using static System.Console;

namespace DivisionQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            int y = 2 + ++x;
            WriteLine($"{x} {y}");

            int x2 = 3 << 2;
            int y2 = 10 >> 1;
            WriteLine($"{x2} {y2}");

            int x3 = 10 & 8;
            int y3 = 10 | 7;
            WriteLine($"{x3} {y3}");
            try
            {
                Write("Enter a number between 0 and 255: ");
                int num1 = int.Parse(ReadLine());
                Write("Enter another number between 0 and 255: ");
                int num2 = int.Parse(ReadLine());
                int divided = num1 / num2;
                WriteLine($"{num1} divided by {num2} is {divided}");
            }
            catch (FormatException)
            {
                WriteLine("You entered the wrong format!");
            }
            catch (Exception ex)
            {
                WriteLine("Can't parse your input!");
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }
    }
}
