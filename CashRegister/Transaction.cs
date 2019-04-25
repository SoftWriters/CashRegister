namespace CashRegister
{
    public class Transaction : ITransaction
    {
        public decimal MoneyOwed { get; set; }

        public decimal MoneyPaid { get; set; }

        public decimal ChangeDue => MoneyPaid >= MoneyOwed
            ? MoneyPaid - MoneyOwed
            : throw new InvalidTransactionException("Money paid must be greater than or equal to money owed.");
    }
}
