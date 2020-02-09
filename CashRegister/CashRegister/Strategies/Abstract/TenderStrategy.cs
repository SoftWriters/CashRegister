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

            // METHOD 2 - Using LINQ.. both one line and 2.. 1 line code commented out due to complexity
            var money = currency.AllDenominations.Where(x => x.Count > 0);
            var sr = money.Aggregate(new StringBuilder(), (x, y) => x.Append(String.Format("{0} {1},", y.Count, y.Name)));
            //var sr = currency.AllDenominations.Where(x => x.Count > 0).Aggregate(new StringBuilder(), (x, y) => x.Append(String.Format("{0} {1},", y.Count, y.Name)));

            if (sr.Length == 0)
                return String.Format("{0}\n", "No Change Due.");  // not part of the requirements, yet exact change is a viable value.
            else
                return String.Format("{0}\n", sr.ToString().Trim(','));
        }

        public abstract ICurrency Calculate(ICurrency currency, decimal price, decimal tender);
    }
}