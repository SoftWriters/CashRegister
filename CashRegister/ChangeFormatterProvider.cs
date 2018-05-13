using CashRegister.ChangeFormatters;

namespace CashRegister
{
    public static class ChangeFormatterProvider
    {
        public static IChangeFormatter GetChangeFormatter(Transaction transaction) =>
            (transaction.ChangeDue % 0.03m) == 0m
                ? (IChangeFormatter)new RandomChangeFormatter()
                : new GreedyChangeFormatter();
    }
}
