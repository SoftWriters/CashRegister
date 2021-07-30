using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChangeTranslator.Tests
{
    [TestClass]
    public class CsvTranslatorTests
    {
        [TestMethod]
        public void Translate_FullRun_RunsWithoutException()
        {
            // Arrange
            // Act
            new CsvTranslator().Translate("../../TestObjects/TestCsv.txt", "../../TestObjects/OutputCsv.txt");

            // Assert
        }

        [TestMethod]
        public void CsvToDtos_GoodCsvFile_ReturnsTransactions()
        {
            // Arrange
            // Act
            var result = new CsvTranslator().CsvToDtos("../../TestObjects/TestCsv.txt").ToList();

            // Assert
            Assert.AreEqual((decimal) 2.12, result[0].Cost);
            Assert.AreEqual(5, result[2].Paid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CsvToDtos_BadCsvFile_ReturnsTransactions()
        {
            // Arrange
            // Act
            new CsvTranslator().CsvToDtos("../../TestObjects/BadCsv.txt");
        }
    }
}
