using System;
using CashRegister.ChangeFormatters;

namespace CashRegister
{
    public static class ChangeFormatterProvider
    {
        private static Lazy<IChangeFormatter> GreedyChangeFormatter => new Lazy<IChangeFormatter>(() => new GreedyChangeFormatter());

        private static Lazy<IChangeFormatter> RandomChangeFormatter => new Lazy<IChangeFormatter>(() => new RandomChangeFormatter());

        public static IChangeFormatter GetChangeFormatter(Transaction transaction) =>
            (transaction.MoneyOwed % 0.03m) == 0m
                ? RandomChangeFormatter.Value
                : GreedyChangeFormatter.Value;
    }
}
