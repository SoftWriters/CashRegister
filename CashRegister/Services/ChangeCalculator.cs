using CashRegister.Exceptions;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class ChangeCalculator : IChangeCalculator
    {
        public decimal CalculateChange(decimal paid, decimal cost)
        {
            if (paid < 0)
            {
                throw new IllegalNegativeException(paid);
            }

            if (cost < 0)
            {
                throw new IllegalNegativeException(cost);
            }
            return paid - cost;
        }

        public string DetermineChange(decimal changeDue)
        {
            throw new System.NotImplementedException();
        }
    }
}