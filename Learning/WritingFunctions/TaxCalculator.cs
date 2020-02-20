using static System.Console;

namespace WritingFunctions
{
    class TaxCalculator
    {
        public static void RunCalculateTax()
        {
            Write("Enter an amount");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code:");
            string region = ReadLine();
            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount.");
            }
        }
        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = twoLetterRegionCode switch
            {
                "CH" => 0.08M,
                "DK" => 0.0M,
                "NO" => 0.25M,
                "GB" => 0.0M,
                "FR" => 0.2M,
                "HU" => 0.27M,
                _ => 0.06M
            };
            return amount * rate;
        }
    }
}
