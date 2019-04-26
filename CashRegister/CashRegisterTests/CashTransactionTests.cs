using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    /// <summary>
    /// Summary description for CashTransactionTests
    /// </summary>
    [TestClass]
    public class CashTransactionTests
    {
        CashTransaction TestTrasaction;

        public CashTransactionTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        
         //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestTrasaction = new CashTransaction(0, 0);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetChangeAsString_WithOneOfEachDenominationDescendingOrder()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations,int>()
            {
                {CashDenominations.Dollars, 1},
                {CashDenominations.Quarters, 1},
                {CashDenominations.Dimes, 1},
                {CashDenominations.Nickels, 1},
                {CashDenominations.Pennies, 1}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 dollar,1 quarter,1 dime,1 nickel,1 penny";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOneOfEachDenominationAscendingOrder()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Pennies, 1},
                {CashDenominations.Nickels, 1},
                {CashDenominations.Dimes, 1},
                {CashDenominations.Quarters, 1},
                {CashDenominations.Dollars, 1}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 dollar,1 quarter,1 dime,1 nickel,1 penny";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithTwoOfEachDenominationAscendingOrder()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Pennies, 2},
                {CashDenominations.Nickels, 2},
                {CashDenominations.Dimes, 2},
                {CashDenominations.Quarters, 2},
                {CashDenominations.Dollars, 2}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "2 dollars,2 quarters,2 dimes,2 nickels,2 pennies";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithAVarietyOfAmountsForEachDenomination()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Nickels, 56},
                {CashDenominations.Dollars, 20005},
                {CashDenominations.Quarters, 2},
                {CashDenominations.Dimes, 1003},
                {CashDenominations.Pennies, 235}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "20005 dollars,2 quarters,1003 dimes,56 nickels,235 pennies";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithAVarietyOfAmountsForSomeDenominations()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 56},
                {CashDenominations.Pennies, 1},
                {CashDenominations.Quarters, 2},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "56 dollars,2 quarters,1 penny";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithNoChange()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOnePenny()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 1},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 penny";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithMultiplePennies()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 35},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "35 pennies";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOneNickel()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 1}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 nickel";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithMultipleNickels()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 308}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "308 nickels";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOneDime()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 1},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 dime";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithMultipleDimes()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 50000},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "50000 dimes";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOneQuarter()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 1},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 quarter";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithMultipleQuarters()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 23},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "23 quarters";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithOneDollar()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 1},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "1 dollar";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }

        [TestMethod]
        public void GetChangeAsString_WithMultipleDollars()
        {
            Dictionary<CashDenominations, int> input = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 4078},
                {CashDenominations.Pennies, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0}
            };
            TestTrasaction.SetChangeDenominationCount(input);

            string expected = "4078 dollars";

            Assert.AreEqual(expected, TestTrasaction.GetChangeAsString());
        }
    }
}
