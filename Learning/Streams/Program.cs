using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace TextStreams
{
    internal class Program
    {
        private static void Main()
        {
            WorkWithText();
        }

        private static string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };

        private static void WorkWithText()
        {
            string textFile = Combine(CurrentDirectory, "streams.txt");
            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);
            // enumerate the strings, writing each one to the stream on a separate line
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close();   // release resources
            // output the contents of the file
            WriteLine("{0} contains {1:N0} bytes.",
                arg0: textFile,
                arg1: new FileInfo(textFile).Length);
            WriteLine(File.ReadAllText(textFile));
        }
    }
}