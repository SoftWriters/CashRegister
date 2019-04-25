using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cash;

namespace RegisterTest
{
    [TestClass]
    public class CurrencyTest //TODO : add tests for invalid input and file format
    {
        [TestMethod]
        public void usd_test_dollar()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double dollar = 1.0,
                   delta  = .001;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(0).value, dollar, delta);
        }

        [TestMethod]
        public void usd_test_quarter()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double quarter = .25,
                   delta   = .001;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(1).value, quarter, delta);
        }

        [TestMethod]
        public void usd_test_dime()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double dime  = .10,
                   delta = .001;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(2).value, dime, delta);
        }

        [TestMethod]
        public void usd_test_nickel()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double nickel = .05,
                   delta = .001;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(3).value, nickel, delta);
        }

        [TestMethod]
        public void usd_test_penny()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double penny = .01,
                   delta = .001;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(4).value, penny, delta);
        }

        [TestMethod]
        public void transaction_test_standard()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double bill        = 2.12,
                   payment     = 3.00,
                   difference  = .88,
                   delta       = .001;
            double change = 0;
            Transaction transaction = new Transaction(bill, payment, currency);
            
            //act
            foreach (Change c in transaction.get_change_list())
            {
                change += c.count * c.value;
            }

            //assert
            Assert.AreEqual(change, difference, delta);
        }

        [TestMethod]
        public void transaction_test_alt()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double bill       = 1.97,
                   payment    = 2.00,
                   difference = .03,
                   delta      = .001;
            double change = 0;
            Transaction transaction = new Transaction(bill, payment, currency);

            //act
            foreach (Change c in transaction.get_change_list())
            {
                change += c.count * c.value;
            }

            //assert
            Assert.AreEqual(change, difference, delta);
        }

        [TestMethod]
        public void transaction_test_random()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double bill       = 3.33,
                   payment    = 5.00,
                   difference = 1.67,
                   delta      = .001;
            double change = 0;
            Transaction transaction = new Transaction(bill, payment, currency);

            //act
            foreach (Change c in transaction.get_change_list())
            {
                change += c.count * c.value;
            }

            //assert
            Assert.AreEqual(change, difference, delta);
        }

        [TestMethod]
        public void transaction_test_exact()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double bill = 3.00,
                   payment = 3.00,
                   difference = 0,
                   delta = .001;
            double change = 0;
            Transaction transaction = new Transaction(bill, payment, currency);

            //act
            try //currently should fail as get list will return null
            {
                foreach (Change c in transaction.get_change_list())
                {
                    change += c.count * c.value;
                }
            }
            catch
            {

            }

            //assert
            Assert.AreEqual(change, difference, delta);
            Assert.AreEqual(transaction.exact, true);
        }

        [TestMethod]
        public void transaction_test_failure()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double bill = 4.00,
                   payment = 3.00,
                   difference = 0,
                   delta = .001;
            double change = 0;
            Transaction transaction = new Transaction(bill, payment, currency);

            //act
            try //currently should fail as get list will return null
            {
                foreach (Change c in transaction.get_change_list())
                {
                    change += c.count * c.value;
                }
            }
            catch
            {

            }

            //assert
            Assert.AreEqual(transaction.failure, true);
        }
    }
}
