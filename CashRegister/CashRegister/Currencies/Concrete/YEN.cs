using System.Collections.Generic;

namespace CashRegisterConsumer
{
    class YEN : Currency
    {
        public YEN() : base() { }
        protected override void InitializeCurrency()
        {
            this._bills = new List<Money>() {
                new Bill(10000, "10000-yen note", "10000-yen notes"),
                new Bill(5000, "5000-yen note", "5000-yen notes"),
                new Bill(2000, "2000-yen note", "2000-yen notes"),
                new Bill(1000, "1000-yen note", "1000-yen notes")
            };

            this._coins = new List<Money>() {
                new Coin(500, "500-yen coin", "500-yen coins"),
                new Coin(100, "100-yen coin", "100-yen coins"),
                new Coin(50, "50-yen coin", "50-yen coins"),
                new Coin(10, "10-yen coin", "10-yen coins"),
                new Coin(5, "5-yen coin", "5-yen coins"),
                new Coin(1, "1-yen coin","1-yen coins")
            };
        }
    }
}
