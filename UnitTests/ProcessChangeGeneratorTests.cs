using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.BL;

namespace UnitTests
{
    /// <summary>
    /// Unit Test Coverage For ProcessChangeGenerator Class
    /// </summary>
    [TestClass]
    public class ProcessChangeGeneratorTests
    {
        private readonly ProcessChangeGenerator _pcg = new ProcessChangeGenerator();
        private readonly Utilities _ut = new Utilities();
        private Dictionary<string, decimal> _nonRandomDictionary = new Dictionary<string, decimal>();
        private readonly List<string[]> _inputFileContents = new List<string[]>();

        #region TestInitialize

        [TestInitialize]
        public void Test_Initialize()
        {
            _nonRandomDictionary = new Dictionary<string, decimal>
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
        }

        #endregion TestInitialize

        #region Output Change To Customer

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_RecordIsValid_Success()
        {
            // Arrange
            var arr = new string[2];
            arr[0] = "1.60";  // Total amount due
            arr[1] = "3.00";  // Amount customer paid

            _inputFileContents.Add(arr);
            const string expectedOutput = "1 One Dollar Bill, 1 Quarter, 1 Dime, 1 Nickel\r\n";

            // Act
            var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "OutputChangeToCustomer_RecordIsValid_Success");
        }

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_InvalidTestDataOneString_Success()
        {
            // Arrange
            var arr = new string[1];
            arr[0] = "Invalid Test Data";

            _inputFileContents.Add(arr);
            const string expectedOutput = "Invalid Input\r\n";

            // Act
            var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "OutputChangeToCustomer_InvalidTestDataOneString");
        }

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_InvalidTestDataOneInteger_Success()
        {
            // Arrange
            var arr = new string[1];
            arr[0] = "35";

            _inputFileContents.Add(arr);
            const string expectedOutput = "Invalid Input\r\n";

            // Act
            var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "OutputChangeToCustomer_InvalidTestDataOneInteger");
        }

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_InvalidTestDataOneDecimal_Success()
        {
            // Arrange
            var arr = new string[1];
            arr[0] = "2.12";

            _inputFileContents.Add(arr);
            const string expectedOutput = "Invalid Input\r\n";

            // Act
            var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "OutputChangeToCustomer_InvalidTestDataOneDecimal");
        }

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_RecordIsValid_TotalCentsIsDivisibleByThree_Success()
        {
            // Arrange
            var arr = new string[2];
            arr[0] = "1.50";  // Total amount due
            arr[1] = "5.00";  // Amount customer paid

            // Change denominations will be random
            _inputFileContents.Add(arr);

            // Act & Assert
            try
            {
                var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);
                Assert.IsTrue(actualOutput.Length > 0, "OutputChangeToCustomer_RecordIsValid_TotalCentsIsDivisibleByThree");
            }
            catch (Exception ex)
            {
                // No exception expected
                Assert.Fail("No exception was expected, but the following exception was thrown: " + ex.Message);
            }
        }

        [TestMethod]
        public void ProcessChangeGenerator_OutputChangeToCustomer_TotalDueGreaterThanAmountPaid_RecordInvalid_Success()
        {
            // This test ensures that amount the customer paid cannot be less than the total due.
            // This would result in a refund, which the Cash Register does not perform.

            // Arrange
            var arr = new string[2];
            arr[0] = "6.00";  // Total amount due
            arr[1] = "2.00";  // Amount customer paid

            _inputFileContents.Add(arr);
            const string expectedOutput = "Invalid Input\r\n";

            // Act
            var actualOutput = _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "OutputChangeToCustomer_TotalDueGreaterThanAmountPaid_RecordInvalid");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ProcessChangeGenerator_OutputChangeToCustomer_NullInput_NullReferenceException()
        {
            // Arrange
            _inputFileContents.Add(null);

            // Act
            _pcg.OutputChangeToCustomer(_inputFileContents);

            // Assert - Nothing needed - NullReferenceException is expected
        }

        #endregion Output Change To Customer

        #region Get Monetary Denominations Due To Customer

        [TestMethod]
        public void ProcessChangeGenerator_GetMonetaryDenominationsDue_TotalCentsNotDivisibleByThree_Success()
        {
            // Arrange
            var denominationsDictionary = _nonRandomDictionary;
            var changeDue = Convert.ToDecimal(1.13);
            const bool isDivisibleByThree = false;
            const string expectedOutput = "1 One Dollar Bill, 1 Dime, 3 Pennies\r\n";

            // Act
            var actualOutput = _pcg.GetMonetaryDenominationsDue(denominationsDictionary, changeDue, isDivisibleByThree);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "GetMonetaryDenominationsDue_TotalCentsNotDivisibleByThree_Success");
        }

        [TestMethod]
        public void ProcessChangeGenerator_GetMonetaryDenominationsDue_TotalCentsIsDivisibleByThree_Success()
        {
            // Arrange
            var denominationsDictionary = _nonRandomDictionary;
            var changeDue = Convert.ToDecimal(3.33);
            const bool isDivisibleByThree = true;

            // Act
            // Randomize denominations dictionary
            var randomizedDictionary = _ut.RandomizeDenominationsDictionary(denominationsDictionary);

            // Since the output will be randomized I can't set an expected value. As long as no exception is caught, test succeeds.
            try
            {
                var actualOutput = _pcg.GetMonetaryDenominationsDue(randomizedDictionary, changeDue, isDivisibleByThree);
                Assert.IsTrue(actualOutput.Length > 0, "Data was returned when GetMonetaryDenominationsDue was called with randomized dictionary.");
            }
            catch (Exception ex)
            {
                // Assert - should not be thrown
                Assert.Fail("No exception was expected, but the following exception was thrown: " + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ProcessChangeGenerator_GetMonetaryDenominationsDue_NullDictionary_NullReferenceException()
        {
            // Arrange
            var changeDue = Convert.ToDecimal(1.25);
            const bool isDivisibleByThree = false;

            // Act & Assert - Expects NullReferenceException
            _pcg.GetMonetaryDenominationsDue(null, changeDue, isDivisibleByThree);
        }

        #endregion Get Monetary Denominations Due To Customer
    }
}