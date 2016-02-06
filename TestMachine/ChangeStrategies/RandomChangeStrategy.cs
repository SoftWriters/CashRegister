using System;
using System.Collections.Generic;
using CashMachine.Domain;

namespace CashMachine.ChangeStrategies
{
    public interface IRandomChangeStrategy
    {
        Change MakeChange(decimal value);
    }

    public class RandomChangeStrategy : IRandomChangeStrategy
    {
        private readonly IMoney _money;
        private readonly ICurrencyRandomizer _randomizer;

        public RandomChangeStrategy(IMoney money, ICurrencyRandomizer randomizer)
        {
            _money = money;
            _randomizer = randomizer;
        }

        public Change MakeChange(decimal value)
        {
            var change = new Change();
            foreach (var currency in _randomizer.Shuffle(new List<ICurrency>(_money.DecreasingValueCurrency)))
                if (value >= currency.Value)
                {
                    change.Add(currency, (int)Math.Floor(value / currency.Value));
                    value -= currency.Value * change.NumberOf(currency);
                }
            return change;
        }
    }
}
