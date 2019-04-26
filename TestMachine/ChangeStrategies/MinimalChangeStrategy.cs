using System;
using CashMachine.Domain;

namespace CashMachine.ChangeStrategies
{
    public interface IMinimalChangeStrategy : IChangeStrategy  { }

    public class MinimalChangeStrategy : IMinimalChangeStrategy
    {
        private readonly IMoney _money;

        public MinimalChangeStrategy(IMoney money)
        {
            _money = money;
        }

        public virtual Change MakeChange(decimal value)
        {
            var change = new Change();
            foreach(var currency in _money.DecreasingValueCurrency)
            {
                if (value >= currency.Value)
                {
                    change.Add(currency, (int)Math.Floor(value / currency.Value));
                    value -= currency.Value * change.NumberOf(currency);
                }
            }
            return change;
        }
    }
}
