namespace DataAccess.FakeData.Currency
{
    public abstract class CurrencyRow
    {
        /// <summary>
        /// Monetary value. .25
        /// </summary>
        public abstract decimal Value { get; }

        /// <summary>
        /// Singular form. Quarter.
        /// </summary>
        public abstract string SingularDescription { get; }

        /// <summary>
        /// Plural form. Quarters
        /// </summary>
        public abstract string PluralDescription { get; }
    }
}