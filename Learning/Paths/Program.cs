using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;

namespace Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFiles();
        }

        static void WorkWithFiles()
        {
            //// create a directory
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code");
            CreateDirectory(dir);
            //// define file paths
            string textFile = Combine(dir, "Dummy.txt");

            WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
            WriteLine($"File Name: {GetFileName(textFile)}");
            WriteLine("File Name without Extension: {0}", GetFileNameWithoutExtension(textFile));
            WriteLine($"File Extension: {GetExtension(textFile)}");
            WriteLine($"Random File Name: {GetRandomFileName()}");
            WriteLine($"Temporary File Name: {GetTempFileName()}");

        }
    }
}
