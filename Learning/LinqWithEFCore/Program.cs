using System;
using static System.Console;
using System.Linq;
using System.Xml.Linq;
using static LinqWithEFCore.MyLinqCommands;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilterAndSort();
            //JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //AggregateProducts();
            //CustomExtensionMethods();

            //ProcessSettings();

            LinqExercise.SearchByCity();
        }



        static void CustomExtensionMethods()
        {
            using (var db = new Northwind())
            {
                WriteLine("Mean units in stock: {0:N0}", db.Products.Average(p => p.UnitsInStock));
                WriteLine("Mean unit price: {0:$#,##0.00}", db.Products.Average(p => p.UnitPrice));
                WriteLine("Median units in stock: {0:N0}", db.Products.Median(p => p.UnitsInStock));
                WriteLine("Median unit price: {0:$#,##0.00}", db.Products.Median(p => p.UnitPrice));
                WriteLine("Mode units in stock: {0:N0}", db.Products.Mode(p => p.UnitsInStock));
                WriteLine("Mode unit price: {0:$#,##0.00}", db.Products.Mode(p => p.UnitPrice));
            }
        }
        static void OutputProductsAsXml()
        {
            using (var db = new Northwind())
            {
                var productsForXml = db.Products.ToArray();

                var xml = new XElement("products",
                    from p in productsForXml
                    select new XElement("product",
                        new XAttribute("id", p.ProductID),
                        new XAttribute("price", p.UnitPrice),
                        new XElement("name", p.ProductName)));
                WriteLine(xml.ToString());
            }
        }

        static void ProcessSettings()
        {
            XDocument doc = XDocument.Load("settings.xml");
            var appSettings = doc.Descendants("appSettings")
                .Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value
                }).ToArray();
            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
