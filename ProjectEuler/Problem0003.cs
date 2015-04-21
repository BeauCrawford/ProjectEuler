using System.Linq;

namespace ProjectEuler
{
    public class Problem0003 : Problem
    {
        public override void Execute()
        {
            // The prime factors of 13195 are 5, 7, 13 and 29.

            // What is the largest prime factor of the number 600851475143 ?

            var max = MathHelper.FindFactors(600851475143).Where(f => MathHelper.IsPrime(f)).Max();

            Require((long)6857, max);
        }
    }
}