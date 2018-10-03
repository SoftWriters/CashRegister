using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cash;

namespace RegisterTest
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void usd_test_constructor_no_flags()
        {
            //arrange
            USD currency = new USD(USD.NO_FLAGS);
            double penny   = .01,
                   nickel  = .05,
                   dime    = .10,
                   quarter = .25,
                   dollar  = 1.0;

            //act

            //assert
            Assert.AreEqual(currency.get_denomination(0), dollar);
        }
    }
}
