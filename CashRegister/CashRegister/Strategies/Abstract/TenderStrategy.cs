using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class TenderStrategy : ITenderStrategy
    {
        public abstract string Calculate(ICurrency currency, decimal price, decimal tender);
    }
}
