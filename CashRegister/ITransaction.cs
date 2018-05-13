namespace CashRegister
{
    public interface ITransaction
    {
        decimal MoneyPaid { get; }

        decimal MoneyOwed { get; }
    }
}
