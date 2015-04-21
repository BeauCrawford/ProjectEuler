namespace ProjectEuler
{
    public class Problem0005 : Problem
    {
        public override void Execute()
        {
            // Position: 258,285

            // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

            // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

            const int TargetCount = 20;

            int number = 0;

            while (true)
            {
                number++;

                int matches = 0;

                for (int i = 1; i <= TargetCount; i++)
                {
                    if (number % i == 0)
                    {
                        matches++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (matches == TargetCount)
                {
                    break;
                }
            }

            Require(232792560, number);
        }
    }
}