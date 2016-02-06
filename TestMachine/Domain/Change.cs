using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Domain
{
    public class Change
    {
        public Change()
        {
            _currency = new Dictionary<ICurrency, int>();
        }

        public Change Add(ICurrency currencyType, int count = 1)
        {
            if (_currency.ContainsKey(currencyType)) count += _currency[currencyType];
            _currency[currencyType] = count;

            return this;
        }

        public override string ToString()
        {
            string display = String.Empty;

            var currencyList = new List<ICurrency>(_currency.Keys);
            
            foreach(var currency in currencyList.OrderByDescending(x => x.Value))
            {
                if (display != String.Empty) display += ",";
                display += currency.ToString( _currency[currency]);   
            }

            return display;
        }

        public decimal Value => CalcValue();

        private readonly Dictionary<ICurrency, int> _currency;

        private decimal CalcValue()
        {
            return _currency.Keys.Sum(currency => currency.Value*_currency[currency]);
        }

        public int NumberOf(ICurrency currency)
        {
            return _currency.ContainsKey(currency) ? _currency[currency] : 0;
        }
    }
}