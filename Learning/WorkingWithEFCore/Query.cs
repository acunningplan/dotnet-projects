using static System.Console;
using Models;
using Logger;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WorkingWithEFCore
{
    public class Query
    {
        public static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                //WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related products
                IQueryable<Category> cats = db.Categories
                    .TagWith("Query Tag: Categories and how many products they have:");
                //.Include(c => c.Products);
                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        public static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products that cost more than a price, highest at top.");
                string input;
                double price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                }
                while (!double.TryParse(input, out price));
                IOrderedEnumerable<Product> prods = db.Products
                    .AsEnumerable()
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);
                foreach (Product item in prods)
                {
                    WriteLine(
                        "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                        item.ProductID, item.ProductName, item.Cost, item.Stock);
                }
            }
        }

        public static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
                foreach (Product item in prods)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued? {2}", item.ProductName, item.Stock, item.Discontinued);
                }
            }
        }
        public static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}", "ID", "Product Name", "Cost", "Stock", "Disc.");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        item.ProductID, item.ProductName, item.Cost,
                        item.Stock, item.Discontinued);
                }
            }
        }
    }
}
