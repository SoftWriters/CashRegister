using System;
using CashRegister.Constants;
using CashRegister.Exceptions;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class RandomChangeCalculator : IChangeCalculator
    {
        private IChangeStringBuilder changeStringBuilder;
        private IRandomNumberGenerator randomNumberGenerator;
        public RandomChangeCalculator(
            IChangeStringBuilder changeStringBuilder,
            IRandomNumberGenerator randomNumberGenerator)
        {
            this.changeStringBuilder = changeStringBuilder;  
            this.randomNumberGenerator = randomNumberGenerator;  
        }

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
            // Multiply * 100
            changeDue = changeDue * 100;

            decimal dollars;
            decimal quarters;
            decimal dimes;
            decimal nickels;
            decimal pennies;

            dollars = determineDenomination(changeDue, Denomination.DOLLAR);
            changeDue = RecalculateChangeDue(changeDue, dollars, Denomination.DOLLAR);

            quarters = determineDenomination(changeDue, Denomination.QUARTER);
            changeDue = RecalculateChangeDue(changeDue, quarters, Denomination.QUARTER);

            dimes = determineDenomination(changeDue, Denomination.DIME);
            changeDue = RecalculateChangeDue(changeDue, dimes, Denomination.DIME);

            nickels = determineDenomination(changeDue, Denomination.NICKEL);
            changeDue = RecalculateChangeDue(changeDue, nickels, Denomination.NICKEL);

            pennies = (int) changeDue;

            return changeStringBuilder.BuildChangeString(dollars, quarters, dimes, nickels, pennies);
        }

        private decimal determineDenomination(decimal changeDue, int denomination)
        {
            return randomNumberGenerator.GenerateRandomInt(0, (int) Math.Floor(changeDue / denomination));
        }

        private decimal RecalculateChangeDue(decimal changeDue, decimal denominationCount, int denomination)
        {
            return changeDue - (denominationCount * denomination);
        }
    }
}