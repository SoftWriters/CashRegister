
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegister
{
    [TestClass]
    public class CashRegisterTests
    {
        [TestMethod]
        public void RandomChange()
        {
            CashRegister cr = new CashRegister();
            Change actualChange = cr.GetChange(3.33M);
            decimal actualTotal = GetTotal(actualChange);
            decimal expectedTotal = 3.33M;
            Assert.AreEqual(expectedTotal, actualTotal, "Unequal Total");
        }

        private decimal GetTotal(Change change)
        {
            decimal total = 0;

            total += change.Dollar * 1.00M;
            total += change.Quarter * 0.25M;
            total += change.Dime * 0.10M;
            total += change.Nickel * 0.05M;
            total += change.Penny * 0.01M;

            return total;
        }
        
        [TestMethod]
        public void Return1Dollar()
        {
            CashRegister cr = new CashRegister();
            Change actual = cr.GetChange(1.00M);
            Change expected = new Change();
            expected.AddDollar();

            CompareChangeObject(expected, actual);
        }

        private void CompareChangeObject(Change expectedChange, Change actualChange)
        {
            Assert.AreEqual(expectedChange.Dollar, actualChange.Dollar, "Unequal Dollars");
            Assert.AreEqual(expectedChange.Quarter, actualChange.Quarter, "Unequal Quarters");
            Assert.AreEqual(expectedChange.Dime, actualChange.Dime, "Unequal Dimes");
            Assert.AreEqual(expectedChange.Nickel, actualChange.Nickel, "Unequal Nickels");
            Assert.AreEqual(expectedChange.Penny, actualChange.Penny, "Unequal Pennies");
        }

        //[TestMethod]
        //public void Return1Dollar1Quarter()
        //{
        //    CashRegister cr = new CashRegister();
        //    int[] actual = cr.GetChange(1.25M);
        //    int[] expected = { 1, 1, 0, 0, 0 };
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Return1Dollar1Quarter1Dime()
        //{
        //    CashRegister cr = new CashRegister();
        //    int[] actual = cr.GetChange(1.35M);
        //    int[] expected = { 1, 1, 1, 0, 0 };
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Return1Dollar1Quarter1Dime1Nickel()
        //{
        //    CashRegister cr = new CashRegister();
        //    int[] actual = cr.GetChange(1.40M);
        //    int[] expected = { 1, 1, 1, 1, 0 };
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Return1Dollar1Quater1Dime1Nickel4Pennies()
        //{
        //    CashRegister cr = new CashRegister();
        //    int[] actual = cr.GetChange(1.44M);
        //    int[] expected = { 1, 1, 1, 1, 4 };
        //    CollectionAssert.AreEqual(expected, actual);
        //}

    }
}
