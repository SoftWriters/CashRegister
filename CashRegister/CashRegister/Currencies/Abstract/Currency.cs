using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class Currency : ICurrency
    {
        protected List<Money> _bills;
        protected List<Money> _coins;

        public List<Money> Bills { get { return _bills; } }
        public List<Money> Coins { get { return _coins; } }
        public List<Money> AllDenominations { get { return _bills.Concat(_coins).ToList(); } }

        public Currency()
        {
            this._bills = new List<Money>();
            this._coins = new List<Money>();

            InitializeCurrency();
            this._bills.Sort();
            this._bills.Reverse();
            this._coins.Sort();
            this._coins.Reverse();
        }

        protected abstract void InitializeCurrency();

        public void Clear()
        {
            foreach (Money money in AllDenominations)
            {
                money.Clear();
            }
        }
    }
}
