using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public static class CashRegister
    {
        private static readonly double[] _denominations = { 100.00, 50.00, 20.00, 10.00, 5.00, 1.00, 0.25, 0.10, 0.05, 0.01 };

        public static IList<ChangeAmount> MakeChange(OwedPaid owedPaid)
        {
            return owedPaid.ShouldMakeCreative ? MakeCreativeChange(owedPaid.Change) : MakeRegularChange(owedPaid.Change);
        }

        private static IList<ChangeAmount> MakeRegularChange(double amountLeft)
        {
            var startingPoint = 0;
            for (var i = 0; i < _denominations.Length; i++)
            {
                if (_denominations[i] > amountLeft)
                {
                    continue;
                }

                startingPoint = i;
                break;
            }

            var results = new SortedDictionary<double, int>();
            for (var i = startingPoint; i < _denominations.Length; i++)
            {
                var denomination = _denominations[i];

                if (denomination > amountLeft)
                {
                    continue;
                }

                var coins = (int)Math.Floor(amountLeft / denomination);
                amountLeft = Math.Round(amountLeft - (coins * denomination), 2);
                if (results.ContainsKey(denomination))
                    results[denomination] += coins;
                else
                    results.Add(denomination, coins);
            }

            return ParseChange(results);
        }

        private static IList<ChangeAmount> MakeCreativeChange(double amountLeft)
        {
            var results = new SortedDictionary<double, int>();
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            while (amountLeft > 0)
            {
                var denomIndex = random.Next(0, _denominations.Length);
                var denomination = _denominations[denomIndex];

                if (denomination > amountLeft)
                {
                    continue;
                }

                var coins = (int)Math.Floor(amountLeft / denomination);
                amountLeft = Math.Round(amountLeft - (coins * denomination), 2);
                if (results.ContainsKey(denomination))
                    results[denomination] += coins;
                else
                    results.Add(denomination, coins);
            }

            return ParseChange(results);
        }

        private static IList<ChangeAmount> ParseChange(IDictionary<double, int> coins)
        {
            var parsed = new List<ChangeAmount>();
            foreach(var coin in coins.Reverse())
            {
                var description = GetDenominationDescription(coin.Key, coin.Value);
                parsed.Add(new ChangeAmount { Amount = coin.Value, Description = description });
            }

            return parsed;
        }

        private static string GetDenominationDescription(double denomination, int amount)
        {
            var plural = amount > 1;

            if (denomination == 100.00) return plural ? "Hundreds" : "Hundred";
            else if (denomination == 50.00) return plural ? "Fifties" : "Fifty";
            else if (denomination == 20.00) return plural ? "Twenties" : "Twenty";
            else if (denomination == 10.00) return plural ? "Tens" : "Ten";
            else if (denomination == 5.00) return plural ? "Fives" : "Five";
            else if (denomination == 1.00) return plural ? "Dollars" : "Dollar";
            else if (denomination == 0.25) return plural ? "Quarters" : "Quarter";
            else if (denomination == 0.10) return plural ? "Dimes" : "Dime";
            else if (denomination == 0.05) return plural ? "Nickels" : "Nickel";
            else return plural ? "Pennies" : "Penny";
        }
    }
}
