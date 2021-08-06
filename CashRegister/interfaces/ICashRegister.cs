using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public interface ICashRegister
    {
        public Change GetChange(decimal price, decimal totalPaid);
    }
}
