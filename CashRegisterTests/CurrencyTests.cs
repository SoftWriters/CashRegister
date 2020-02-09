using CashRegisterConsumer;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.IO;


namespace CurrencyTests
{
    public class CurrencyTests
    {
        #region Setup
        public CurrencyTests()
        {

        }
        #endregion
        [Fact]
        public void CurrencyClearClearsMoneyCountForBills()
        {
            Currency currency = new CurrencyTestSortReverseCurrency();

            //now that we know we have a count in each of our bills... we will clear the currency and test.
            currency.Clear();

            foreach (Money bill in currency.Bills)
            {
                Assert.True(bill.Count == 0);
            }

        }
        [Fact]
        public void CurrencyClearClearsMoneyCountForCoins()
        {
            Currency currency = new CurrencyTestSortReverseCurrency();

            //now that we know we have a count in each of our coins... we will clear the currency and test.
            currency.Clear();

            foreach (Money coin in currency.Bills)
            {
                Assert.True(coin.Count == 0);
            }

        }
        [Fact]
        public void CurrencyAllDenominationsReturnsConcatForBillsAndCoins()
        {

            // this also effectively tests the "sort/reverse" functionality of the InitializeCurrency method 
            //  so creating a new method for that would be redundent (not necessarily bad though)
            Currency currency = new CurrencyTestPluralNameCurrencyNoMoney();

            for (int i = 0; i < currency.Bills.Count-1; i++)
            {
                Assert.Equal(currency.Bills[i], currency.AllDenominations[i]);
            }

            for (int i = 0; i < currency.Coins.Count-1; i++)
            {
                Assert.Equal(currency.Coins[i], currency.AllDenominations[i + currency.Bills.Count]); // coins should start after bills due to the sort/reverse (denomination based)
            }
        }
    }

    #region CurrecyTestClass
    public class CurrencyTestSortReverseCurrency : Currency
    {
        public CurrencyTestSortReverseCurrency():base() { }

        protected override void InitializeCurrency()
        {
            this._bills = new List<Money>() {
                new Bill(5, "five", "fives"),
                new Bill(100000, "one hundred thousand", "one hundred thousands"),
                new Bill(50, "fifty", "fifties"),
                new Bill(1000, "thousand", "thousands"),
                new Bill(500, "five hundred", "five hundreds"),
                new Bill(5000, "five thousand", "five thousands"),
                new Bill(100, "hundred", "hundreds"),
                new Bill(20, "twenty", "twenties"),
                new Bill(10000, "ten thousand", "ten thousands"),
                new Bill(10, "ten", "tens"),
                new Bill(1, "dollar", "dollars")
            };

            this._coins = new List<Money>() {
                new Coin(.05m, "nickel", "nickels"),
                new Coin(.01m, "penny","pennies"),
                new Coin(.25m, "quarter", "quarters"),
                new Coin(.10m, "dime", "dimes")
            };
        }
    }
    public class CurrencyTestSingularNameCurrency : Currency
    {
        protected override void InitializeCurrency()
        {
            this._bills = new List<Money>() {
                new Bill(100000, "one hundred thousand", "one hundred thousands", 1),
                new Bill(10000, "ten thousand", "ten thousands", 1),
                new Bill(5000, "five thousand", "five thousands", 1),
                new Bill(1000, "thousand", "thousands", 1),
                new Bill(500, "five hundred", "five hundreds", 1),
                new Bill(100, "hundred", "hundreds", 1),
                new Bill(50, "fifty", "fifties", 1),
                new Bill(20, "twenty", "twenties", 1),
                new Bill(10, "ten", "tens", 1),
                new Bill(5, "five", "fives", 1),
                new Bill(1, "dollar", "dollars", 1)
            };

            this._coins = new List<Money>() {
                new Coin(.25m, "quarter", "quarters", 1),
                new Coin(.10m, "dime", "dimes", 1),
                new Coin(.05m, "nickel", "nickels", 1),
                new Coin(.01m, "penny","pennies", 1)
            };
        }
    }
    public class CurrencyTestPluralNameCurrency : Currency
    {
        protected override void InitializeCurrency()
        {
            this._bills = new List<Money>() {
                new Bill(100000, "one hundred thousand", "one hundred thousands", 50),
                new Bill(10000, "ten thousand", "ten thousands", 2),
                new Bill(5000, "five thousand", "five thousands", 2),
                new Bill(1000, "thousand", "thousands", 4),
                new Bill(500, "five hundred", "five hundreds", 2),
                new Bill(100, "hundred", "hundreds", 600),
                new Bill(50, "fifty", "fifties", 56),
                new Bill(20, "twenty", "twenties", 2),
                new Bill(10, "ten", "tens", 4),
                new Bill(5, "five", "fives", 3),
                new Bill(1, "dollar", "dollars", 1245)
            };

            this._coins = new List<Money>() {
                new Coin(.25m, "quarter", "quarters", 500),
                new Coin(.10m, "dime", "dimes", 5),
                new Coin(.05m, "nickel", "nickels", 40),
                new Coin(.01m, "penny","pennies", 100)
            };
        }
    }
    public class CurrencyTestPluralNameCurrencyNoMoney : Currency
    {
        protected override void InitializeCurrency()
        {
            this._bills = new List<Money>() {
                new Bill(100000, "one hundred thousand", "one hundred thousands"),
                new Bill(10000, "ten thousand", "ten thousands"),
                new Bill(5000, "five thousand", "five thousands"),
                new Bill(1000, "thousand", "thousands"),
                new Bill(500, "five hundred", "five hundreds"),
                new Bill(100, "hundred", "hundreds"),
                new Bill(50, "fifty", "fifties"),
                new Bill(20, "twenty", "twenties"),
                new Bill(10, "ten", "tens"),
                new Bill(5, "five", "fives"),
                new Bill(1, "dollar", "dollars")
            };

            this._coins = new List<Money>() {
                new Coin(.25m, "quarter", "quarters"),
                new Coin(.10m, "dime", "dimes"),
                new Coin(.05m, "nickel", "nickels"),
                new Coin(.01m, "penny","pennies")
            };
        }
    }
    #endregion
}
