using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public interface IReadService
    {
        public List<decimal> ReadFile();
    }
}
