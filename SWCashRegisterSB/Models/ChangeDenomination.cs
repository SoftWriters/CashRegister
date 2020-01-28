using SWCashRegisterSB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB.Models
{
    public class ChangeDenomination : IDenomination
    {
        public string Name { get; set; }
        public string PluralName { get; set; }
        public decimal Value { get; set; }
    }
}
