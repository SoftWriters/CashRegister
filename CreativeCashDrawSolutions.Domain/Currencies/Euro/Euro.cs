using System.Collections.Generic;
using CreativeCashDrawSolutions.Entities;

namespace CreativeCashDrawSolutions.Domain.Currencies.Euro
{
    public class Euro : CurrencyType
    {
        private readonly List<DenominationType> _denominations = new List<DenominationType>
        {
            new DenominationType { NameSingular = "€2", NamePlural = "€2", Value = 200 },
            new DenominationType { NameSingular = "€1", NamePlural = "€1", Value = 100 },
            new DenominationType { NameSingular = "50 cent", NamePlural = "50 cents", Value = 50 },
            new DenominationType { NameSingular = "20 cent", NamePlural = "20 cents", Value = 20 },
            new DenominationType { NameSingular = "10 cent", NamePlural = "10 cents", Value = 10 },
            new DenominationType { NameSingular = "5 cent", NamePlural = "5 cents", Value = 5 },
            new DenominationType { NameSingular = "2 cent", NamePlural = "2 cents", Value = 2 },
            new DenominationType { NameSingular = "1 cent", NamePlural = "1 cents", Value = 1 }
        };

        protected override IEnumerable<DenominationType> Denominations
        {
            get { return _denominations; }
        }
    }
}
