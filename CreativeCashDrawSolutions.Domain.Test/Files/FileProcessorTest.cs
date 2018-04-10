using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using CreativeCashDrawSolutions.Domain.Files;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Files
{
    public class FileProcessorTest
    {
        [Fact]
        public void TestFileSystemRead()
        {
            const string filePath = @"c:\input.txt";
            var expected = new StringBuilder();
            expected.AppendLine("2.12,3.00");
            expected.AppendLine("1.97,2.00");

            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { filePath, new MockFileData(expected.ToString()) }
            });

            var component = new FileProcessor(fileSystem);

            var files = component.ImportTransactions(filePath);
            Assert.NotNull(files);
            var actual = new StringBuilder();
            foreach (var file in files)
            {
                actual.AppendLine(file);
            }
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void TestFileSystemWrite()
        {
            const string filePath = @"c:\output.txt";
            var expected = new List<string> {"3 quarters,1 dime,3 pennies", "3 pennies"};

            var fileSystem = new MockFileSystem();

            var component = new FileProcessor(fileSystem);

            component.WriteTransactions(filePath, expected);

            var actual = component.ImportTransactions(filePath);
            Assert.NotEqual(0, actual.Count);

            Assert.Equal(expected, actual);
        }
    }
}
