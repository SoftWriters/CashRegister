using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public class LargestDenominationFirstChangeCalculator : IChangeCalculator
    {
        public IDictionary<ICurrencyDenomination, int> GetChange(decimal amountChangeDue, IEnumerable<ICurrencyDenomination> denominationsAvailable)
        {
            IDictionary<ICurrencyDenomination, int> change = new Dictionary<ICurrencyDenomination, int>();

            // Order the denominations available by the largest denomination first
            denominationsAvailable = denominationsAvailable.OrderByDescending(da => da.ValueInLowestDenomination);

            // Change amount due to the be in the lowest denomination available (i.e. cents)
            // Use the absolute value in case there is a refund due
            int amountDueInLowestDenomination = Math.Abs((int)(amountChangeDue * 100));

            foreach (ICurrencyDenomination denomination in denominationsAvailable)
            {
                int countOfDenominationDue = amountDueInLowestDenomination / denomination.ValueInLowestDenomination;

                if (countOfDenominationDue > 0)
                {
                    change.Add(denomination, countOfDenominationDue);
                }

                // Get the remaining amount after the current denomination has been processed
                amountDueInLowestDenomination = amountDueInLowestDenomination % denomination.ValueInLowestDenomination;
            }

            return change;
        }
    }
}
