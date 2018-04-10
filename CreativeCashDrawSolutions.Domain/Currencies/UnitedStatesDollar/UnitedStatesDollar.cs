using System.Collections.Generic;
using CreativeCashDrawSolutions.Entities;

namespace CreativeCashDrawSolutions.Domain.Currencies.UnitedStatesDollar
{
    public class UnitedStatesDollar : CurrencyType
    {
        private readonly List<DenominationType> _denominations = new List<DenominationType>
        {
            new DenominationType { NameSingular = "dollar", NamePlural = "dollars", Value = 100 },
            new DenominationType { NameSingular = "quarter", NamePlural = "quarters", Value = 25 },
            new DenominationType { NameSingular = "dime", NamePlural = "dimes", Value = 10 },
            new DenominationType { NameSingular = "nickle", NamePlural = "nickles", Value = 5 },
            new DenominationType { NameSingular = "penny", NamePlural = "pennies", Value = 1 }
        };

        protected override IEnumerable<DenominationType> Denominations
        {
            get { return _denominations; }
        }

        public override string GetOutputStringByValue(int value, int count)
        {
            var type = GetTypeByValue(value);

            // Regarding dollar, singular is just 1. 0 is treated as plural.
            return string.Format("{0} {1}", count, count == 1 ? type.NameSingular : type.NamePlural);
        }
    }
}
