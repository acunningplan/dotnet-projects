using static System.Console;


namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Query.QueryingCategories();
            // Query.QueryingProducts();
            //Query.QueryingWithLike();
            //if (Command.AddProduct(6, "Bob's Burgers", 500))
            //{
            //    WriteLine("Product added.");
            //}

            //if (Command.IncreaseProductPrice("Bob", 20))
            //{
            //    WriteLine("Product updated.");
            //}

            int deleted = Command.DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) were deleted.");

            Query.ListProducts();
        }
    }
}
