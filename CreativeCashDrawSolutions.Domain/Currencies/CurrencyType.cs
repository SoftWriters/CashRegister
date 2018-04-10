using System;
using System.Collections.Generic;
using System.Linq;
using CreativeCashDrawSolutions.Entities;

namespace CreativeCashDrawSolutions.Domain.Currencies
{
    /// <summary>This class is responsible for defining the type of currency in the library.</summary>
    public abstract class CurrencyType
    {
        /// <summary>Gets the denominations of the implemented currency.</summary>
        /// <value>A collection of supported denominations.</value>
        protected abstract IEnumerable<DenominationType> Denominations { get; }

        /// <summary>Gets the denomination types in this collection.</summary>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the denomination types in this
        /// collection.
        /// </returns>
        public IEnumerable<DenominationType> GetDenominationTypes()
        {
            return Denominations.OrderByDescending(x => x.Value);
        }

        /// <summary>This routine is responsible for getting the correct output string based on the denomination value and count.</summary>
        /// <param name="value">The denomination value to evaluate.</param>
        /// <param name="count">Number of denominations to evaluate.</param>
        /// <returns>A singular or plural string containing the output.</returns>
        /// <remarks>If the output of 1 penny or 2 pennies is not correct for the currency code, you can override it to support the currency.</remarks>
        public virtual string GetOutputStringByValue(int value, int count)
        {
            var type = GetTypeByValue(value);

            // Not sure how all languages deal with plural names so I will default to anything greater than 1 is plural
            return string.Format("{0} {1}", count, count > 1 ? type.NamePlural : type.NameSingular);
        }

        /// <summary>This routine is responsible for getting the type of currency based on the value.</summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown in the event that a denomination is passed in that is not supported in the currency.
        /// </exception>
        /// <param name="value">The denomination value to evaluate.</param>
        /// <returns>The denomination type that maps to the value.</returns>
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
