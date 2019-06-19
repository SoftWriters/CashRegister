// Chooses a currency based on the given string, and invokes methods in the Currency Object.
using System.Collections.Generic;
namespace CCDS.res.currency.@base
{
    public abstract class CurrencyChooser
    {
        protected abstract List<Currency> GetCurrencyList(string currency);
        public List<Currency> Choose(string typeOfCurrency)
        {
            var chosenCurrency = GetCurrencyList(typeOfCurrency);
            return chosenCurrency;
        }
    }
}