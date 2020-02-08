using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterConsumer
{
    public interface IMoney
    {
        void Add(int count);
        void Subtract(int count);
        void Clear();
    }
}
