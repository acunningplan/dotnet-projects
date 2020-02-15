using System;
using static System.Console;
using System.IO;

namespace SwitchStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {number}");
            switch (number)
            {
                case 1:
                    WriteLine($"The random number is one or three");
                    break;
                case 2:
                    WriteLine($"The number is 2.");
                    break;
                case 3:
                    goto case 1;
                default:
                    break;
            }
            // Make sure this folder exists or you'll get an unhandled exception!
            string path = @"C:\Users\jlfly\Desktop\repos\dotnet-projects\Learning\SwitchStatements";
            Stream s = File.Open(
                Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);
            string message = string.Empty;
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "This is a read-only file";
                    break;
                case MemoryStream ms:
                    message = "The stream is a file that I can write to.";
                    break;
                default:
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null";
                    break;
            }
            WriteLine(message);

            message = s switch
            {
                FileStream writeableFile when s.CanWrite => "The stream is a file that I can write to.",
                FileStream readOnlyFile => "The stream is a read-only file",
                MemoryStream ms => "The stream is a memory address.",
                null => "The stream is null",
                _ => "The stream is some other type."
            };
            WriteLine(message);
        }
    }
}
