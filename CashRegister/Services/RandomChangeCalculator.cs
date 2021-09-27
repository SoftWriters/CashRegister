using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class RandomChangeCalculator : IChangeCalculator
    {
        public decimal CalculateChange(decimal paid, decimal cost)
        {
            throw new System.NotImplementedException();
        }

        public string DetermineChange(decimal changeDue)
        {
            throw new System.NotImplementedException();
        }
    }
}