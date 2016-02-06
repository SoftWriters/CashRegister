using CashMachine.ChangeStrategies;
using CashMachine.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CashMachineTests.DomainTests
{
    [TestClass]
    public class PurchaseStrategyTests : WithTestMoney<PurchaseStrategy>
    {
        [TestMethod]
        public void when_purchasing_on_the_happy_path_even_cost()  
        {
            Mocks.ClassUnderTest.MakePurchase(new Purchase("2.00,2.30"));
            For<IMinimalChangeStrategy>().AssertWasCalled(x => x.MakeChange(0.30M));
            For<IRandomChangeStrategy>().AssertWasNotCalled(x => x.MakeChange(0.30M));
        }

        [TestMethod]
        public void when_purchasing_on_the_happy_path_odd_cost()
        {
            Mocks.ClassUnderTest.MakePurchase(new Purchase("3.33,4.00"));
            For<IMinimalChangeStrategy>().AssertWasNotCalled(x => x.MakeChange(0.67M));
            For<IRandomChangeStrategy>().AssertWasCalled(x => x.MakeChange(0.67M));
        }

        [TestMethod]
        public void when_purchasing_on_the_happy_path_odd_cost2()
        {
            Mocks.ClassUnderTest.MakePurchase(new Purchase("0.03,4.00"));
            For<IMinimalChangeStrategy>().AssertWasNotCalled(x => x.MakeChange(3.97M));
            For<IRandomChangeStrategy>().AssertWasCalled(x => x.MakeChange(3.97M));
        }
    }
}
