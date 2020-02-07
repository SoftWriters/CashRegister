using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class ChangeCalculator : IChangeCalculator
    {
        public abstract string Calculate(ICurrency _price, ICurrency _tender);
    }
}
