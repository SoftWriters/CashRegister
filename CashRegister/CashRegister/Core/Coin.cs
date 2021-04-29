using System;

namespace CashRegister.Core
{
    public abstract class Coin : IComparable<Coin>
    {
        #region Protected Members
        protected string VerboseSingular { get; }
        protected string VerbosePlural { get; }
        #endregion

        #region Public Members
        public int CentValue { get; set; }
        #endregion

        #region Constructors / Factory Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Constructor that requires a value (in cents),
        ///             the text for a singular coin descriptor,
        ///             and the text for the plural coin descriptor.
        /// </summary>
        /// <param name="centValue">Value of coin in cents.</param>
        /// <param name="singular">String text for singular descriptor.</param>
        /// <param name="plural">String text for plural descriptor.</param>
        protected Coin(int centValue, string singular, string plural)
        {
            CentValue = centValue;
            VerboseSingular = singular;
            VerbosePlural = plural;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Checks to see if quantity is higher than one.
        /// </summary>
        /// <param name="quantity">Int for quantity of coins to check.</param>
        /// <returns>Returns whether there is more than one coin.</returns>
        private bool IsPlural(int quantity)
        {
            return quantity > 1;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Creates descriptor string for the coin.
        /// </summary>
        /// <param name="quantity">Int for amount of coins for determining descriptor.</param>
        /// <returns>Returns a string describing quantity of coins.</returns>
        public string ToVerboseString(int quantity)
        {
            if (quantity == 0)
            {
                return "";
            }
            if (IsPlural(quantity))
            {
                return $"{quantity} {VerbosePlural}";
            }
            return $"{quantity} {VerboseSingular}";
        }
        #endregion

        #region Interface Implementations
        public int CompareTo(Coin coin)
        {
            return CentValue.CompareTo(coin.CentValue);
        }
        #endregion
    }
}
