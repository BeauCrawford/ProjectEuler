﻿using System;
using System.Linq;

namespace ProjectEuler
{
    public class Problem0002 : Problem
    {
        public override void Execute()
        {
            /*
            Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

            By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
             
            */

            var total = MathHelper.Fibonacci(maxValue: 4000000).Where(e => e % 2 == 0).CalculateSum();

            Console.WriteLine(total);
        }
    }
}
