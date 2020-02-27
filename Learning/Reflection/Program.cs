using System;
using System.Reflection;
using static System.Console;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($"  Full name: {assembly.FullName}");
            WriteLine($"  Location: {assembly.Location}");
            var attributes = assembly.GetCustomAttributes();
            WriteLine($"  Attributes:");
            foreach (Attribute a in attributes)
            {
                WriteLine($"    {a.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($"  Version: {version.InformationalVersion}");
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($"  Company: {company.Company}");
        }
    }
}
