using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class ChangeCalculator : IChangeCalculator
    {
        public decimal CalculateChange(decimal cost, decimal paid)
        {
            return cost - paid;
        }

        public string DetermineChange(decimal changeDue)
        {
            throw new System.NotImplementedException();
        }
    }
}