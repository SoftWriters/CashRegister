using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class ChangeCalculator : IChangeCalculator
    {
        public double CalculateChange(double cost, double paid)
        {
            throw new System.NotImplementedException();
        }

        public string DetermineChange(double changeDue)
        {
            throw new System.NotImplementedException();
        }
    }
}