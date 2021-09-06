using CashDrawer.Core.ChangeCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CashDrawer.Core.Tests.ChangeCalculators
{
    [TestClass]
    public class RandomChangeCalculatorTests
    {

        [TestMethod]
        public void random_calculator_returns_correct_change()
        {
            var calculator = new RandomChangeCalculator(new Random());

            for(var i=0; i < 10000; i++)
            {
                var change = calculator.GetChange(due: 0.03m, paid: 10.00m);
                Assert.AreEqual(997, ToPennies(change));
            }
        }


        [TestMethod]
        public void random_calculator_produces_random_result()
        {
            var random = new Random(100);  // seed 100 produces sequence 9 0 6 7 5

            var calculator = new RandomChangeCalculator(random);
            var change = calculator.GetChange(due: 2.00m, paid: 12.00m);

            Assert.AreEqual(9, change.Dollars);
            Assert.AreEqual(0, change.Quarters);
            Assert.AreEqual(6, change.Dimes);
            Assert.AreEqual(7, change.Nickles);
            Assert.AreEqual(5, change.Pennies);
        }


        private int ToPennies(Change change)
        {
            return
                change.Dollars * 100 +
                change.Quarters * 25 +
                change.Dimes * 10 +
                change.Nickles * 5 +
                change.Pennies;
        }

    }
}
