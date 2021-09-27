using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CashRegister.Controllers;
using CashRegister.Models;
using CashRegister.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CashRegister.Tests.Controllers
{
    [TestFixture]
    public class CashRegisterControllerTests
    {
        private readonly Mock<ILogger<CashRegisterController>> mockLogger;
        private Mock<ICsvFileParser> mockCsvParser;
        private Mock<IChangeCalculator> mockChangeCalculator;
        private Mock<IRandomChangeCalculator> mockRandomChangeCalculator;
        private CashRegisterController uut;
        private Stream memoryStream = new MemoryStream();
        private Mock<IFormFile> mockFormFile;

        private List<CashRegisterTransaction> expectedCashRegisterTransactions = new List<CashRegisterTransaction>()
        {
            new CashRegisterTransaction
            {
                costDue = 12.01m,
                paid = 12.50m
            },
            new CashRegisterTransaction
            {
                costDue = 3.33m,
                paid = 17.50m
            },
            new CashRegisterTransaction
            {
                costDue = 1.20m,
                paid = 2.00m
            }
        };

        public CashRegisterControllerTests()
        {

            mockLogger = new Mock<ILogger<CashRegisterController>>();
            mockCsvParser = new Mock<ICsvFileParser>();
            mockChangeCalculator = new Mock<IChangeCalculator>();
            mockRandomChangeCalculator = new Mock<IRandomChangeCalculator>();
            mockFormFile = new Mock<IFormFile>();

            uut = new CashRegisterController(mockLogger.Object, mockCsvParser.Object, mockChangeCalculator.Object, mockRandomChangeCalculator.Object);
        }

        [SetUp]
        public void SetUpTests()
        {
            mockFormFile.SetupGet(f => f.FileName).Returns("textData.csv");
            mockFormFile.Setup(f => f.OpenReadStream())
                .Returns(memoryStream);

            mockCsvParser.Setup(parser => parser.ParseCsvFile(It.IsAny<Stream>()))
                .Returns(expectedCashRegisterTransactions);
        }

        [TearDown]
        public void TearDownTests()
        {
            mockLogger.Reset();
            mockCsvParser.Reset();
            mockChangeCalculator.Reset();
            mockRandomChangeCalculator.Reset();
            mockFormFile.Reset();
        }


        [Test]
        public void CashRegisterController_Should_ReturnBadRequestOnNonValidFileTypes()
        {
            mockFormFile.SetupGet(f => f.FileName).Returns("textData.asdfadsf");

            var response = uut.Index(mockFormFile.Object);

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public void CashRegisterController_Should_ReturnBadRequestIfFileIsNull()
        {
            var response = uut.Index(null);

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public void CashRegisterController_Should_ReturnCallParseCsv()
        {
            var memoryStream = new MemoryStream();
            mockFormFile.Setup(f => f.OpenReadStream())
                .Returns(memoryStream);

            var response = uut.Index(mockFormFile.Object);

            mockCsvParser.Verify(parser => parser.ParseCsvFile(memoryStream), Times.Once);
        }

        [Test]
        public void CashRegisterController_Should_CallChangeCalculatorMethodsOnce_AndRandomChangeCalculatorMethodsTwice()
        {
            var response = uut.Index(mockFormFile.Object);

            mockChangeCalculator.Verify(calc => calc.CalculateChange(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
            mockChangeCalculator.Verify(calc => calc.DetermineChange(It.IsAny<decimal>()), Times.Once);

            mockRandomChangeCalculator.Verify(calc => calc.CalculateChange(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(2));
            mockRandomChangeCalculator.Verify(calc => calc.DetermineChange(It.IsAny<decimal>()), Times.Exactly(2));
        }

        [Test]
        public void CashRegisterController_Should_ReturnTheExpectedResponse()
        {
            var expectedTransactions = new List<CashRegisterTransaction>()
            {
                new CashRegisterTransaction
                {
                    costDue = 12.01m,
                    paid = 12.50m
                }
            };

            mockCsvParser.Setup(parser => parser.ParseCsvFile(It.IsAny<Stream>()))
                .Returns(expectedTransactions);

            var expectedResultString = "1 dollar, 3 quarters, 1 nickel";
            mockChangeCalculator.Setup(calc => calc.DetermineChange(It.IsAny<decimal>()))
                .Returns(expectedResultString);

            var response = uut.Index(mockFormFile.Object);

            Assert.IsInstanceOf<OkObjectResult>(response);
            Assert.AreEqual(StatusCodes.Status200OK, ((OkObjectResult)response).StatusCode);
            Assert.AreEqual(expectedResultString, ((OkObjectResult)response).Value);
        }

    }
}