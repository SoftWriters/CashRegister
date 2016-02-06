using CashMachine.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicConsoleAppTests.DomainTests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class when_parsing_cost_and_payment
    {
        [TestMethod]
        public void it_should_handle_the_happy_path()
        {
            var purchase = new Purchase("2.00,3.00");
            Assert.AreEqual(purchase.Payment,3M);
            Assert.AreEqual(purchase.ItemCost, 2M);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void it_should_handle_not_enough_money_exception()
        {
            new Purchase("3.00,2.00,");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void it_should_handle_bad_item_cost()
        {
            new Purchase("2.00,a");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void it_should_handle_bad_item_payment()
        {
            new Purchase("a, 0.0");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void it_should_handle_a_negative_item_payment()
        {
            new Purchase("2.00,-3.00");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void it_should_handle_a_negative_item_cost()
        {
            new Purchase("-2.00,3.00");
        }

        [TestMethod]
        public void it_should_display_the_object()
        {
            var purchase = new Purchase("2.00,3.00");
            Assert.AreEqual(purchase.ToString(),"P:3.00,C:2.00");
        }
    }
}
