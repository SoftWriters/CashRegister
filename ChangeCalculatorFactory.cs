using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegister
{
    public static class ChangeCalculatorFactory
    {
        private static RandomChangeCalculator randomChangeCalculator = new RandomChangeCalculator();
        private static MinimumChangeCalculator minimumChangeCalculator = new MinimumChangeCalculator();

        public static IChangeCalculator GetChangeCalculator(int changeAmount)
        {
            if (changeAmount % 3 == 0)
            {
                return randomChangeCalculator;
            }
            else
            {
                return minimumChangeCalculator;
            }
        }
    }
}
