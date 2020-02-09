using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegisterConsumer
{
    public class Random3Strategy : TenderStrategy
    {
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            if (currency.AllDenominations.Count == 0)
                throw new InvalidCurrencyException("No currency denominations found");

            if (Math.Abs(((price * 100) % 10)) == 3)
            {
                Random random = new Random();
                int count;
                decimal change = tender - price;

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
                // when not using the "random", we can just use the standard strategy
                return new StandardTenderStrategy().Calculate(currency, price, tender);
            }
        }

        //public override string Calculate(ICurrency currency, decimal price, decimal tender)
        //{
        //    if (currency.AllDenominations.Count == 0)
        //        throw new InvalidCurrencyException("No currency denominations found");

        //    if (Math.Abs(((price * 100) % 10)) == 3)
        //    {
        //        Random random = new Random();
        //        int count;
        //        decimal change = tender - price;

        //        while (change >= currency.AllDenominations.Min(x => x.Denomination))
        //        {
        //            foreach (Money money in currency.AllDenominations)
        //            {
        //                if (money.Denomination <= change) // if the current denomination is less than the change
        //                {
        //                    count = random.Next(1, (int)Math.Floor(change / money.Denomination)); // get a random count (not bigger than the change)
        //                    money.Add(count); // add the appropriate amount of this denomination based on our random
        //                    change -= (money.Denomination * count); // remove the money denomination(times count) from the change
        //                }
        //            }
        //        }
        //        return currency.ToString();
        //    }
        //    else
        //    {
        //        // when not using the "random", we can just use the standard strategy
        //        return new StandardTenderStrategy().Calculate(currency, price, tender);
        //    }
        //}

    }
}