using System;
using System.Text;
using System.Collections.Generic;
using CashMachine.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicConsoleAppTests.DomainTests
{
    /// <summary>
    /// Summary description for MoneyTests
    /// </summary>
    [TestClass]
    public class when_creating_our_money : With<Money>
    {
        private Money _money;
         
        [TestInitialize]
        public void Arrange()
        {
            _money = Mocks.ClassUnderTest;
        }

        [TestMethod]
        public void it_should_create_dollar()
        {
            Assert.AreEqual(Money.Dollar.Value, 1M);
            Assert.AreEqual(Money.Dollar.Name, "dollar");
            Assert.AreEqual(Money.Dollar.PuralName, "dollars");
        }

        [TestMethod]
        public void it_should_create_quarter()
        {
            Assert.AreEqual(Money.Quarter.Value, 0.25M);
            Assert.AreEqual(Money.Quarter.Name, "quarter");
            Assert.AreEqual(Money.Quarter.PuralName, "quarters");
        }

        [TestMethod]
        public void it_should_create_dime()
        {
            Assert.AreEqual(Money.Dime.Value, 0.10M);
            Assert.AreEqual(Money.Dime.Name, "dime");
            Assert.AreEqual(Money.Dime.PuralName, "dimes");
        }

        [TestMethod]
        public void it_should_create_nickel()
        {
            Assert.AreEqual(Money.Nickel.Value, 0.05M);
            Assert.AreEqual(Money.Nickel.Name, "nickel");
            Assert.AreEqual(Money.Nickel.PuralName, "nickels");
        }

        [TestMethod]
        public void it_should_create_penny()
        {
            Assert.AreEqual(Money.Penny.Value, 0.01M);
            Assert.AreEqual(Money.Penny.Name, "penny");
            Assert.AreEqual(Money.Penny.PuralName, "pennies");
        }

        [TestMethod]
        public void it_should_display_singularly()
        {
            Assert.AreEqual(Money.Penny.ToString(1), "1 penny");
        }

        [TestMethod]
        public void it_should_display_purally()
        {
            Assert.AreEqual(Money.Penny.ToString(2), "2 pennies");
        }

        [TestMethod]
        public void it_should_setup_the_decreasing_list()
        {
            Assert.AreEqual(_money.DecreasingValueCurrency[0].Value,Money.Dollar.Value);
            Assert.AreEqual(_money.DecreasingValueCurrency[1].Value, Money.Quarter.Value);
            Assert.AreEqual(_money.DecreasingValueCurrency[2].Value, Money.Dime.Value);
            Assert.AreEqual(_money.DecreasingValueCurrency[3].Value, Money.Nickel.Value);
            Assert.AreEqual(_money.DecreasingValueCurrency[4].Value, Money.Penny.Value);
        }
    }
}
