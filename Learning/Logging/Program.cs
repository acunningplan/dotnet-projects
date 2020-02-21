using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;


namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            Trace.AutoFlush = true;

            Debug.WriteLine("Debug says, I'm watching!");
            Trace.WriteLine("Trace says, I am watching!");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var ts = new TraceSwitch(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");
            configuration.GetSection("PacktSwitch").Bind(ts);
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}
