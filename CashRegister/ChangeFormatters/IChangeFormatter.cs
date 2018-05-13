namespace CashRegister.ChangeFormatters
{
    public interface IChangeFormatter
    {
        string FormatChangeResult(Transaction transaction);
    }
}
