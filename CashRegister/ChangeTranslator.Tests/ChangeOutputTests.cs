using System;
using System.Linq;
using ChangeTranslator.Dtos;
using ChangeTranslator.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;

namespace ChangeTranslator.Tests
{
    [TestClass]
    public class ChangeOutputTests
    {
        private IFixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
        }

        [TestMethod]
        public void MakeChange_NoChange_ReturnsNoChangePhrase()
        {
            // Arrange
            var testCurrency = _fixture.Create<TestCurrency>();
            var cost = _fixture.Create<decimal>();
            var isRandom = _fixture.Create<bool>();
            var changeOutput = new ChangeOutput(testCurrency);

            // Act
            var result = changeOutput.MakeChange(cost, cost, isRandom);

            // Assert
            Assert.AreEqual(testCurrency.NoChangePhrase, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeChange_CostGreaterThanPaid_ThrowsArguementException()
        {
            // Arrange
            var cost = _fixture.Create<decimal>();
            var isRandom = _fixture.Create<bool>();
            var changeOutput = new ChangeOutput(new UnitedStatesCurrency());

            // Act
            changeOutput.MakeChange(cost + 1, cost, isRandom);
        }

        [TestMethod]
        public void MakeChange_SingleDenominationsNotRandom_ReturnsList()
        {
            // Arrange
            var changeOutput = new ChangeOutput(new UnitedStatesCurrency());

            // Act
            var result = changeOutput.MakeChange(0, 1.41m, false);

            // Assert
            Assert.AreEqual("1 dollar,1 quarter,1 dime,1 nickel,1 penny", result);
        }

        [TestMethod]
        public void MakeChange_MultipleDenominationsNotRandom_ReturnsList()
        {
            // Arrange
            var changeOutput = new ChangeOutput(new UnitedStatesCurrency());

            // Act
            var result = changeOutput.MakeChange(0, .52m, false);

            // Assert
            Assert.AreEqual("2 quarters,2 pennies", result);
        }

        [TestMethod]
        public void MakeChange_CostAndPaidDiffNotRandom_ReturnsList()
        {
            // Arrange
            var changeOutput = new ChangeOutput(new UnitedStatesCurrency());

            // Act
            var result = changeOutput.MakeChange(.5m, 1.02m, false);

            // Assert
            Assert.AreEqual("2 quarters,2 pennies", result);
        }

        [TestMethod]
        public void MakeChange_RandomDenominations_ReturnsList()
        {
            // Arrange
            var changeOutput = new ChangeOutput(new UnitedStatesCurrency());
            var result = string.Empty;
            var expected = "4 dollars,1 quarter,1 nickel,1 penny";
            expected += (expected + expected);

            // Act
            result += changeOutput.MakeChange(0, 4.31m, true);
            result += changeOutput.MakeChange(0, 4.31m, true);
            result += changeOutput.MakeChange(0, 4.31m, true);

            // Assert
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void RandomChange_ValueIsNotSmallest_ReturnRandomCount()
        {
            // Arrange
            var testCurrency = _fixture.Create<TestCurrency>();
            var largest = testCurrency.Denominations.Max(x => x.Value);
            var maxCount = _fixture.Create<int>();
            var result = 0;
            var changeOutput = new ChangeOutput(testCurrency);

            // Act
            result += changeOutput.RandomCount(maxCount, largest);
            result += changeOutput.RandomCount(maxCount, largest);
            result += changeOutput.RandomCount(maxCount, largest);

            // Assert
            Assert.AreNotEqual(maxCount * 3, result);
        }

        [TestMethod]
        public void RandomChange_ValueIsSmallest_ReturnMaxCount()
        {
            // Arrange
            var testCurrency = _fixture.Create<TestCurrency>();
            var smallest = testCurrency.Denominations.Min(x => x.Value);
            var expected = _fixture.Create<int>();
            var changeOutput = new ChangeOutput(testCurrency);

            // Act
            var result = changeOutput.RandomCount(expected, smallest);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
