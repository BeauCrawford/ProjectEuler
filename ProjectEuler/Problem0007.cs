using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem0007 : Problem
    {
        public override void Execute()
        {
            // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            // What is the 10,001st prime number?

            var results = new List<int>();

            int i = 0;

            while (true)
            {
                if (MathHelper.IsPrime(++i))
                {
                    results.Add(i);

                    if (results.Count >= 10001)
                        break;
                }
            }

            Console.WriteLine("COUNT: " + results.Count);

            Console.WriteLine(results.Last());
        }
    }
}
