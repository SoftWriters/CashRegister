using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public static class CashRegister
    {
        private static readonly double[] _denominations = { 100.00, 50.00, 20.00, 10.00, 5.00, 1.00, 0.25, 0.10, 0.05, 0.01 };
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        public static IList<ChangeAmount> MakeChange(OwedPaid owedPaid)
        {
            var amountLeft = owedPaid.Change;
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

            var denomIndex = owedPaid.ShouldMakeCreative ? _random.Next(startingPoint, _denominations.Length) : startingPoint;

            var results = new SortedDictionary<double, int>();
            while (amountLeft > 0)
            {
                var denomination = _denominations[denomIndex];

                var tenders = GetTenders(denomination, amountLeft, owedPaid.ShouldMakeCreative);

                if (tenders != 0)
                {
                    amountLeft = Math.Round(amountLeft - (tenders * denomination), 2);
                    if (results.ContainsKey(denomination))
                    {
                        results[denomination] += tenders;
                    }
                    else
                    {
                        results.Add(denomination, tenders);
                    }
                }

                denomIndex = owedPaid.ShouldMakeCreative ? _random.Next(startingPoint, _denominations.Length) : denomIndex + 1;
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

        private static int GetTenders(double denomination, double amountLeft, bool shouldMakeCreative)
        {
            var tenders = (int)Math.Floor(amountLeft / denomination);

            if (shouldMakeCreative)
            {
                return tenders != 0 ? _random.Next(1, tenders + 1) : 0;
            }

            return tenders;
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
