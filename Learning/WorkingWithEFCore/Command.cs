using static System.Console;
using Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    public class Command
    {
        public static bool AddProduct(int categoryID, string productName, double? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };
                // mark product as added in change tracking 
                db.Products.Add(newProduct); // save tracked change to database
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        public static bool IncreaseProductPrice(string name, double amount)
        {
            using (var db = new Northwind())
            {
                // get first product whose name starts with name 
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        public static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    WriteLine("Transaction isolation level: {0}", t.GetDbTransaction().IsolationLevel);

                    IEnumerable<Product> products = db.Products.Where(
                        p => p.ProductName.StartsWith(name));
                    db.Products.RemoveRange(products);
                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                }
            }
        }
    }
}
