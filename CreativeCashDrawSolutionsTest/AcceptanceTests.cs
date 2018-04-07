using Xunit;

namespace CreativeCashDrawSolutionsTest
{
    // The goal of this test class is to support some basic acceptance tests that were gathered throughout the problem description. This file
    // will likely be changed to reflect progress throughout development. 

    // TODO: Naming schema for tests defined
    public class AcceptanceTests
    {
        [Fact]
        public void EnsureTheDenominationsAreOrdered()
        {
            // This test will check that the implemented denominations are ordered correctly.
        }

        [Theory]
        [InlineData("2.12", "3.00")]
        [InlineData("1.97", "2.00")]
        public void VerifyChangeIsCorrect(string input, string expectedOutput)
        {
            // This test is responsible for taking predictable input values and returning the output values
        }

        [Fact]
        public void VerifyRandomChangeIsCorrect()
        {
            // This test is responsible for taking the random change that is returned and verifying its correctness
            // 3.33,5.00
        }

        [Fact]
        public void WhenNoDenominationsExistToComplete_ThrowsException()
        {
            // In the event a denomination amount cannot be completed to give the change, throw an exception
            // ie. we need provide 3 back and the smallest demo. is 5
        }

        [Fact]
        public void EnsureThatTheLeastAmountOfCoinsAreReturned()
        {
            // Ensure that if the coin denominations were 1, 3 and 4, then to make 6 we would use 3 and 3 and not 4, 1, 1
        }

        [Fact]
        public void EnsureThatTheLeastAmountOfCoinsReturnedWithTheLargestOneBeingUsed()
        {
            // If we had a two possible sets that were considered the minimum amounts, we should use the one with the highest coins
        }

        [Fact]
        public void EnsureThatAcceptedFileTypesAreAllowed()
        {
            // Allowed file types of csv and txt are accepted
        }

        [Fact]
        public void InvalidFileTypeThrowsException()
        {
            // File type not accepted throws exception
        }

        [Fact]
        public void FileNotAccessibleThrowsException()
        {
            // If the file cannot be accessed an exception is thrown
        }

        [Fact]
        public void EnsureInputHasTwoItemsSeperatedByComma()
        {
            // Ensure that the input is on a line and seperated by a comma
        }

        [Fact]
        public void EnsureLineIsInProperFormat()
        {
            // Input should be two numbers that can go in a double or decimal
        }

        [Fact]
        public void ReturnExceptionIfNotInProperFormat()
        {
            // If format is bad throws exception
        }

        [Fact]
        public void InputFileContainsAtLeastOneLine()
        {
            // Make sure that we are checking for at least one line in the file
        }

        [Fact]
        public void ThrowExceptionIfNoLinesInInputFile()
        {
            // If there are no lines we should throw an exception
        }

        [Fact]
        public void EnsureOutputFileIsGenerated()
        {
            // Make that an output file can be generated to disk
        }

        [Fact]
        public void ThrowExceptionIfOutputFileCannotBeWritten()
        {
            // Throw exception if output file cannot be written
        }

        [Fact]
        public void EnsureStringIsWrittenToFile()
        {
            // Verify that the output can actually be written
        }

        [Fact]
        public void ThrowExceptionIfStringCannotBeWritten()
        {
            // If the file cannot be updated with the output, throw exception
        }

        [Fact]
        public void VerifyCountOfInputLinesEqualsOutputLines()
        {
            // If the line counts of the input and output do not match, throw exception
        }

        [Fact]
        public void EnsureThatWhenOneItemReturnedItIsSingular()
        {
            // 1 quarter should not be plural
        }

        [Fact]
        public void EnsureThatWhenMultipleItemsReturnedItIsPlural()
        {
            // 3 quarters should not be singular
        }

        [Fact]
        public void EnsureReturnStatementsAreseperatedByCommas()
        {
            // 3 quarters,1 dime,3 pennies
        }

        [Fact]
        public void EnsureReturnStatementsDoesNotHaveTrailingComma()
        {
            // A comma at the end would be incorrect ie. 3 quarters,1 dime,3 pennies,
        }
    }
}
