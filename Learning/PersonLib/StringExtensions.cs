using System;
using System.Text.RegularExpressions;

namespace Shared
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {  // use simple regular expression to check   
            // that the input string is a valid email   
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }
        public static bool IsValidPassword(this string input)
        {
            // minimum of eight valid characters 
            return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
        }
        public static bool IsValidHex(this string input)
        { // three or six valid hex number characters
            return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}
