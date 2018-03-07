using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    public interface ICurrency
    {
        string ValueString { get; set; }
        string Denomination { get; set; }
        string DenominationPlural { get; set; }
        decimal Value { get; }
    }
}
