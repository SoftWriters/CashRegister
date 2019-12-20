using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CashRegisterLib.Tests
{
    [TestClass]
    public class CashierTests
    {
        private Cashier cashier;

        [TestInitialize]
        public void SetUp()
        {
            cashier = new Cashier();
        }

        [TestMethod]
        public void WhenPaidEqualsTotal()
        {
            var results = cashier.GetChange(1.56m, 1.56m);
            Assert.AreEqual("Exact change. Nothing to be returned.", results);
        }

        [TestMethod]
        public void WhenPaidIsLessThanTotal()
        {
            try
            {
                cashier.GetChange(2, 1);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
                Assert.AreEqual("Please pay more. Paid amount is less than the total amount.", ex.Message);
                return;
            }

            Assert.Fail("Exception was expected");
        }

        [TestMethod]
        public void WhenChangeIsOnePenny()
        {
            var results = cashier.GetChange(1.99m, 2);
            Assert.AreEqual("1 penny", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoPennies()
        {
            var results = cashier.GetChange(2.98m, 3);
            Assert.AreEqual("2 pennies", results);
        }

        [TestMethod]
        public void WhenChangeIsOneNickel()
        {
            var results = cashier.GetChange(2.95m, 3);
            Assert.AreEqual("1 nickel", results);
        }

        [TestMethod]
        public void WhenChangeIsOneDime()
        {
            var results = cashier.GetChange(1.90m, 2);
            Assert.AreEqual("1 dime", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoDimes()
        {
            var results = cashier.GetChange(2.80m, 3);
            Assert.AreEqual("2 dimes", results);
        }

        [TestMethod]
        public void WhenChangeIsOneQuarter()
        {
            var results = cashier.GetChange(1.75m, 2);
            Assert.AreEqual("1 quarter", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoQuarter()
        {
            var results = cashier.GetChange(1.51m, 2.01m);
            Assert.AreEqual("2 quarters", results);
        }

        [TestMethod]
        public void WhenChangeIsOneDollar()
        {
            var results = cashier.GetChange(1.00m, 2);
            Assert.AreEqual("1 dollar", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoDollars()
        {
            var results = cashier.GetChange(1.00m, 3);
            Assert.AreEqual("2 dollars", results);
        }

        [TestMethod]
        public void WhenChangeIsOneFive()
        {
            var results = cashier.GetChange(10.00m, 15.0m);
            Assert.AreEqual("1 five", results);
        }

        [TestMethod]
        public void WhenChangeIsOneTen()
        {
            var results = cashier.GetChange(10.00m, 20);
            Assert.AreEqual("1 ten", results);
        }

        [TestMethod]
        public void WhenChangeIsOneTwenty()
        {
            var results = cashier.GetChange(80.00m, 100);
            Assert.AreEqual("1 twenty", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoTwenties()
        {
            var results = cashier.GetChange(70.00m, 110);
            Assert.AreEqual("2 twenties", results);
        }


        [TestMethod]
        public void WhenChangeIsOneFifty()
        {
            var results = cashier.GetChange(50.00m, 100);
            Assert.AreEqual("1 fifty", results);
        }


        [TestMethod]
        public void WhenChangeIsOneHunder()
        {
            var results = cashier.GetChange(100.00m, 200);
            Assert.AreEqual("1 hundred", results);
        }

        [TestMethod]
        public void WhenChangeIsTwoHunder()
        {
            var results = cashier.GetChange(100.00m, 300);
            Assert.AreEqual("2 hundreds", results);
        }

        [TestMethod]
        public void WhenChangeIs3Quarters1DimeAnd3Pennies()
        {
            var results = cashier.GetChange(2.12m, 3.00m);
            Assert.AreEqual("3 quarters,1 dime,3 pennies", results);
        }

        [TestMethod]
        public void WhenChangeIs3Pennies()
        {
            var results = cashier.GetChange(1.97m, 2.00m);
            Assert.AreEqual("3 pennies", results);
        }

        [TestMethod]
        public void WhenTotalIsDivisiableBy3()
        {
            var results = cashier.GetChange(3.33m, 5.00m);
            Assert.AreNotEqual("Exact change. Nothing to be returned.", results);
        }

        [TestMethod]
        public void WhenMaxChangeAllowed()
        {
            var results = cashier.GetChange(0.01m, 21474836.48m);
            Assert.AreNotEqual("Exact change. Nothing to be returned.", results);
        }


        [TestMethod]
        public void WhenOverMaxChangeAllowed()
        {
            try
            {
                cashier.GetChange(0.01m, 21474836.49m);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
                Assert.AreEqual("Change amount is too large to be calculated. Must be less than or equal to 21474836.47.", ex.Message);
                return;
            }

            Assert.Fail("Exception was expected");
        }

        [TestMethod]
        public void WhenTotalIsNegative()
        {
            try
            {
                cashier.GetChange(-0.01m, 16.49m);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
                Assert.AreEqual("Total amount should be a positive amount.", ex.Message);
                return;
            }

            Assert.Fail("Exception was expected");
        }

        [TestMethod]
        public void WhenPaidIsNegative()
        {
            try
            {
                cashier.GetChange(0.01m, -16.49m);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
                Assert.AreEqual("Paid amount should be a positive amount.", ex.Message);
                return;
            }

            Assert.Fail("Exception was expected");
        }
    }
}
