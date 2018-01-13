using System.Collections.Generic;

namespace CashRegister
{
    public interface IChangeCalculator
    {
        IDictionary<ICurrencyDenomination, int> GetChange(decimal amountChangeDue, IEnumerable<ICurrencyDenomination> denominationsAvailable);
    }
}
