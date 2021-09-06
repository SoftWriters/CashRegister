using CashDrawer.Core.ChangeCalculators;
using System;

namespace CashDrawer.Core.ChangeCalculatorFactories
{
    public class ChangeCalculatorFactory : IChangeCalculatorFactory
    {
        private static Random _random = new Random();

        private IChangeCalculator _standardChangeCalculator = new StandardChangeCalculator();
        private IChangeCalculator _randomChangeCalculator   = new RandomChangeCalculator(_random);


        public IChangeCalculator GetChangeCalculator(decimal due)
        {
            var pennies = due * 100;
            if (pennies % 3 == 0)
            {
                return _randomChangeCalculator;
            }
            return _standardChangeCalculator;
        }
    }
}
