using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class StringConversion
    {
        public static string ConvertToTitleCase(this string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return null;
            var outputString = inputString.ToLower().Replace("-", " ").Replace("_", " ");
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            outputString = info.ToTitleCase(outputString);
            return outputString;
        }
    }
}
