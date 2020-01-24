using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.BL;

namespace UnitTests
{
    /// <summary>
    /// Unit Test Coverage for Utilities Class
    /// </summary>
    [TestClass]
    public class UtilitiesTests
    {
        private readonly Utilities _ut = new Utilities();

        #region Generate Denominations Dictionary

        [TestMethod]
        public void Utilities_GenerateDenominationsDictionary_Success()
        {
            // Arrange
            var expectedDictionary = new Dictionary<string, decimal>
                {
                    {"Twenty Dollar Bill", 20.00m},
                    {"Ten Dollar Bill", 10.00m},
                    {"Five Dollar Bill", 5.00m},
                    {"One Dollar Bill", 1.00m},
                    {"Quarter", .25m},
                    {"Dime", .10m},
                    {"Nickel", .05m},
                    {"Penny", .01m}
                };

            // Act
            var actualDictionary = _ut.GenerateDenominationsDictionary();

            // Assert
            CollectionAssert.AreEqual(expectedDictionary, actualDictionary, "GenerateDenominationDictionary_Success");
        }

        [TestMethod]
        public void Utilities_GenerateDenominationsDictionary_NonEqualDictionaryTest_Success()
        {
            // Arrange
            var expectedDictionary = new Dictionary<string, decimal>
                {
                    {"Twenty Dollar Bill", 20.00m},
                    {"Dime", .10m},
                    {"Nickel", .05m},
                    {"Penny", .01m}
                };

            // Act
            var actualDictionary = _ut.GenerateDenominationsDictionary();

            // Assert
            CollectionAssert.AreNotEqual(expectedDictionary, actualDictionary, "GenerateDenominationDictionary_NonEqualDictionaryTest_Success");
        }

        #endregion Generate Denominations Dictionary

        #region Randomize Cash Dictionary

        [TestMethod]
        public void Utilities_RandomizeCashDictionary_Success()
        {
            // Arrange
            var nonRandomizedDictionary = new Dictionary<string, decimal>
                {
                    {"Twenty Dollar Bill", 20.00m},
                    {"Ten Dollar Bill", 10.00m},
                    {"Five Dollar Bill", 5.00m},
                    {"One Dollar Bill", 1.00m},
                    {"Quarter", .25m},
                    {"Dime", .10m},
                    {"Nickel", .05m},
                    {"Penny", .01m}
                };

            // Act
            var randomizedDictionary = _ut.RandomizeDenominationsDictionary(nonRandomizedDictionary);

            // Assert
            CollectionAssert.AreNotEqual(nonRandomizedDictionary, randomizedDictionary, "RandomizedCashDictionary Success");
        }

        [TestMethod]
        public void Utilities_RandomizeCashDictionary_NullNonRandomizedDictionary_ArgumentNullException()
        {
            // Arrange - nothing needed
            // Act & Assert
            try
            {
                _ut.RandomizeDenominationsDictionary(null);
            }
            catch (ArgumentNullException a)
            {
                Assert.AreEqual("Value cannot be null.\r\nParameter name: source", a.Message, "RandomizeCashDictionary - ArgumentNullException");
            }
        }

        #endregion Randomize Cash Dictionary

        #region ReplaceWithPlurals

        [TestMethod]
        public void Utilities_ReplaceWithPlurals_Bill_Success()
        {
            // Arrange
            const string input = "Bill";
            const string expectedOutput = "Bills";

            // Act
            var actualOutput = _ut.ReplaceWithPlurals(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "ReplaceWithPlurals_Bill Success");
        }

        [TestMethod]
        public void Utilities_ReplaceWithPlurals_Quarter_Success()
        {
            // Arrange
            const string input = "Quarter";
            const string expectedOutput = "Quarters";

            // Act
            var actualOutput = _ut.ReplaceWithPlurals(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "ReplaceWithPlurals_Quarter Success");
        }

        [TestMethod]
        public void Utilities_ReplaceWithPlurals_Nickel_Success()
        {
            // Arrange
            const string input = "Nickel";
            const string expectedOutput = "Nickels";

            // Act
            var actualOutput = _ut.ReplaceWithPlurals(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "ReplaceWithPlurals_Nickel Success");
        }

        [TestMethod]
        public void Utilities_ReplaceWithPlurals_Dime_Success()
        {
            // Arrange
            const string input = "Dime";
            const string expectedOutput = "Dimes";

            // Act
            var actualOutput = _ut.ReplaceWithPlurals(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "ReplaceWithPlurals_Dime Success");
        }

        [TestMethod]
        public void Utilities_ReplaceWithPlurals_Penny_Success()
        {
            // Arrange
            const string input = "Penny";
            const string expectedOutput = "Pennies";

            // Act
            var actualOutput = _ut.ReplaceWithPlurals(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "ReplaceWithPlurals_Penny Success");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Utilities_ReplaceWithPlurals_EmptyString_IndexOutOfRangeException()
        {
            // Arrange
            const string input = "";

            // Act
            _ut.ReplaceWithPlurals(input);

            // Assert
            // Nothing to Assert. IndexOutOfRangeException will be caught
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Utilities_ReplaceWithPlurals_Null_NullReferenceException()
        {
            // Arrange
            const string input = null;

            // Act
            _ut.ReplaceWithPlurals(input);

            // Assert
            // Nothing to Assert. NullReferenceException will be caught
        }

        #endregion ReplaceWithPlurals
    }
}