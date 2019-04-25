using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public class RandomizedChangeCalculator : IChangeCalculator
    {
        public IDictionary<ICurrencyDenomination, int> GetChange(decimal amountChangeDue, IEnumerable<ICurrencyDenomination> denominationsAvailable)
        {
            // Create a SortedDictionary, so that even though we are randomly grabbing denominations to make change the output will
            // still be sorted by the largest denomination first.
            IComparer<ICurrencyDenomination> currencyComparer = new SortLargestDenomiationFirst();
            IDictionary<ICurrencyDenomination, int> change = new SortedDictionary<ICurrencyDenomination, int>(currencyComparer);

            // Create a list from the IEnumerable, so that we can use indexes to access the elements
            List<ICurrencyDenomination> denominationsAvailableList = denominationsAvailable.ToList();

            // Change amount due to the be in the lowest denomination available (i.e. cents)
            // Use the absolute value in case there is a refund due
            int amountDueInLowestDenomination = Math.Abs((int)(amountChangeDue * 100));
            Random random = new Random();

            while (amountDueInLowestDenomination > 0)
            {
                // Pick a denomination randomly
                int randomDenominationIndex = random.Next(0, denominationsAvailableList.Count - 1);
                ICurrencyDenomination denomination = denominationsAvailableList[randomDenominationIndex];

                if (amountDueInLowestDenomination >= denomination.ValueInLowestDenomination)
                {
                    // Add the denomination to the collection
                    if (change.ContainsKey(denomination))
                    {
                        change[denomination]++;
                    }
                    else
                    {
                        change.Add(denomination, 1);
                    }

                    // Remove the value of that denomination from the total change due
                    amountDueInLowestDenomination -= denomination.ValueInLowestDenomination;
                }
                else
                {
                    // Remove the denomination that is too large for the remaining amount from list of available denominations
                    denominationsAvailableList.RemoveAt(randomDenominationIndex);
                }
            }

            return change;
        }
    }
}
