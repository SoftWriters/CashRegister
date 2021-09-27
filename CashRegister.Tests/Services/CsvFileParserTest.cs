using System.Collections.Generic;
using System.IO;
using CashRegister.Models;
using CashRegister.Services;
using NUnit.Framework;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class CsvFileParserTest
    {
        private CsvFileParser uut;
        private Stream stream;

        public CsvFileParserTest()
        {
            uut = new CsvFileParser();
        }

        [SetUp]
        public void SetUpTests()
        {
            stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\testData.txt");
        }

        [Test]
        public void CsvParser_Should_ReturnTheExpectedListOfResults()
        {
            var expectedList = new List<CashRegisterTransaction>()
            {
                new CashRegisterTransaction() { costDue = 2.12m, paid = 3.00m},
                new CashRegisterTransaction() { costDue = 1.97m, paid = 2.00m},
                new CashRegisterTransaction() { costDue = 3.33m, paid = 5.00m},
            };

            var results = uut.ParseCsvFile(stream);

            // Iterate through each item in the list and Assert it was found in our exppected results
            results.ForEach(res =>
            {
                var foundIdx = expectedList.FindIndex(transaction => transaction.costDue == res.costDue && transaction.paid == res.paid);
                Assert.True(foundIdx > -1);
            });
        }
        
    }
}