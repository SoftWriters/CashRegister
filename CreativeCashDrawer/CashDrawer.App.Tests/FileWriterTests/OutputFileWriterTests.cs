using CashDrawer.App.FileWriters;
using CashDrawer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CashDrawer.App.Tests.FileWriterTests
{
    [TestClass]
    public class OutputFileWriterTests
    {

        [TestMethod]
        public void file_writer_writes_change_to_a_file()
        {
            var filename = "FileWriterTest.txt";

            File.Delete(filename);

            var writer = new OutputFileWriter(filename, new Humanizer());

            var change1 = new Change(0, 1, 2, 3, 4);
            var change2 = new Change(5, 6, 7, 8, 9);
            writer.Write(change1);
            writer.Write(change2);

            var output = File.ReadAllLines(filename);

            Assert.AreEqual(2, output.Length);
            Assert.AreEqual("1 quarter, 2 dimes, 3 nickles, 4 pennies", output[0]);
            Assert.AreEqual("5 dollars, 6 quarters, 7 dimes, 8 nickles, 9 pennies", output[1]);
        }

    }
}
