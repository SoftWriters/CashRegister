using System;
using System.Linq;

namespace CashRegisterConsumer
{
    public class Random3Strategy : TenderStrategy
    {
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            if (currency.AllDenominations.Count == 0)
                throw new InvalidCurrencyException("No currency denominations found");

            if (Math.Abs(((price * 100) % 3)) == 0) // updated to correct algorithm
            {
                Random random = new Random();
                int count;
                decimal change = tender - price;

                // the currency.AllDenominations.Min(x => x.Denomination) is to ensure that if there is a currency that
                // has a minimum value that is less then that change, the extra will be "dropped" and no infinite loop will occur.
                // This itself has the problem that in a large system, these "dropped" percentages could be significant.  This would
                // be addressed with the business and the development team to determine the best course of action.
                while (change >= currency.AllDenominations.Min(x => x.Denomination))
                {
                    foreach (Money money in currency.AllDenominations)
                    {
                        if (money.Denomination <= change) // if the current denomination is less than the change
                        {
                            count = random.Next(1, (int)Math.Floor(change / money.Denomination)); // get a random count (not bigger than the change)
                            money.Add(count); // add the appropriate amount of this denomination based on our random
                            change -= (money.Denomination * count); // remove the money denomination(times count) from the change
                        }
                    }
                }
                return currency;
            }
            else
            {
                return base.Calculate(currency, price, tender);
            }
        }
    }
}