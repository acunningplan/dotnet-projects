using System;
using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;
            int trials = 0;
            do
            {
                Write("Enter your password:");
                password = ReadLine();
                trials++;
            }
            while (password != "Pa$$w0rd" && trials < 3);
            if (password == "Pa$$w0rd")
            {
                WriteLine("Correct!");
            }
            else
            {
                WriteLine("Tried too many times!");
            }

            // Skipped for loop and foreach loop
        }
    }
}
