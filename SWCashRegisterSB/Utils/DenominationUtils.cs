using SWCashRegisterSB.Calculators;
using SWCashRegisterSB.Calculators.Interfaces;
using SWCashRegisterSB.Models;
using SWCashRegisterSB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Utils
{
    public static class DenominationUtils
    {
        #region static Change Denominations...
        public readonly static ChangeDenomination Hundred = new ChangeDenomination { Name = "hundred", PluralName = "hundreds", Value = 100 };
        public readonly static ChangeDenomination Fifty = new ChangeDenomination { Name = "fifty", PluralName = "fifties", Value = 50 };
        public readonly static ChangeDenomination Twenty = new ChangeDenomination { Name = "twenty", PluralName = "twenties", Value = 20 };
        public readonly static ChangeDenomination Ten = new ChangeDenomination { Name = "ten", PluralName = "tens", Value = 10 };
        public readonly static ChangeDenomination Five = new ChangeDenomination { Name = "five", PluralName = "fives", Value = 5 };
        public readonly static ChangeDenomination Dollar = new ChangeDenomination { Name = "dollar", PluralName = "dollars", Value = 1 };

        public readonly static ChangeDenomination Quarter = new ChangeDenomination { Name = "quarter", PluralName = "quarters", Value = 0.25M };
        public readonly static ChangeDenomination Dime = new ChangeDenomination { Name = "dime", PluralName = "dimes", Value = 0.10M };
        public readonly static ChangeDenomination Nickel = new ChangeDenomination { Name = "nickel", PluralName = "nickels", Value = 0.05M };
        public readonly static ChangeDenomination Penny = new ChangeDenomination { Name = "penny", PluralName = "pennies", Value = 0.01M };

        public readonly static List<ChangeDenomination> OrderedDenominations = new List<ChangeDenomination> { Hundred, Fifty, Twenty, Ten, Five, Dollar, Quarter, Dime, Nickel, Penny };
        #endregion

        private readonly static RandomChangeCalculator _randomChangeCalculator = new RandomChangeCalculator();
        private readonly static ChangeCalculator _changeCalculator = new ChangeCalculator();

        public static IChangeCalculator GetChangeCalculator(decimal amountDue)
        {
            if (amountDue % 0.03m == 0)
                return _randomChangeCalculator;
            else
                return _changeCalculator;
        }

        public static string GetChangeOutput(List<IChangeResult> changeResults)
        {
            var changeSB = new StringBuilder();

            var sortedResults = changeResults.OrderByDescending(x => x.Denomination.Value);

            foreach(var result in sortedResults)
            {
                if (changeSB.Length > 0)
                    changeSB.Append(',');

                var plural = result.Quantity > 1;

                changeSB.Append($"{result.Quantity} {(plural ? result.Denomination.PluralName : result.Denomination.Name)}");
            }

            return changeSB.ToString();
        }
    }
}
