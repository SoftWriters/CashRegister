using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegister
{
    public class MinimumChangeCalculator : IChangeCalculator
    {
        public IList<(Currency, int)> GetChange(int changeAmount)
        {
            List<(Currency Currency, int Quantity)> change = new List<(Currency Currency, int Quantity)>();

            foreach (var currency in Currency.List())
            {
                if (changeAmount >= currency.Value)
                {
                    int quantity = changeAmount / currency.Value;
                    change.Add((Currency: currency, Quantity: quantity));
                    changeAmount -= currency.Value * quantity;
                }
            }

            return change;
        }
    }
}
