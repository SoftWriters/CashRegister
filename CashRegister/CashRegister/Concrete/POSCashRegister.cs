using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    public class POSCashRegister : CashRegister
    {
        public POSCashRegister() { }
        public POSCashRegister(ICurrency price, ICurrency tender, IChangeCalculator changeCalculator):base(price, tender, changeCalculator) { }
    }
}
