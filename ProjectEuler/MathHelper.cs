using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class MathHelper
    {
        public static bool IsPalidrome(int number)
        {
            if (number < 0)
                return false;

            var chars = number.ToString().ToCharArray();

            if (chars.Length == 1)
                return true;

            int matchCount = 0;

            for (int i = 0; i < chars.Length / 2; i++)
            {
                var other = chars.Length - 1 - i;

                if (chars[i] == chars[other])
                    matchCount++;
                    
            }

            return matchCount == chars.Length / 2;
        }

        public static bool IsMultipleOf(int x, int n)
        {
            return (x % n) == 0;
        }

        public static bool IsPrime(long number)
        {
            var boundary = Math.Floor(Math.Sqrt(number));

            if (number == 1)
                return false;

            if (number == 2)
                return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static IEnumerable<long> FindFactors(long number)
        {
            var factors = new List<long>();

            int max = (int)Math.Sqrt(number);

            for (long factor = 1; factor <= max; ++factor)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);

                    if (factor != number / factor)
                    {
                        factors.Add(number / factor);
                    }
                }
            }

            factors.Sort();

            return factors;
        }

        public static IEnumerable<ulong> Fibonacci(ulong? maxValue = null)
        {
            var fibonacci = new List<ulong>();
            fibonacci.Add(1);
            fibonacci.Add(1);
            fibonacci.Add(2);

            int i = 2;

            while (true)
            {
                var sum = fibonacci[i - 2] + fibonacci[i - 1];

                if (maxValue.HasValue && sum >= maxValue)
                    break;

                fibonacci.Add(sum);

                i++;
            }

            return fibonacci;
        }
    }
}
