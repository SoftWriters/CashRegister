using System.Collections.Generic;
using CreativeCashDrawSolutions.Entities;

namespace CreativeCashDrawSolutions.Domain.Currencies.Canada
{
    public class Canada : CurrencyType
    {
        private readonly List<DenominationType> _denominations = new List<DenominationType>
        {
            new DenominationType { NameSingular = "toonie", NamePlural = "toonies", Value = 100 },
            new DenominationType { NameSingular = "loonie", NamePlural = "loonies", Value = 100 },
            new DenominationType { NameSingular = "half dollar", NamePlural = "half dollars", Value = 50 },
            new DenominationType { NameSingular = "quarter", NamePlural = "quarters", Value = 25 },
            new DenominationType { NameSingular = "dime", NamePlural = "dimes", Value = 10 },
            new DenominationType { NameSingular = "nickle", NamePlural = "nickles", Value = 5 },
            new DenominationType { NameSingular = "penny", NamePlural = "pennies", Value = 1 }
        };

        protected override IEnumerable<DenominationType> Denominations
        {
            get { return _denominations; }
        }
    }
}
