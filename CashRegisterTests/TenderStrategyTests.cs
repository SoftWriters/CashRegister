using CashRegisterConsumer;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TenderStrategyTests
{
    public class TenderStrategyTests
    {
        #region Setup

        private readonly Mock<ICurrency> currencyMock;

        public TenderStrategyTests()
        {
            currencyMock = new Mock<ICurrency>();
        }

        #endregion Setup

        [Fact]
        public void TenderStrategyDisplayReturnsProperlyFormattedStringValueForSingularCount()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "dollar", "dollars", 1) });
            string expected = "1 dollar\n";

            TenderStrategy tenderStrategy = new TenderStrategyTestMock();
            var actual = tenderStrategy.Display(currencyMock.Object);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TenderStrategyDisplayReturnsProperlyFormattedStringValueForMultipleCount()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "dollar", "dollars", 2) });
            string expected = "2 dollars\n";

            TenderStrategy tenderStrategy = new TenderStrategyTestMock();
            var actual = tenderStrategy.Display(currencyMock.Object);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TenderStrategyDisplayReturnsProperlyFormattedStringValueForZeroCount()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1, "dollar", "dollars", 0) });
            string expected = "No Change Due\n";

            TenderStrategy tenderStrategy = new TenderStrategyTestMock();
            var actual = tenderStrategy.Display(currencyMock.Object);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TenderStrategyDisplayReturnsProperStringValueForMultipleDenominations()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() {
                                                                                    new Bill(5, "five dollar", "five dollars", 10),
                                                                                    new Bill(1, "dollar", "dollars", 1),
                                                                                    new Coin(.01m, "dime", "dimes",3),
                                                                                    new Coin(.01m,"penny","pennies",1)
                                                                                    });
            string expected = "10 five dollars,1 dollar,3 dimes,1 penny\n";

            TenderStrategy tenderStrategy = new TenderStrategyTestMock();
            var actual = tenderStrategy.Display(currencyMock.Object);

            Assert.Equal(expected, actual);
        }
    }

    #region MockTenderStrategy Abstract

    internal class TenderStrategyTestMock : TenderStrategy
    {
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            throw new NotImplementedException();
        }
    }

    #endregion MockTenderStrategy Abstract
}