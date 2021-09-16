using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Models.Interfaces
{
    public interface IChangeResult
    {
        IDenomination Denomination { get; set; }
        int Quantity { get; set; }
    }
}
