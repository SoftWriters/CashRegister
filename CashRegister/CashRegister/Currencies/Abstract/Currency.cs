using System.Collections.Generic;

namespace CashRegisterConsumer
{
    public abstract class Currency : ICurrency
    {
        protected List<Money> _bills;
        protected List<Money> _coins;


        public List<Money> Bills
        {
            get { return _bills; }
        }

        public List<Money> Coins
        {
            get { return _coins; }
        }

        public decimal TotalValue()
        {
            //todo Calculate Total Value for both bills and coins
            //todo  return the decimal value.
            throw new System.NotImplementedException();
        }

        public void AddMoney(decimal value)
        {
            //todo Using the "Bills" and "Coins", we can
            //todo  we can add the proper amount of bills and coins from
            //todo  the decimal equivilent
            throw new System.NotImplementedException();
        }
        public void AddMoney(Money money)
        {
            //todo Using the "Bills" and "Coins", we can
            //todo  we can add the proper amount of bills and coins from
            //todo  the Money equivilent
            throw new System.NotImplementedException();
        }

        //? Possible future enhancement
        //public decimal CreditLine { get; } 
    }
}
