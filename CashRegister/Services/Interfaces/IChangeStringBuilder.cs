namespace CashRegister.Services.Interfaces
{
    public interface IChangeStringBuilder
    {
         string BuildChangeString(decimal dollars, decimal quarters, decimal dimes, decimal nickels, decimal pennies);
    }
}