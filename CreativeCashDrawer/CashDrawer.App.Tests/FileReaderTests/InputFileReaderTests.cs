using CashDrawer.App.FileReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.App.Tests.FileReaderTests
{
    [TestClass]
    public class InputFileReaderTests
    {

        [TestMethod]
        public void file_reader_reads_input_from_a_file()
        {
            var filename = @"FileReaderTests\InputFileReaderData.txt";

            var reader = new InputFileReader(filename, new LineParser());

            Assert.IsTrue(reader.HaveMore);
            var line = reader.Next();
            Assert.IsFalse(line.HasError);
            Assert.AreEqual(1.00m, line.Due);
            Assert.AreEqual(2.00m, line.Paid);

            Assert.IsTrue(reader.HaveMore);
            line = reader.Next();
            Assert.IsFalse(line.HasError);
            Assert.AreEqual(3.00m, line.Due);
            Assert.AreEqual(4.00m, line.Paid);

            Assert.IsTrue(reader.HaveMore);
            line = reader.Next();
            Assert.IsFalse(line.HasError);
            Assert.AreEqual(5.00m, line.Due);
            Assert.AreEqual(6.00m, line.Paid);

            Assert.IsFalse(reader.HaveMore);
        }

    }
}
