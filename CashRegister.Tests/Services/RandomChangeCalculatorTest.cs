using CashRegister.Exceptions;
using CashRegister.Services;
using CashRegister.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class RandomChangeCalculatorTest
    {
        private Mock<IChangeStringBuilder> mockChangeStringBuilder;
        private Mock<IRandomNumberGenerator> mockRandomNumberGenerator;
        private RandomChangeCalculator uut;

        public RandomChangeCalculatorTest()
        {
            mockChangeStringBuilder = new Mock<IChangeStringBuilder>();
            mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            uut = new RandomChangeCalculator(mockChangeStringBuilder.Object, mockRandomNumberGenerator.Object);
        }

        [SetUp]
        public void BeforeEach()
        {
            mockRandomNumberGenerator.Setup(rng => rng.GenerateRandomInt(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            mockChangeStringBuilder.Setup(cb => cb.BuildChangeString(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns("");
        }

        [TearDown]
        public void AfterEach()
        {
            mockChangeStringBuilder.Reset();
            mockRandomNumberGenerator.Reset();
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

            var results = uut.DetermineChange(costDue);
            Assert.IsInstanceOf<string>(results);
        }

        [Test]
        public void DetermineChange_Should_CallRandomNumberGenerator5Times()
        {
            var changeDue = 1.66m;
            var expectedRngCallCount = 4;

            uut.DetermineChange(changeDue);
            mockRandomNumberGenerator.Verify(rng => rng.GenerateRandomInt(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(expectedRngCallCount));
        }

        [Test]
        public void DetermineChange_Should_CallChangeStringBuilderWithExpectedArguments()
        {
            var changeDue = 1.66m;
            var expectedDollars = 1;
            var expectedQuarter = 1;
            var expectedDimes = 1;
            var expectedNickes = 1;
            var expectedPennies = 26;

            uut.DetermineChange(changeDue);
            
            mockChangeStringBuilder.Verify(cb =>
            cb.BuildChangeString(
                expectedDollars,
                expectedQuarter,
                expectedDimes,
                expectedNickes,
                expectedPennies
            ), Times.Once);
        }

    }
}