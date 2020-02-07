using System.Collections.Generic;

namespace CashRegisterConsumer
{
    internal class USD : Currency
    {
        public USD():base()
        {
            this._bills = new List<Money>() { 
                new Bill(100000, "One Hundred Thousand"),
                new Bill(10000, "Ten Thousand"),
                new Bill(5000, "Five Thousand"),
                new Bill(1000, "Thousand"),
                new Bill(500, "Five Hundred"),
                new Bill(100, "Hundred"),
                new Bill(50, "Fifty"),
                new Bill(20, "Twenty"),
                new Bill(5, "Five"),
                new Bill(1, "Dollar")
            };

            this._coins = new List<Money>() { 
                new Coin(25, "Quarter"), 
                new Coin(10, "Dime"),
                new Coin(5, "Nickel"),
                new Coin(1, "Penny")
            }; ;
        }
    }
}
