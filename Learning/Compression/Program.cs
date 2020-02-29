using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithCompression();
        }
        private static string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
        static void WorkWithCompression()
        { // compress the XML output
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");
            FileStream gzipFile = File.Create(gzipFilePath);
            using (GZipStream compressor = new GZipStream(gzipFile, CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                    // the normal call to WriteEndElement is not necessary
                    // because when the XmlWriter disposes, it will 
                    // automatically end any elements of any depth
                }
            }
            // also closes the underlying stream
            // output all the contents of the compressed file 
            WriteLine("{0} contains {1:N0} bytes.", gzipFilePath, new FileInfo(gzipFilePath).Length);
            WriteLine($"The compressed contents:");
            WriteLine(File.ReadAllText(gzipFilePath));
            // read a compressed file
            WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    // read the next XML node
                    {
                        // check if we are on an element node named callsign  
                        if ((reader.NodeType == XmlNodeType.Element)
                           && (reader.Name == "callsign"))
                        {
                            reader.Read();     // move to the text inside element 
                            WriteLine($"{reader.Value}"); // read its value 
                        }
                    }
                }
            }
        }
    }
}
