using System;
using System.Collections.Generic;

namespace CashMachine.Domain
{
    public interface ICurrencyRandomizer
    {
        IList<ICurrency> Shuffle(IList<ICurrency> list);
    }

    public class CurrencyRandomizer : ICurrencyRandomizer
    {
        public IList<ICurrency> Shuffle(IList<ICurrency> currencyList )
        {
            int n = currencyList.Count;

            // Reorder using Yates. It's as good as anything for this application
            // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            //
            while (n > 1)
            {
                n--;
                int k = RandomNumber.Next(n + 1);
                ICurrency value = currencyList[k];
                currencyList[k] = currencyList[n];
                currencyList[n] = value;
            }
            return currencyList;
        }

        private static readonly Random RandomNumber = new Random();
    }
}
