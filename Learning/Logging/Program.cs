using System.Diagnostics;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Debug says, I'm watching!");
            Trace.WriteLine("Trace says, I am watching!");
        }
    }
}
