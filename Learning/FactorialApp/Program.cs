using static System.Console;
using static Shared.FactorialCalculator;

namespace FactorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"5! is {Factorial(5)}");
        }
    }
}
