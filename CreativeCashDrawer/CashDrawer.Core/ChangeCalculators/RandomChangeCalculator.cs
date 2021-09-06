using System;

namespace CashDrawer.Core.ChangeCalculators
{
    public class RandomChangeCalculator : IChangeCalculator
    {
        private readonly Random _random;


        public RandomChangeCalculator(Random random)
        {
            _random = random;
        }


        public Change GetChange(decimal due, decimal paid)
        {
            var duePennies = (int)((paid - due) * 100);

            var dollars = 0;
            if (duePennies >= 100)
            {
                dollars = _random.Next(0, duePennies / 100);
                duePennies -= dollars * 100;
            }

            var quarters = 0;
            if (duePennies > 25)
            {
                quarters = _random.Next(0, duePennies / 25);
                duePennies -= quarters * 25;
            }

            var dimes = 0;
            if (duePennies > 10)
            {
                dimes = _random.Next(0, duePennies / 10);
                duePennies -= dimes * 10;
            }

            var nickles = 0;
            if (duePennies > 5)
            {
                nickles = _random.Next(0, duePennies / 5);
                duePennies -= nickles * 5;
            }

            var pennies = duePennies;

            return new Change(dollars, quarters, dimes, nickles, pennies);
        }
    }
}
