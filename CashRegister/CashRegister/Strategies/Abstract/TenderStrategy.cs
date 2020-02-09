using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class TenderStrategy : ITenderStrategy
    {
        //public abstract string Calculate(ICurrency currency, decimal price, decimal tender);

        public virtual string Display(ICurrency currency)
        {
            StringBuilder sr = new StringBuilder();
            foreach (Money money in currency.AllDenominations)
            {
                if (money.Count > 0)
                {
                    sr.Append(String.Format("{0} {1},", money.Count, money.Name));
                }
            }

            if (sr.Length == 0)
                return String.Format("{0}\n", "No Change Due.");  // not part of the requirements, yet exact change is a viable value.
            else
                return String.Format("{0}\n", sr.ToString().Trim(','));
        }

        public abstract ICurrency Calculate(ICurrency currency, decimal price, decimal tender);

    }
}
