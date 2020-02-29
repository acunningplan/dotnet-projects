using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;


namespace SerializeXml
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8.0 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 },
            };

            var serializerXml = new XmlSerializer(typeof(List<Shape>));
            string path = Combine(CurrentDirectory, "shapes.xml");
            using (FileStream stream = File.Create(path))
            {
                serializerXml.Serialize(stream, listOfShapes);
            }

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                List<Shape> loadedShapesXml = serializerXml.Deserialize(stream) as List<Shape>;
                foreach (Shape item in loadedShapesXml)
                {
                    WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Colour, item.Area);
                };
            }
        }

        [XmlInclude(typeof(Circle))]
        [XmlInclude(typeof(Rectangle))]
        public class Shape
        {
            //public Shape() { }
            public string Colour { get; set; }
            public double Area { get; set; }
        }

        public class Circle : Shape
        {
            //public Circle() : base() { }
            public double Radius { get; set; }
        }
        public class Rectangle : Shape
        {
            //public Rectangle() : base() { }
            public double Height { get; set; }
            public double Width { get; set; }
        }
    }
}