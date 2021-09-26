namespace CashRegister.Services.Interfaces
{
    public interface IChangeCalculator
    {
         public decimal CalculateChange(decimal cost, decimal paid);
         public string DetermineChange(decimal changeDue);
    }
}