using static System.Console;

namespace WritingFunctions
{
    class CardinalToOrdinal
    {
        public static void RunConvertToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{ConvertToOrdinal(number)}");
            }
        }
        /// <summary>
        /// Pass a 32-bit integer and it will be converted into its ordinal equivalent
        /// </summary>
        /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
        /// <returns>Number as  an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
        static string ConvertToOrdinal(int number)
        {

            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th ";
                default:
                    string numberAsText = number.ToString();
                    char lastDigit = numberAsText[numberAsText.Length - 1];
                    string suffix = lastDigit switch
                    {
                        '1' => "st",
                        '2' => "nd",
                        '3' => "rd",
                        _ => "th"
                    };
                    return $"{number}{suffix} ";
            }
        }
    }
}
