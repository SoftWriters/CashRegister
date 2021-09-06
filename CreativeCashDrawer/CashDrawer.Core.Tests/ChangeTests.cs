using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.Core.Tests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void can_construct_change()
        {
            var change = new Change(1, 2, 3, 4, 5);
            Assert.AreEqual(1, change.Dollars);
            Assert.AreEqual(2, change.Quarters);
            Assert.AreEqual(3, change.Dimes);
            Assert.AreEqual(4, change.Nickles);
            Assert.AreEqual(5, change.Pennies);
        }
    }
}
