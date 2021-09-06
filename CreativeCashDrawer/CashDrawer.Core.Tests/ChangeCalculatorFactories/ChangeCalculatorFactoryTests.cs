using CashDrawer.Core.ChangeCalculatorFactories;
using CashDrawer.Core.ChangeCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.Core.Tests.ChangeCalculatorFactories
{

    [TestClass]
    public class ChangeCalculatorFactoryTests
    {

        [TestMethod]
        public void factory_returns_standard_change_calculator_if_due_amount_is_not_divisible_by_3()
        {
            var factory = new ChangeCalculatorFactory();
            var calculator = factory.GetChangeCalculator(10);

            Assert.IsTrue(calculator.GetType() == typeof(StandardChangeCalculator));
        }


        [TestMethod]
        public void factory_returns_random_change_calculator_if_due_amount_is_divisible_by_3()
        {
            var factory = new ChangeCalculatorFactory();
            var calculator = factory.GetChangeCalculator(9);

            Assert.IsTrue(calculator.GetType() == typeof(RandomChangeCalculator));
        }

    }
}
