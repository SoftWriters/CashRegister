using CashRegisterConsumer;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace CashRegisterTests
{
    public class CashRegisterTests
    {
#region SETUP
        private readonly Mock<ICurrency> currencyMock;
        private readonly Mock<ITenderStrategy> tenderStrategyMock;


        private readonly string TenderValueTestFile = @"C:\Users\plwes\source\repos\CashRegister\CashRegisterTests\Test Input Files\ValueTests\TenderValueTestFile.txt";
        private readonly string PriceValueTestFile = @"C:\Users\plwes\source\repos\CashRegister\CashRegisterTests\Test Input Files\ValueTests\PriceValueTestFile.txt";
        private readonly string EmptyFile = @"C:\Users\plwes\source\repos\CashRegister\CashRegisterTests\Test Input Files\EmptyFile.txt";
        private readonly string EmptyLineFile = @"C:\Users\plwes\source\repos\CashRegister\CashRegisterTests\Test Input Files\EmptyLineFile.txt";
        private readonly string NotEnoughTenderFile = @"C:\Users\plwes\source\repos\CashRegister\CashRegisterTests\Test Input Files\TenderLessThanPrice.txt";
        public CashRegisterTests()
        {
            currencyMock = new Mock<ICurrency>();
            tenderStrategyMock = new Mock<ITenderStrategy>();
        }
        private void SetupUSDMockCurrency()
        {
            currencyMock.Setup(p => p.Bills).Returns(new List<Money>() {
                new Bill(100000, "one hundred thousand", "one hundred thousands"),
                new Bill(10000, "ten thousand", "ten thousands"),
                new Bill(5000, "five thousand", "five thousands"),
                new Bill(1000, "thousand", "thousands"),
                new Bill(500, "five hundred", "five hundreds"),
                new Bill(100, "hundred", "hundreds"),
                new Bill(50, "fifty", "fifties"),
                new Bill(20, "twenty", "twenties"),
                new Bill(5, "five", "fives"),
                new Bill(1, "dollar", "dollars")
            });
            currencyMock.Setup(p => p.Coins).Returns(new List<Money>() {
                new Coin(.25m, "quarter", "quarters"),
                new Coin(.10m, "dime", "dimes"),
                new Coin(.05m, "nickel", "nickels"),
                new Coin(.01m, "penny","pennies")
            });
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>(){new Bill(100000, "one hundred thousand", "one hundred thousands"),
                new Bill(10000, "ten thousand", "ten thousands"),
                new Bill(5000, "five thousand", "five thousands"),
                new Bill(1000, "thousand", "thousands"),
                new Bill(500, "five hundred", "five hundreds"),
                new Bill(100, "hundred", "hundreds"),
                new Bill(50, "fifty", "fifties"),
                new Bill(20, "twenty", "twenties"),
                new Bill(5, "five", "fives"),
                new Bill(1, "dollar", "dollars"),
                new Coin(.25m, "quarter", "quarters"),
                new Coin(.10m, "dime", "dimes"),
                new Coin(.05m, "nickel", "nickels"),
                new Coin(.01m, "penny","pennies")
            });
        }
        #endregion

        [Fact]
        public void CashRegisterPriceValueIsAccuratelySetBasedOnTextFileInput()
        {
            // setup
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Coin(.25m, "testCoin", "testCoins") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);

            // setup excpeted
            decimal expected = 2.45m;
            // execute to a point where the actual can be tested
            var results = register.Tender(PriceValueTestFile);
            // are they equal????
            Assert.Equal(expected, register.PriceValue);
        }
        [Fact]
        public void CashRegisterTenderValueIsAccuratelySetBasedOnTextFileInput()
        {
            // setup
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Coin(.25m, "testCoin", "testCoins") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);

            // setup excpeted
            decimal expected = 110.98m;
            // execute to a point where the actual can be tested
            var results = register.Tender(TenderValueTestFile);
            // are they equal????
            Assert.Equal(expected, register.TenderValue);
        }

        #region Exception Tests
        [Fact]
        public void CashRegisterThrowsFileNotFoundExceptionGivenEmptyOrNullPath()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1m, "testMoney", "testMonies") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);
            Assert.Throws<FileNotFoundException>(() => register.Tender(""));
        }
        [Fact]
        public void CashRegisterThrowsFileNotFoundExceptionGivenNullPath()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1m, "testMoney", "testMonies") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);
            Assert.Throws<FileNotFoundException>(() => register.Tender(null));
        }
        [Fact]
        public void CashRegisterThrowsFormatExceptionWhenEmptyFileIsProvided() 
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1m, "testMoney", "testMonies") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);
            Assert.Throws<FormatException>(() => register.Tender(EmptyFile));
        }
        [Fact]
        public void CashRegisterThrowsFormatExceptionWhenEmptyLineFoundInFileProvided()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1m, "testMoney", "testMonies") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);
            Assert.Throws<FormatException>(() => register.Tender(EmptyLineFile));
        }
        [Fact]
        public void CashRegisterThrowsNotEnoughTenderExceptionWhenTenderIsLessThanPrice()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>() { new Bill(1m, "testMoney", "testMonies") });
            CashRegister register = new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object);
            Assert.Throws<NotEnoughTenderException>(() => register.Tender(NotEnoughTenderFile));
        }
        [Fact]
        public void CashRegisterThrowsInvalidCurrencyExceptionWhenNoDenominationsFound()
        {
            currencyMock.Setup(p => p.AllDenominations).Returns(new List<Money>());
            Assert.Throws<InvalidCurrencyException>(() => new POSCashRegister(currencyMock.Object, tenderStrategyMock.Object));
        }
        [Fact]
        public void CashRegisterThrowsNullReferenceExceptionWhenAttemptingToRegisterNullCurrency()
        {
            Assert.Throws<NullReferenceException>(() => new POSCashRegister(null, tenderStrategyMock.Object));
        }
        [Fact]
        public void CashRegisterThrowsNullReferenceExceptionWhenAttemptingToRegisterNullTenderStrategy()
        {
            Assert.Throws<NullReferenceException>(() => new POSCashRegister(currencyMock.Object, null));
        }
        #endregion


    }
}
