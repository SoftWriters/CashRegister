using CashMachine.ChangeStrategies;
using CashMachine.Domain;
using CashMachineTests.DomainTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CashMachineTests.ChangeStrategyTests
{

    [TestClass]
    public class when_making_minimal_change : WithTestMoney<MinimalChangeStrategy>
    {
        [TestInitialize]
        public void Arrange()
        { 
            Mocks.Get<IMoney>().Stub(x => x.DecreasingValueCurrency).Return(TestMoney);
        }

        [TestMethod]
        public void it_should_return_3_dollars_5_dimes_9_pennies()
        {
            var change = Mocks.ClassUnderTest.MakeChange(3.59M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 3); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 5);
            Assert.AreEqual(change.NumberOf(Penny), 9);
        }

        [TestMethod]
        public void it_should_return_5_dollars()
        {
            var change = Mocks.ClassUnderTest.MakeChange(5M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 5); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 0);
            Assert.AreEqual(change.NumberOf(Penny), 0);
        }

        [TestMethod]
        public void it_should_make_minimal_change_for_3_15()
        {
            var change = Mocks.ClassUnderTest.MakeChange(3.15M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 3); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 1);
            Assert.AreEqual(change.NumberOf(Penny), 5);
        }
   
        [TestMethod]
        public void it_should_make_minimal_change_for_7_99()
        {
            var change = Mocks.ClassUnderTest.MakeChange(7.99M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 7); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 9);
            Assert.AreEqual(change.NumberOf(Penny), 9);
        }

        [TestMethod]
        public void it_should_make_minimal_change_for_23_69()
        {
            var change = Mocks.ClassUnderTest.MakeChange(23.69M); //Act

            Assert.AreEqual(change.NumberOf(Dollar),23); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 6);
            Assert.AreEqual(change.NumberOf(Penny), 9);
        }
    }
}
