using System;

namespace DataAccess.Entity
{
    /// <summary>
    /// Represents currency.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Monetary value. Ex: .25
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Singular form. Ex: Quarter.
        /// </summary>
        public string SingularDescription { get; set; }

        /// <summary>
        /// Plural form. Ex: Quarters
        /// </summary>
        public string PluralDescription { get; set; } 

        /// <summary>
        /// How many does it take to equal 1 whole unit i.e. Dollar.
        /// </summary>
        public int MaxPerDollar
        {
            get
            {
                return Convert.ToInt32(1M / this.Value);
            }
        }
    }
}