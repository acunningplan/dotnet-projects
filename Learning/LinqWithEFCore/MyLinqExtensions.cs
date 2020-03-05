using System.Collections.Generic;

namespace System.Linq
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<T> ProcessSequence<T>(
            this IEnumerable<T> sequence)
        { // you could do some processing here
            return sequence;
        }
        // these are scalar LINQ extension methods 
        public static int? Median(this IEnumerable<int?> sequence)
        {
            var ordered = sequence.OrderBy(item => item);
            int middlePosition = ordered.Count() / 2;
            return ordered.ElementAt(middlePosition);
        }
        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }
        public static double? Median(this IEnumerable<double?> sequence)
        {
            var ordered = sequence.OrderBy(item => item);
            int middlePosition = ordered.Count() / 2;
            return ordered.ElementAt(middlePosition);
        }
        public static double? Median<T>(this IEnumerable<T> sequence, Func<T, double?> selector)
        {
            return sequence.Select(selector).Median();
        }
        public static int? Mode(this IEnumerable<int?> sequence)
        {
            var grouped = sequence.GroupBy(item => item);
            var orderedGroups = grouped.OrderBy(group => group.Count());
            return orderedGroups.FirstOrDefault().Key;
        }
        public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Mode();
        }
        public static double? Mode(this IEnumerable<double?> sequence)
        {
            var grouped = sequence.GroupBy(item => item);
            var orderedGroups = grouped.OrderBy(group => group.Count());
            return orderedGroups.FirstOrDefault().Key;
        }
        public static double? Mode<T>(this IEnumerable<T> sequence, Func<T, double?> selector)
        {
            return sequence.Select(selector).Mode();
        }
    }
}
