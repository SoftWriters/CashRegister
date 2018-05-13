namespace CashRegister
{
    public class Transaction : ITransaction
    {
        public decimal MoneyOwed { get; }

        public decimal MoneyPaid { get; }

        public decimal ChangeDue => MoneyPaid - MoneyOwed;

        public Transaction(decimal moneyOwed, decimal moneyPaid)
        {
            if (moneyOwed > moneyPaid)
                throw new InvalidTransactionException("Money paid must be greater than or equal to money owed.");

            MoneyOwed = moneyOwed;
            MoneyPaid = moneyPaid;
        }
    }
}
