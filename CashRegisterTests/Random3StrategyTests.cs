using CashRegisterConsumer;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TenderStrategyTests
{
    public class Random3StrategyTests
    {
        #region Setup

        private readonly Mock<ICurrency> mockCurrency;

        public Random3StrategyTests()
        {
            mockCurrency = new Mock<ICurrency>();
        }

        #endregion Setup

        [Fact]
        public void Random3TenderStrategyCalculatesChangeCorrectlyBasedOnPriceAndTenderDifference()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>()
                                                                    { new Bill(10, "ten", "tens"),
                                                                      new Bill(5, "five", "fives"),
                                                                      new Bill(1, "dollar", "dollars"),
                                                                      new Coin(.10m,"dime","dimes"),
                                                                      new Coin(.05m,"nickel","nickels"),
                                                                      new Coin(.01m,"penny","pennies")
                                                                    });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            decimal expected = 3001.50m;
            decimal actual = 0.0m;
            var result = tenderStrategy.Calculate(mockCurrency.Object, 123.03m, 3124.53m); // 3001.50 in change
            foreach (Money money in mockCurrency.Object.AllDenominations)
            {
                actual += (money.Count * money.Denomination);
            }
            Assert.Equal(expected, actual);

            foreach (Money money in mockCurrency.Object.AllDenominations)
            {
                money.Clear();
            }
            expected = 0.0m;
            actual = 0.0m;

            result = tenderStrategy.Calculate(mockCurrency.Object, 1.03m, 1.03m); // 0 in change
            foreach (Money money in mockCurrency.Object.AllDenominations)
            {
                actual += (money.Count * money.Denomination);
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Random3CalculatesExactTenderCorrectly()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>()
                                                                    { new Bill(10, "ten", "tens"),
                                                                      new Bill(5, "five", "fives"),
                                                                      new Bill(1, "dollar", "dollars"),
                                                                      new Coin(.10m,"dime","dimes"),
                                                                      new Coin(.05m,"nickel","nickels"),
                                                                      new Coin(.01m,"penny","pennies")
                                                                    });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            decimal expected = 0.0m;
            decimal actual = 0.0m;
            var result = tenderStrategy.Calculate(mockCurrency.Object, 1.03m, 1.03m); // 0 in change
            foreach (Money money in mockCurrency.Object.AllDenominations)
            {
                actual += (money.Count * money.Denomination);
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Random3CalculatesZeroTenderWhenTenderIsLessThanPrice()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>()
                                                                    { new Bill(10, "ten", "tens"),
                                                                      new Bill(5, "five", "fives"),
                                                                      new Bill(1, "dollar", "dollars"),
                                                                      new Coin(.10m,"dime","dimes"),
                                                                      new Coin(.05m,"nickel","nickels"),
                                                                      new Coin(.01m,"penny","pennies")
                                                                    });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            decimal expected = 0.0m;
            decimal actual = 0.0m;
            var result = tenderStrategy.Calculate(mockCurrency.Object, 10.03m, 1.03m); // 0 in change
            foreach (Money money in result.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                actual += (money.Count * money.Denomination);
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnNonDecimalDenominationsAndRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "dollar", "dollars") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1.33m, 3.33m);

            // test that our "1 dollar bill" is added 2 times during the process for standard strategy for change
            // (meaning that the price is recuded each time accordingly)
            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(2, money.Count); // price - tender = 2 dollars in change
            }
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnDecimalDenominationsAndRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(.01m, "penny", "pennies") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1.33m, 1.43m);

            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(10, money.Count); // price - tender = 10 pennies in change
            }
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnOddDecimalDenominationsAndRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(.25m, "quarter", "quarters") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1.33m, 2.33m);

            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(4, money.Count); // price - tender = 4 quarters in change
            }
        }

        [Fact]
        public void Random3TenderStrategyReturnsCurrentyWithNoMoneyValuesAndNonRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "test", "tests") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 0, 0);

            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(0, money.Count);   // due to the "ToString" override being used, we have to test the counts.
            }                                   // Consider refactoring ToString. Hard testing indicates a design flaw.
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnNonDecimalDenominationsAndNonRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "dollar", "dollars") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1, 3);

            // test that our "1 dollar bill" is added 2 times during the process for standard strategy for change
            // (meaning that the price is recuded each time accordingly)
            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(2, money.Count); // price - tender = 2 dollars in change
            }
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnDecimalDenominationsAndNonRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(.01m, "penny", "pennies") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1, 1.10m);

            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(10, money.Count); // price - tender = 10 pennies in change
            }
        }

        [Fact]
        public void Random3TenderStrategySubtractsCorrectlyFromThePriceBasedOnOddDecimalDenominationsAndNonRandomReturn()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(.25m, "quarter", "quarters") });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            var actual = tenderStrategy.Calculate(mockCurrency.Object, 1, 2.00m);

            foreach (Money money in actual.AllDenominations) // mockCurrency.Object.AllDenominations)
            {
                Assert.Equal(4, money.Count); // price - tender = 4 quarters in change
            }
        }

        #region Exception Testing

        [Fact]
        public void Random3TenderStrategyCalculateThrowsInvalidCurrencyExceptionWhenNoDenominationsFound()
        {
            mockCurrency.Setup(p => p.AllDenominations).Returns(new List<Money>() { });
            ITenderStrategy tenderStrategy = new Random3Strategy();
            Assert.Throws<InvalidCurrencyException>(() => tenderStrategy.Calculate(mockCurrency.Object, 0, 0));
        }

        #endregion Exception Testing
    }
}