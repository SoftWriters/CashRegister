using System.Collections.Generic;
using System.Linq;

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
            // initialize lists
            this._bills = new List<Money>();
            this._coins = new List<Money>();

            InitializeCurrency(); // load currency "money" based on inherited implementation
            this._bills.Sort(); // ensure that we have the correct order of money
            this._bills.Reverse(); // since the sort will make it small to large, we want large to small so foreach works easier.
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