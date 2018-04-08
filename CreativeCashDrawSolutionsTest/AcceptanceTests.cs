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
    }
}
