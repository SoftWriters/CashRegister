using CashDrawer.Core.ChangeCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.Core.Tests.ChangeCalculators
{
    [TestClass]
    public class StandardChangeCalculatorTests
    {

        [TestMethod]
        [DataRow("0.00", "0.00", 0, 0, 0, 0, 0)]
        [DataRow("1.00", "2.00", 1, 0, 0, 0, 0)]
        [DataRow("0.75", "1.00", 0, 1, 0, 0, 0)]
        [DataRow("0.90", "1.00", 0, 0, 1, 0, 0)]
        [DataRow("0.95", "1.00", 0, 0, 0, 1, 0)]
        [DataRow("0.99", "1.00", 0, 0, 0, 0, 1)]
        [DataRow("0.01", "3.00", 2, 3, 2, 0, 4)]
        [DataRow("2.12", "3.00", 0, 3, 1, 0, 3)]
        [DataRow("1.97", "2.00", 0, 0, 0, 0, 3)]
        public void standard_calculator_returns_correct_change(string dueString,
                                                               string paidString,
                                                               int expectedDollars,
                                                               int expectedQuarters,
                                                               int expectedDimes,
                                                               int expectedNickles,
                                                               int expectedPennies)
        {
            var due = decimal.Parse(dueString);
            var paid = decimal.Parse(paidString);

            var calulator = new StandardChangeCalculator();
            var change = calulator.GetChange(due, paid);

            Assert.AreEqual(expectedDollars, change.Dollars);
            Assert.AreEqual(expectedQuarters, change.Quarters);
            Assert.AreEqual(expectedDimes, change.Dimes);
            Assert.AreEqual(expectedNickles, change.Nickles);
            Assert.AreEqual(expectedPennies, change.Pennies);

        }

    }
}
