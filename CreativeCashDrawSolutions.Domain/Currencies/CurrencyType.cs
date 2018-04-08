using System;
using System.Collections.Generic;
using System.Linq;
using CreativeCashDrawSolutions.Entities;

namespace CreativeCashDrawSolutions.Domain.Currencies
{
    public abstract class CurrencyType
    {
        protected abstract IEnumerable<DenominationType> Denominations { get; }

        public IEnumerable<DenominationType> GetDenominationTypes()
        {
            return Denominations.OrderByDescending(x => x.Value);
        }

        public virtual string GetOutputStringByValue(int value, int count)
        {
            var type = GetTypeByValue(value);

            // Not sure how all languages deal with plural names so I will default to anything greater than 1 is plural
            return string.Format("{0} {1}", count, count > 1 ? type.NamePlural : type.NameSingular);
        }

        protected DenominationType GetTypeByValue(int value)
        {
            var type = Denominations.Select(x => x).FirstOrDefault(x => x.Value == value);
            if (type == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("Value of {0} does not exist in the availiable types.", value));
            }

            return type;
        }
    }
}
