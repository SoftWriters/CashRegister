namespace CashRegister.Services.Interfaces
{
    public interface IChangeCalculator
    {
         public double CalculateChange(double cost, double paid);
         public string DetermineChange(double changeDue);
    }
}