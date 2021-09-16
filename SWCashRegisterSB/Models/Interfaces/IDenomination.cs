using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Models.Interfaces
{
    public interface IDenomination
    {
        string Name { get; set; }
        string PluralName { get; set; }
        decimal Value { get; set; }
    }
}
