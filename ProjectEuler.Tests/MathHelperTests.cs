using NUnit.Framework;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class MathHelperTests
    {
        [TestCase(9009)]
        [TestCase(411114)]
        [TestCase(0)]
        public void IsPalidrome_Even_Number_Of_Digits_True(int number)
        {
            Assert.IsTrue(MathHelper.IsPalidrome(number));
        }

        [TestCase(9003)]
        [TestCase(411112)]
        public void IsPalidrome_Even_Number_Of_Digits_False(int number)
        {
            Assert.IsFalse(MathHelper.IsPalidrome(number));
        }

        [TestCase(90409)]
        public void IsPalidrome_Odd_Number_Of_Digits_True(int number)
        {
            Assert.IsTrue(MathHelper.IsPalidrome(number));
        }


        [Test]
        public void IsPrime()
        {
            Assert.IsTrue(MathHelper.IsPrime(7));
        }
    }
}