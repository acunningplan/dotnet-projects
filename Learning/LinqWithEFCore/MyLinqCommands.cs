using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Linq;

namespace LinqWithEFCore
{
    public class MyLinqCommands
    {
        public static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .ProcessSequence()
                    .Where(product => product.UnitPrice < 10)
                    // IQueryable<Product>
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });

                WriteLine("Product that cost less than $10.");
                foreach (var item in query)
                {
                    WriteLine("{0}: {1} costs {2:$#,##0.00}",
                        item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }
        }

        public static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryJoin = db.Categories.Join(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, p) =>
                    new { c.CategoryName, p.ProductName, p.ProductID });
                foreach (var item in queryJoin)
                {
                    WriteLine("{0}: {1} is in {2}.",
                        arg0: item.ProductID,
                        arg1: item.ProductName,
                        arg2: item.CategoryName);
                }
            }
        }

        public static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())

            { // group all products by their category to return 8 matches 
                var queryGroup = db.Categories
                    .AsEnumerable()
                    .GroupJoin(inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) =>
                    new { c.CategoryName, Products = matchingProducts.OrderBy(p => p.ProductName) });
                foreach (var category in queryGroup)
                {
                    WriteLine("{0} has {1} products.", arg0: category.CategoryName, arg1: category.Products.Count());
                    foreach (var product in category.Products)
                    {
                        WriteLine($"  {product.ProductName}");
                    }
                }
            }
        }

        public static void AggregateProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-25} {1,10}", arg0: "Product count:",
                    arg1: db.Products.Count());
                WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Highest product price:",
                    arg1: db.Products.Max(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:N0}", arg0: "Sum of units in stock:",
                    arg1: db.Products.Sum(p => p.UnitsInStock));
                WriteLine("{0,-25} {1,10:N0}", arg0: "Sum of units on order:",
                    arg1: db.Products.Sum(p => p.UnitsOnOrder));
                WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Average unit price:",
                    arg1: db.Products.Average(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Value of units in stock:",
                    arg1: db.Products
                    .AsEnumerable()
                    .Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }
    }
}
