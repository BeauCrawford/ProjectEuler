using NUnit.Framework;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void IsPrime()
        {
            Assert.IsTrue(MathHelper.IsPrime(7));
        }
    }
}
