using CashRegister.Exceptions;
using CashRegister.Services;
using NUnit.Framework;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class ChangeCalculatorTests
    {
        protected ChangeCalculator uut = new ChangeCalculator();

        [Test]
        public void CalculateChange_Should_ReturnAdecimal()
        {
            decimal paid = 5.00m;
            decimal cost = 1.66m;
            var result = uut.CalculateChange(paid, cost);
            Assert.IsInstanceOf<decimal>(result);
        }

        [Test]
        [TestCase(75.00, 63.12, 11.88)]
        [TestCase(5.00, 3.99, 1.01)]
        [TestCase(100.67, 88.12, 12.55)]
        public void CalculateChange_Should_ReturnExpectedResult(
            decimal paid,
            decimal cost,
            decimal expected
        )
        {
            var result = uut.CalculateChange(paid, cost);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateChange_ShouldThrow_IfCostIsANegativeValue()
        {
            var paid = -30;
            var cost = 12;
            var expectedExceptionMessage = "-30 is not able to be negative";

            var thrownException = Assert.Throws<IllegalNegativeException>(() => uut.CalculateChange(paid, cost));
            Assert.AreEqual(expectedExceptionMessage, thrownException.Message);
        }

        [Test]
        public void CalculateChange_ShouldThrow_IfPaidIsANegativeValue()
        {
            var paid = 30;
            var cost = -12;
            var expectedExceptionMessage = "-12 is not able to be negative";

            var thrownException = Assert.Throws<IllegalNegativeException>(() => uut.CalculateChange(paid, cost));
            Assert.AreEqual(expectedExceptionMessage, thrownException.Message);
        }


    }
}