﻿using System;

namespace ProjectEuler
{
    public class Problem0001 : Problem
    {
        public override void Execute()
        {
            // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

            // Find the sum of all the multiples of 3 or 5 below 1000.

            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (MathHelper.IsMultipleOf(i, 3) || MathHelper.IsMultipleOf(i, 5))
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}