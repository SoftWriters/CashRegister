using System.Collections.Generic;

namespace CashRegister
{
    public class LargestDenominationFirstChangeCalculationStrategy : IChangeCalculationStrategy
    {
        public IDictionary<ICurrencyDenomination, int> GetChange(PurchaseTransaction transaction, IEnumerable<ICurrencyDenomination> denominationsAvailable)
        {
            var changeCalculator = new LargestDenominationFirstChangeCalculator();
            return changeCalculator.GetChange(transaction.AmountReceived - transaction.AmountOwed, denominationsAvailable);
        }
    }
}
