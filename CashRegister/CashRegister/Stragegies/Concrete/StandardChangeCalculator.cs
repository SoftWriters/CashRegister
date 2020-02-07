using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    internal class StandardChangeCalculator : ChangeCalculator
    {
        public override string Calculate(ICurrency _price, ICurrency _tender)
        {
            throw new NotImplementedException();
        }
    }
}
