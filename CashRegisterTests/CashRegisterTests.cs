
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegister
{
    [TestClass]
    public class CashRegisterTests
    {
        [TestMethod]
        public void Return1Dollar()
        {
            CashRegister cr = new CashRegister();
            int[] actual = cr.GetChange(1.00M);
            int[] expected = { 1, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Return1Dollar1Quarter()
        {
            CashRegister cr = new CashRegister();
            int[] actual = cr.GetChange(1.25M);
            int[] expected = { 1, 1, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Return1Dollar1Quarter1Dime()
        {
            CashRegister cr = new CashRegister();
            int[] actual = cr.GetChange(1.35M);
            int[] expected = { 1, 1, 1, 0, 0 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Return1Dollar1Quarter1Dime1Nickel()
        {
            CashRegister cr = new CashRegister();
            int[] actual = cr.GetChange(1.40M);
            int[] expected = { 1, 1, 1, 1, 0 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Return1Dollar1Quater1Dime1Nickel4Pennies()
        {
            CashRegister cr = new CashRegister();
            int[] actual = cr.GetChange(1.44M);
            int[] expected = { 1, 1, 1, 1, 4 };
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
