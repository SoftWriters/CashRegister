using CashMachine.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachineTests.DomainTests
{
    [TestClass]
    public class When_counting_change : WithTestMoney<Change>
    {
        [TestMethod]
        public void it_should_return_a_value_of_6_75()
        {
            var change = Mocks.ClassUnderTest.Add(Dollar, 6).Add(Dime,7).Add(Penny,5); // Arrange

            Assert.AreEqual(change.Value, 6.75M);
        }
    }

    [TestClass]
    public class When_adding_more_coins : WithTestMoney<Change>
    {
        [TestMethod]
        public void it_should_return_a_value_of_6_95()
        {
            var change = Mocks.ClassUnderTest.Add(Dollar, 6).Add(Dime, 7).Add(Penny, 5); // Arrange
            Assert.AreEqual(change.Value, 6.75M);

            change.Add(Dime, 2); // Adding more change! Wow, getting rich
            Assert.AreEqual(change.Value, 6.95M);
        }
    }
}
