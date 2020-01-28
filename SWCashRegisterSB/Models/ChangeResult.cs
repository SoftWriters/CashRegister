using SWCashRegisterSB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Models
{
    public class ChangeResult : IChangeResult
    {
        public ChangeResult(IDenomination denomination, int quantity)
        {
            Denomination = denomination;
            Quantity = quantity;
        }
        public IDenomination Denomination { get; set; }
        public int Quantity { get; set; }
    }
}
