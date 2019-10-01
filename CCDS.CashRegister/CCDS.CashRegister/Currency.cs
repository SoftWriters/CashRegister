//stores currency amounts and currency name singulars & plurals

using System.Collections.Generic;

namespace CCDS.CashRegister
{
    public static class Currency
    {
        public static readonly long[] USCurrencyAmounts = new long[] { 100L, 25L, 10L, 5L, 1L };
        public static readonly List<KeyValuePair<string, string>> USCurrency = new List<KeyValuePair<string, string>> {
            new KeyValuePair<string, string>("dollar", "dollars"),
            new KeyValuePair<string, string>("quarter", "quarters"),
            new KeyValuePair<string, string>("dime", "dimes"),
            new KeyValuePair<string, string>("nickel", "nickels"),
            new KeyValuePair<string, string>("penny", "pennies")
        };
    }
}
