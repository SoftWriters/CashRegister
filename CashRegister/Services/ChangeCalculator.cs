using CashRegister.Exceptions;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class ChangeCalculator : IChangeCalculator
    {
        public decimal CalculateChange(decimal cost, decimal paid)
        {
            if (cost < 0)
            {
                throw new IllegalNegativeException(cost);
            }

            if (paid < 0)
            {
                throw new IllegalNegativeException(paid);
            }
            return cost - paid;
        }

        public string DetermineChange(decimal changeDue)
        {
            throw new System.NotImplementedException();
        }
    }
}