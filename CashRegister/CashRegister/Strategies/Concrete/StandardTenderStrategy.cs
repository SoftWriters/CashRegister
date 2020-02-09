using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegisterConsumer
{
    public class StandardTenderStrategy : TenderStrategy
    {
        //public override string Calculate(ICurrency currency, decimal price, decimal tender)
        //{
        //    if (currency.AllDenominations.Count == 0)
        //        throw new InvalidCurrencyException("No currency denominations found");

        //    decimal change = tender - price;
        //    // this is to ensure that coinage less than the smallest denomination will not cause an infinite loop.
        //    // the extra "change" is ignored.. this can occur because some currencies do not have decimal value denominations (YEN)
        //    while (change >= currency.AllDenominations.Min(x => x.Denomination))
        //    {
        //        foreach (Money money in currency.AllDenominations)
        //        {
        //            while (change >= money.Denomination)
        //            {
        //                money.Add(1);
        //                change -= money.Denomination;
        //            }
        //        }
        //    }
        //    return currency.ToString();
        //}
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            if (currency.AllDenominations.Count == 0)
                throw new InvalidCurrencyException("No currency denominations found");

            decimal change = tender - price;
            // this is to ensure that coinage less than the smallest denomination will not cause an infinite loop.
            // the extra "change" is ignored.. this can occur because some currencies do not have decimal value denominations (YEN)
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
