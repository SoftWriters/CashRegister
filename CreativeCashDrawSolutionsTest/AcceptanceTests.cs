using Xunit;

namespace CreativeCashDrawSolutions.CreativeCashDrawSolutionsTest
{
    // The goal of this test class is to support some basic acceptance tests that were gathered throughout the problem description. This file
    // will likely be changed to reflect progress throughout development. 

    // TODO: Naming schema for tests defined
    public class AcceptanceTests
    {
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
