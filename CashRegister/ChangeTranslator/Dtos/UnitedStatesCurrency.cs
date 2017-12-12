using System.Collections.Generic;

namespace ChangeTranslator.Dtos
{
    public class UnitedStatesCurrency : ICurrency
    {
        public IEnumerable<Denomination> Denominations { get; }
        public string NoChangePhrase { get; }

        public UnitedStatesCurrency()
        {
            Denominations = new List<Denomination>
            {
                new Denomination {SingularName = "dollar", PluralName = "dollars", Value = 1m},
                new Denomination {SingularName = "quarter", PluralName = "quarters", Value = .25m},
                new Denomination {SingularName = "dime", PluralName = "dimes", Value = .10m},
                new Denomination {SingularName = "nickel", PluralName = "nickels", Value = .05m},
                new Denomination {SingularName = "penny", PluralName = "pennies", Value = .01m}
            };

            NoChangePhrase = "No change";
        }
    }
}
