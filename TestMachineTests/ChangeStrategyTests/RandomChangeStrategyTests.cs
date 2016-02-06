using BasicConsoleAppTests.DomainTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using CashMachine.ChangeStrategies;
using CashMachine.Domain;

namespace BasicConsoleAppTests.ChangeStrategyTests
{
    [TestClass]
    public class when_making_random_change : WithTestMoney<RandomChangeStrategy>
    {
        [TestMethod]
        public void it_should_return_35_dimes_and_9_pennys()
        {
            var unorderedList = new List<ICurrency> { Dime, Dollar, Penny }; //Arrange
            Mocks.Get<IMoney>().Stub(x => x.DecreasingValueCurrency).Return(TestMoney);
            Mocks.Get<ICurrencyRandomizer>().Stub(x => x.Shuffle(TestMoney))
                .Return(unorderedList);
            var change = Mocks.ClassUnderTest.MakeChange(3.59M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 0); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 35);
            Assert.AreEqual(change.NumberOf(Penny), 9);

            For <ICurrencyRandomizer>().AssertWasCalled(x => x.Shuffle(TestMoney));
        }

        [TestMethod]
        public void it_should_return_359_pennys()
        {
            var unorderedList = new List<ICurrency> { Penny, Dollar, Dime }; //Arrange
            Mocks.Get<IMoney>().Stub(x => x.DecreasingValueCurrency).Return(TestMoney);
            Mocks.Get<ICurrencyRandomizer>().Stub(x => x.Shuffle(TestMoney))
                .Return(unorderedList);
            var change = Mocks.ClassUnderTest.MakeChange(3.59M); //Act

            Assert.AreEqual(change.NumberOf(Dollar), 0); //Assert
            Assert.AreEqual(change.NumberOf(Dime), 0);
            Assert.AreEqual(change.NumberOf(Penny), 359);

            For<ICurrencyRandomizer>().AssertWasCalled(x => x.Shuffle(TestMoney));
        }
    }
}