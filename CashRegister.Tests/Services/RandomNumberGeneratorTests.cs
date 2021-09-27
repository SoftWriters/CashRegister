using CashRegister.Services;
using NUnit.Framework;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class RandomNumberGeneratorTests
    {
        public RandomNumberGenerator uut;

        public RandomNumberGeneratorTests()
        {
            uut = new RandomNumberGenerator();
        }

        [Test]
        public void RandomNumberGenerator_Should_ReturnAnInteger()
        {
            var result = uut.GenerateRandomInt(0, 10);

            Assert.IsInstanceOf<int>(result);
        }
    }
}