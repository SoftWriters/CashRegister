using System;
using System.Collections.Generic;
using System.Linq;
using ChangeTranslator.Dtos;

namespace ChangeTranslator
{
    public class ChangeOutput
    {
        private ICurrency Currency { get; }
        private decimal SmallestDenomination { get; }
        private Random Randomizer { get; }
        
        public ChangeOutput(ICurrency currency = null)
        {
            Currency = currency ?? new UnitedStatesCurrency();
            SmallestDenomination = Currency.Denominations.Min(x => x.Value);
            Randomizer = new Random();
        }

        public string MakeChange(decimal cost, decimal paid, bool isRandom)
        {
            var diff = paid - cost;
            if (diff == 0) return Currency.NoChangePhrase;
            if(diff < 0) throw new ArgumentException("paid cannot be less than cost");

            var change = new List<string>();
            var denominations = Currency.Denominations.OrderByDescending(x => x.Value).ToList();

            foreach (var d in denominations)
            {
                var maxCount = (int) (diff / d.Value);
                var count = isRandom ? RandomCount(maxCount, d.Value) : maxCount;
                diff -= count * d.Value;
                if (count > 0)
                    change.Add(count + " " + (count > 1 ? d.PluralName : d.SingularName));
            }
            return string.Join(",", change);
        }

        public int RandomCount(int maxCount, decimal value)
        {
            return value == SmallestDenomination ? maxCount : Randomizer.Next(maxCount + 1);
        }
    }
}
