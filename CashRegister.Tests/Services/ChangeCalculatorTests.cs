using Moq;
using CashRegister.Exceptions;
using CashRegister.Services;
using NUnit.Framework;
using CashRegister.Services.Interfaces;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class ChangeCalculatorTests
    {
        private Mock<IChangeStringBuilder> mockChangeBuilder;
        protected ChangeCalculator uut;

        public ChangeCalculatorTests()
        {
            mockChangeBuilder = new Mock<IChangeStringBuilder>();
            uut = new ChangeCalculator(mockChangeBuilder.Object);
        }

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

        [Test]
        public void DetermineChange_Should_ReturnAString()
        {
            var costDue = 3;

            mockChangeBuilder.Setup(cb => cb.BuildChangeString(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns("");

            var results = uut.DetermineChange(costDue);
            Assert.IsInstanceOf<string>(results);
        }

        [Test]
        public void DetermineChange_Should_CallChangeBuilderWithExpectedArguments()
        {
            var costDue = 2.67m;
            var expectedDollars = 2;
            var expectedQuarters = 2;
            var expectedDimes = 1;
            var expectedNickels = 1;
            var expectedPennies = 2;

            var results = uut.DetermineChange(costDue);

            mockChangeBuilder.Verify(cb => cb.BuildChangeString(expectedDollars, expectedQuarters, expectedDimes, expectedNickels, expectedPennies), Times.Once);
        }

        [Test]
        public void DetermineChange_Should_ReturnTheExpectedResult()
        {
            var costDue = 2.67m;
            var expectedDollars = 2;
            var expectedQuarters = 2;
            var expectedDimes = 1;
            var expectedNickels = 1;
            var expectedPennies = 2;

            var expectedResults = "2 dollars, 2 quarters, 1 dime, 1 nickel, 2 pennies";

            mockChangeBuilder.Setup(cb => cb.BuildChangeString(expectedDollars, expectedQuarters, expectedDimes, expectedNickels, expectedPennies))
                .Returns(expectedResults);

            var results = uut.DetermineChange(costDue);
            Assert.AreEqual(expectedResults, results);
        }
    }
}