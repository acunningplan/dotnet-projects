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
            // create a directory
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code");
            CreateDirectory(dir);
            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#");
            textWriter.Close();
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine(
                $"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist (press ENTER): ");
            ReadLine();

            // delete main file and read backup file
            File.Delete(textFile);
            WriteLine($"Reading contents of {backupFile}");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // Getting file information
            var info = new FileInfo(backupFile);
            WriteLine($"{ backupFile}");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");
        }
    }
}
