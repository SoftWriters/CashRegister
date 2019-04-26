using System;
using ChangeTranslator.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;

namespace ChangeTranslator.Tests
{
    [TestClass]
    public class TransactionTests
    {
        private IFixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
        }

        [TestMethod]
        public void Transaction_CostDivisibleBy3_RandomChangeTrue()
        {
            // Arrange
            var paid = _fixture.Create<decimal>();

            // Act
            var result = new Transaction("3.33", $"{paid}");

            // Assert
            Assert.IsTrue(result.RandomChange);
        }

        [TestMethod]
        public void Transaction_CostNotDivisibleBy3_RandomChangeFalse()
        {
            // Arrange
            var paid = _fixture.Create<decimal>();

            // Act
            var result = new Transaction("3.32", $"{paid}");

            // Assert
            Assert.IsFalse(result.RandomChange);
        }

        [TestMethod]
        public void TransactionConstructor_DecimalStrings_ReturnsTransactionObject()
        {
            // Arrange
            var cost = _fixture.Create<decimal>();
            var paid = _fixture.Create<decimal>();

            // Act
            var result = new Transaction($"{cost}", $"{paid}");

            // Assert
            Assert.AreEqual(cost, result.Cost);
            Assert.AreEqual(paid, result.Paid);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TransactionConstructor_BadCost_ThrowsInvalidCastException()
        {
            // Arrange
            var cost = _fixture.Create<string>();
            var paid = _fixture.Create<decimal>();

            // Act
            var result = new Transaction(cost, $"{paid}");

            // Assert
            Assert.AreEqual(cost, result.Cost);
            Assert.AreEqual(paid, result.Paid);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TransactionConstructor_BadPaid_ThrowsInvalidCastException()
        {
            // Arrange
            var cost = _fixture.Create<decimal>();
            var paid = _fixture.Create<string>();

            // Act
            var result = new Transaction($"{cost}", paid);

            // Assert
            Assert.AreEqual(cost, result.Cost);
            Assert.AreEqual(paid, result.Paid);
        }
    }
}
