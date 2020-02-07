using System;

namespace CashRegisterConsumer
{
    internal class Random3ChangeCalculator : ChangeCalculator
    {
        public override string Calculate(ICurrency _price, ICurrency _tender)
        {
            if (Math.Abs(((_tender.TotalValue() * 100) % 10)) == 3)
            {
                //todo Create "random" strategy
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}