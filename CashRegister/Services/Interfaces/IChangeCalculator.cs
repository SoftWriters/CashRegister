namespace CashRegister.Services.Interfaces
{
    public interface IChangeCalculator
    {
         public decimal CalculateChange(decimal paid, decimal cost);
         public string DetermineChange(decimal changeDue);
    }
}