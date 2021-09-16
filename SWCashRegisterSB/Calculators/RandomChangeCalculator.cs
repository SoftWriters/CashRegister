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
    public class RandomChangeCalculator : IChangeCalculator
    {

        public List<IChangeResult> CalculateChange(decimal changeAmount)
        {
            var result = new Dictionary<string,IChangeResult>();
            var random = new Random();

            while(changeAmount > 0)
            {
                var denominations = DenominationUtils.OrderedDenominations.Where(x => x.Value <= changeAmount).ToList();
                var index = random.Next(0, denominations.Count());
                var denomination = denominations[index];
                var count = random.Next(1, decimal.ToInt32(changeAmount / denomination.Value));

                if (result.ContainsKey(denomination.Name))
                    result[denomination.Name].Quantity += count;
                else
                    result.Add(denomination.Name, new ChangeResult(denomination, count));

                changeAmount -= denomination.Value * count;

            }

            return result.Values.ToList();
        }
    }
}
