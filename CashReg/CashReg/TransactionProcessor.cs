using System;
using System.Collections.Generic;
using System.Linq;

namespace CashReg
{
    public static class TransactionProcessor
    {
        // Based on: https://en.wikipedia.org/wiki/United_States_dollar#Coins
        private static readonly int[] Denominations =
        {
            1,    // penny
            5,    // nickel
            10,   // dime
            25,   // quarter
            50,   // half dollar
            100,  // $1 dollar (coin or bill)
            200,  // $2 bill
            500,  // $5 bill
            1000, // $10 bill
            2000, // $20 bill
            5000, // $50 bill
            10000 // $100 bill
        };

        private static readonly Dictionary<int, string> DenominationPrettyNames = new Dictionary<int, string>
        {
            {1,    "Penn"}, // we'll add the rest of the letters later.
            {5,    "Nickel"},
            {10,   "Dime"},
            {25,   "Quarter"},
            {50,   "Half Dollar"},
            {100,  "Dollar"},
            {200,  "2 Dollar Bill"},
            {500,  "5 Dollar Bill"},
            {1000, "10 Dollar Bill"},
            {2000, "20 Dollar Bill"},
            {5000, "50 Dollar Bill"},
            {10000,"100 Dollar Bill"}
        };

        public static string ProcessTransaction(Transaction t)
        {
            var changeOwedAsTotalPennies = (int)(t.Paid * 100) - (int)(t.Due * 100);
            return DetermineOutputLine(changeOwedAsTotalPennies, IsWacky(changeOwedAsTotalPennies));
        }

        private static bool IsWacky(int changedOwedAsPennies)
        {
            return changedOwedAsPennies % 3 == 0;
        }

        private static string DetermineOutputLine(int changedOwedAsPennies, bool isWacky)
        {
            var result = string.Empty;
            var denoms = Denominations.Reverse();
            foreach (var denom in denoms)
            {
                if (changedOwedAsPennies < denom)
                {
                    continue;
                }

                var numOfDenominations = changedOwedAsPennies / denom;

                var suffix = numOfDenominations > 1 ? "s" : string.Empty;
                var lineTerminator = ", ";
                if (denom == 1)
                {
                    lineTerminator = string.Empty;
                    isWacky = false;
                    suffix = numOfDenominations > 1 ? "ies" : "y";
                }

                if (isWacky)
                {
                    var random = new Random();
                    numOfDenominations = random.Next(0, changedOwedAsPennies / denom);
                    if (numOfDenominations == 0)
                    {
                        continue;
                    }
                    suffix = numOfDenominations > 1 ? "s" : string.Empty;
                }

                result += $"{numOfDenominations} {DenominationPrettyNames[denom]}{suffix}{lineTerminator}";
                changedOwedAsPennies -= denom * numOfDenominations;
            }

            return result;
        }
    }
}
