using System.Collections.Generic;

namespace ProjectEuler
{
    public static class Extensions
    {
        public static IEnumerable<int> ParseInts(this string values)
        {
            foreach (var value in values.Split(','))
            {
                yield return int.Parse(value);
            }
        }

        public static IEnumerable<byte> ParseBytes(this string values)
        {
            foreach (var value in values.Split(','))
            {
                yield return byte.Parse(value);
            }
        }

        public static ulong CalculateSum(this IEnumerable<ulong> items)
        {
            ulong total = 0;

            foreach (var i in items)
            {
                total += i;
            }

            return total;
        }
    }
}
