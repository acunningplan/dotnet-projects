using System;

namespace JupyterLab
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("CMD.exe", "/C conda run jupyter lab");
        }
    }
}
