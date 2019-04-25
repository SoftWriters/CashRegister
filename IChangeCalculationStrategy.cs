using System.Collections.Generic;

namespace CashRegister
{
    public interface IChangeCalculationStrategy
    {
        IDictionary<ICurrencyDenomination, int> GetChange(PurchaseTransaction transaction, IEnumerable<ICurrencyDenomination> denominationsAvailable);
    }
}
