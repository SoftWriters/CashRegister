using System.Collections.Generic;

namespace CashRegister
{
    public class RandomizedChangeCalculationStrategy : IChangeCalculationStrategy
    {
        public IDictionary<ICurrencyDenomination, int> GetChange(PurchaseTransaction transaction, IEnumerable<ICurrencyDenomination> denominationsAvailable)
        {
            decimal amountChangeDue = transaction.AmountReceived - transaction.AmountOwed;
            var changeCalculator = GetCalculator(transaction.AmountOwed);
            return changeCalculator.GetChange(amountChangeDue, denominationsAvailable);
        }

        // GetCalculator Factory Method
        private static IChangeCalculator GetCalculator(decimal amountOwed)
        {
            IChangeCalculator changeCalculator;

            //NOTE: The specifications said if the amount is a multiple of 3 and gave $3.33 as an example of this, but 3.33 is not a multiple of 3, so
            // I made the assumption that I should check if the amount owed in cents is a multiple of 3.
            if (amountOwed == 0 || (amountOwed * 100) % 3 != 0)
            {
                changeCalculator = new LargestDenominationFirstChangeCalculator();
            }
            else
            {
                changeCalculator = new RandomizedChangeCalculator();
            }

            return changeCalculator;
        }
    }
}
