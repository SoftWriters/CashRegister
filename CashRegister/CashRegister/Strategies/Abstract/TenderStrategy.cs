using System;
using System.Linq;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class TenderStrategy : ITenderStrategy
    {
        public virtual string Display(ICurrency currency)
        {
            // METHOD 1 - with foreach loop (did not remove code so reviewers could evaluate both methods)
            //StringBuilder sr = new StringBuilder();
            //foreach (Money money in currency.AllDenominations)
            //{
            //    if (money.Count > 0)
            //    {
            //        sr.Append(String.Format("{0} {1},", money.Count, money.Name));
            //    }
            //}

            // METHOD 2 - Using LINQ.. both one line and 2 line versions. 1 line version commented out due to complexity and clarity
            var money = currency.AllDenominations.Where(x => x.Count > 0);
            var sr = money.Aggregate(new StringBuilder(), (x, y) => x.Append(String.Format("{0} {1},", y.Count, y.Name)));
            //var sr = currency.AllDenominations.Where(x => x.Count > 0).Aggregate(new StringBuilder(), (x, y) => x.Append(String.Format("{0} {1},", y.Count, y.Name)));

            if (sr.Length == 0)
                return String.Format("{0}\n", "No Change Due");  // not part of the requirements, yet exact change is a viable value.
            else
                return String.Format("{0}\n", sr.ToString().Trim(','));
        }

        public virtual ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
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