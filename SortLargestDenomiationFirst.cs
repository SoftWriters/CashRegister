using System.Collections.Generic;

namespace CashRegister
{
    public class SortLargestDenomiationFirst : IComparer<ICurrencyDenomination>
    {
        int IComparer<ICurrencyDenomination>.Compare(ICurrencyDenomination currencyDenomination1, ICurrencyDenomination currencyDenomination2)
        {
            if (currencyDenomination1.ValueInLowestDenomination > currencyDenomination2.ValueInLowestDenomination)
                return -1;

            if (currencyDenomination1.ValueInLowestDenomination < currencyDenomination2.ValueInLowestDenomination)
                return 1;

            // Values are equal
            return 0;
        }
    }
}
