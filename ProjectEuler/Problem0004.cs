using System.Collections.Generic;
namespace ProjectEuler
{
    public class Problem0004 : Problem
    {
        public override void Execute()
        {
            // Position: 245,626

            // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
            // Find the largest palindrome made from the product of two 3-digit numbers.

            var numbers = new List<int>();

            for (int i = 100; i <= 999; i++)
            {
                numbers.Add(i);
            }

            int max = 0;

            foreach (var numberA in numbers)
            {
                foreach (var numberB in numbers)
                {
                    var product = numberA * numberB;

                    if (MathHelper.IsPalidrome(product))
                    {
                        if (product > max)
                            max = product;
                    }
                }
            }

            Require(906609, max);
        }
    }
}