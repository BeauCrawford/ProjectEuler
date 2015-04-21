using System;

namespace ProjectEuler
{
    public abstract class Problem
    {
        protected Problem()
        {
        }

        public abstract void Execute();

        protected void Require(object expected, object actual)
        {
            if (!object.Equals(expected, actual))
                throw new InvalidOperationException(string.Format("Expected {0}, Actual {1}", expected, actual));
        }
    }
}