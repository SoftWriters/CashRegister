using System.Linq;

namespace CashRegisterConsumer
{
    public class StandardTenderStrategy : TenderStrategy
    {
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            if (currency.AllDenominations.Count == 0)
                throw new InvalidCurrencyException("No currency denominations found");

            decimal change = tender - price;

            // the currency.AllDenominations.Min(x => x.Denomination) is to ensure that if there is a currency that
            // has a minimum value that is less then that change, the extra will be "dropped" and no infinite loop will occur.
            // This itself has the problem that in a large system, these "dropped" percentages could be significant.  This would
            // be addressed with the business and the development team to determine the best course of action.
            while (change >= currency.AllDenominations.Min(x => x.Denomination))
            {
                foreach (Money money in currency.AllDenominations)
                {
                    while (change >= money.Denomination)
                    {
                        money.Add(1);
                        change -= money.Denomination;
                    }
                }
            }
            return currency;
        }
    }
}