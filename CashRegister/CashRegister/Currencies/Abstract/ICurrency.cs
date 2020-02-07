using System.Collections.Generic;

namespace CashRegisterConsumer
{
    public interface ICurrency
    {
        decimal TotalValue();
        void AddMoney(decimal value);
        void AddMoney(Money money);
    }
}