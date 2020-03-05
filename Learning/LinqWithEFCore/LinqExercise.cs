using static System.Console;
using System.Linq;

namespace LinqWithEFCore
{
    public static class LinqExercise
    {
        public static void SearchByCity()
        {
            using (var db = new Northwind())
            {
                var cities = db.Customers.Select(c => c.City).Distinct();
                WriteLine(string.Join(", ", cities));

                Write("Enter the name of a city: ");
                string city = ReadLine();
                var customers = db.Customers
                     .Where(customer => customer.City == city);
                WriteLine($"There are {customers.Count()} customers in {city}");
                foreach (var customer in customers)
                {
                    WriteLine(customer.CompanyName);
                }
            }
        }
    }
}
