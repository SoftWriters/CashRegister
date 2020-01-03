using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegister
{
    public class RandomChangeCalculator : IChangeCalculator
    {
        public IList<(Currency, int)> GetChange(int changeAmount)
        {
            List<(Currency Currency, int Quantity)> change = new List<(Currency Currency, int Quantity)>();
            Random random = new Random();

            while (changeAmount > 0)
            {
                List<Currency> availableCurrencies = Currency.List().Where(x => x.Value <= changeAmount).ToList();
                int index = random.Next(0, availableCurrencies.Count());
                Currency currency = availableCurrencies[index];
                change.Add((Currency: currency, Quantity: 1));
                changeAmount -= currency.Value;
            }

            return change;
        }
    }
}
