using System.Collections.Generic;

namespace CashMachine.Domain
{
    public interface IMoney
    {
        IList<ICurrency> DecreasingValueCurrency { get; }

        IList<ICurrency> UnsortedCurrency { get; }
    }

    public class Money : IMoney
    {
        public static DollarCurrency Dollar = new DollarCurrency();
        public static QuarterCurrency Quarter = new QuarterCurrency();
        public static NickelCurrency Nickel = new NickelCurrency();
        public static DimeCurrency Dime = new DimeCurrency();
        public static PennyCurrency Penny = new PennyCurrency();

        private static readonly List<ICurrency> DecreasingKnownCurrency = new List<ICurrency>() { Dollar, Quarter, Dime, Nickel, Penny };
        private static readonly List<ICurrency> KnownCurrency = new List<ICurrency>() { Dollar, Quarter, Nickel, Dime, Penny };

        public IList<ICurrency> DecreasingValueCurrency => DecreasingKnownCurrency;
        public IList<ICurrency> UnsortedCurrency => KnownCurrency;
    }

    public class DollarCurrency : BaseCurrency
    {
        internal DollarCurrency() : base("dollar", "dollars", 1M) { }
    }

    public class QuarterCurrency : BaseCurrency
    {
        internal QuarterCurrency() : base("quarter", "quarters", 0.25M) { }
    }

    public class DimeCurrency : BaseCurrency
    {
        internal DimeCurrency() : base("dime", "dimes", 0.10M) { }
    }

    public class NickelCurrency : BaseCurrency
    {
        internal NickelCurrency() : base("nickel", "nickels", 0.05M) { }
    }

    public class PennyCurrency : BaseCurrency
    {
        internal PennyCurrency() : base("penny", "pennies", 0.01M) { }
    }
}
