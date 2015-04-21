using System.Numerics;

namespace ProjectEuler
{
    public class Problem0025 : Problem
    {
        public override void Execute()
        {
            // Result: 90,216

            var current = new BigInteger(0);
            var previous2 = new BigInteger(1);
            var previous1 = new BigInteger(1);

            int counter = 3;

            while (true)
            {
                current = previous1 + previous2;
                previous2 = previous1;
                previous1 = current;

                if (current.ToString().Length >= 1000)
                {
                    break;
                }

                counter++;
            }

            Require(4782, counter);
        }
    }
}
