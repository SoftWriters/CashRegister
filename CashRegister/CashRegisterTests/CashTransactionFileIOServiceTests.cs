using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class CashTransactionFileIOServiceTests
    {
        // CashTransactionFileIOServiceTests.HasLessThanThreeDecimalPlaces() tests.
        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_Zero_ReturnsTrue()
        {
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            Assert.IsTrue(ctfios.HasLessThanThreeDecimalPlaces(0m));
        }

        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_One_ReturnsTrue()
        {
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            Assert.IsTrue(ctfios.HasLessThanThreeDecimalPlaces(1m));
        }

        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_OnePointFive_ReturnsTrue()
        {
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            Assert.IsTrue(ctfios.HasLessThanThreeDecimalPlaces(1.5m));
        }

        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_OnePointSixNine_ReturnsTrue()
        {
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            Assert.IsTrue(ctfios.HasLessThanThreeDecimalPlaces(1.69m));
        }

        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_OnePointFourFiveThree_ReturnsFalse()
        {
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            Assert.IsFalse(ctfios.HasLessThanThreeDecimalPlaces(1.453m));
        }

        [TestMethod]
        public void HasLessThanThreeDecimalPlaces_ZeroPointOneOneOne_ReturnsFalse_AsDoSubsequentValuesAfterDivindingBySevenInALoopOfTen()
        {
            decimal input = 0.111m;
            decimal divisor = 7;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();
            for (int i = 0; i < 10; ++i)
            {
                if (i > 0)
                {
                    input /= divisor;
                }
                Assert.IsFalse(ctfios.HasLessThanThreeDecimalPlaces(input));
            }
        }

        // CashTransactionFileIOServiceTests.ConvertToPenniesFrom_ZeroDollars() tests.
        [TestMethod]
        public void ConvertToPenniesFrom_ZeroDollars_ReturnsZeroCents()
        {
            decimal input = 0m;
            int expected = 0;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();

            Assert.AreEqual(expected, ctfios.ConvertToPenniesFrom(input));
        }

        [TestMethod]
        public void ConvertToPenniesFrom_ZeroDollarsAndTwoCents_ReturnsTwoCents()
        {
            decimal input = 0.02m;
            int expected = 2;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();

            Assert.AreEqual(expected, ctfios.ConvertToPenniesFrom(input));
        }

        [TestMethod]
        public void ConvertToPenniesFrom_ZeroDollarsAndThirtyCents_ReturnsThirtyCents()
        {
            decimal input = 0.3m;
            int expected = 30;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();

            Assert.AreEqual(expected, ctfios.ConvertToPenniesFrom(input));
        }

        [TestMethod]
        public void ConvertToPenniesFrom_FiveHundredTwentyThreeDollarsAndTwentyCents_ReturnsFiftyTwoThousandThreeHundredTwentyCents()
        {
            decimal input = 523.2m;
            int expected = 52320;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();

            Assert.AreEqual(expected, ctfios.ConvertToPenniesFrom(input));
        }

        [TestMethod]
        public void ConvertToPenniesFrom_FourtyTwoDollarsAndZeroCents_ReturnsFourThousandTwoHunderedCents()
        {
            decimal input = 42m;
            int expected = 4200;
            CashTransactionFileIOService ctfios = new CashTransactionFileIOService();

            Assert.AreEqual(expected, ctfios.ConvertToPenniesFrom(input));
        }
    }
}
