using SWCashRegisterSB.Calculators.Interfaces;
using SWCashRegisterSB.Models;
using SWCashRegisterSB.Models.Interfaces;
using SWCashRegisterSB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Calculators
{
    class ChangeCalculator : IChangeCalculator
    {
        List<IChangeResult> IChangeCalculator.CalculateChange(decimal changeAmount)
        {
            var result = new List<IChangeResult>();

            while (changeAmount > 0)
            {
                var denomination = DenominationUtils.OrderedDenominations.First(x => x.Value <= changeAmount);
                var count = decimal.ToInt32(changeAmount / denomination.Value);

                result.Add(new ChangeResult(denomination, count));
                changeAmount -= denomination.Value * count;
            }

            return result;
        }
    }
}
