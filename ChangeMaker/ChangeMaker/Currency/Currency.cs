using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    /// <summary>
    /// A generic currency. 
    /// Can be of any denomination or value.
    /// Initialized within ValidCurrencies.
    /// </summary>
    public class Currency : ICurrency
    {
        public string ValueString { get; set; }
        public string Denomination { get; set; }
        public string DenominationPlural { get; set; }
        public decimal Value
        {
            get
            {
                decimal val;
                decimal.TryParse(ValueString, out val);
                return val;
            }
        }
    }
}
