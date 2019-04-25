namespace CashRegister
{
    public class UsCurrencyDenomination : ICurrencyDenomination
    {
        public int ValueInLowestDenomination { get; set; }
        public string Name { get; set; }
        //NOTE: Not all languages use plurals in the same way as English.
        // Therefore PluralizedName is on the concrete class and not on the interface.
        // The naming of the currency based on the number of currency will be unique to a specific CultureInfo.
        // I would expand upon this idea if the application needed to be globalized
        public string PluralizedName { get; set; }

        public UsCurrencyDenomination(int valueInLowestDenomination, string name, string pluralizedName)
        {
            ValueInLowestDenomination = valueInLowestDenomination;
            Name = name;
            PluralizedName = pluralizedName;
        }
    }
}
