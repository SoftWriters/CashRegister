using System.Collections.Generic;

namespace CashRegisterConsumer
{
    internal class USD : Currency
    {
        public USD() : base() { }

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
}
