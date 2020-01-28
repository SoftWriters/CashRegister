using SWCashRegisterSB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Calculators.Interfaces
{
    public interface IChangeCalculator
    {
        List<IChangeResult> CalculateChange(decimal changeAmount);
    }
}
