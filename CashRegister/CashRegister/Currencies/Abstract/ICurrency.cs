using System.Collections.Generic;

namespace CashRegisterConsumer
{
    public interface ICurrency
    {
        List<Money> Bills { get; }
        List<Money> Coins { get; }
        List<Money> AllDenominations { get; }

        void Clear();
    }
}