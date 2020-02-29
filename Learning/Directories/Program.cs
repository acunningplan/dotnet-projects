using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithDirectories();
        }

        static void WorkWithDirectories()
        {
            // define a directory path for a new folder 
            // starting in the user's folder 
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with: {newFolder}");
            // check if it exists 
            WriteLine($"Does it exist? {Exists(newFolder)}");
            // create directory  
            WriteLine("Creating it...");
            CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Exists(newFolder)}");
            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();
            // delete directory  
            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exist? {Exists(newFolder)}");
        }
    }
}
