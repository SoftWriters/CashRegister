using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegister.Tests
{
    [TestClass()]
    public class ChangeMakerTests
    {
        [TestMethod()]
        public void MakeChangeTest()
        {
            var changeMaker = new ChangeMaker(2.60m, 3m);
            var change = changeMaker.MakeChange();

            Assert.AreEqual("1 Quarter,1 Dime,1 Nickel", change);

            changeMaker = new ChangeMaker(3.28m, 100m);
            change = changeMaker.MakeChange();

            Assert.AreEqual("4 Twenties,1 Ten,1 Five,1 Dollar,2 Quarters,2 Dimes,2 Pennies", change);
        }

        [TestMethod()]
        public void MakeRandomChangeTest()
        {
            var changeMaker = new ChangeMaker(6.27m, 50m);
            var change = changeMaker.MakeChange();

            Assert.AreEqual("1 Ten,1 Five,7 Dollars,21 Quarters,41 Dimes,61 Nickels,933 Pennies", change);
        }

        [TestMethod()]
        public void ErrorTests()
        {
            var changeMaker = new ChangeMaker(2.60m, 1m);
            var change = changeMaker.MakeChange();
            Assert.AreEqual(string.Empty, change);

            changeMaker = new ChangeMaker(-2m, 1m);
            change = changeMaker.MakeChange();
            Assert.AreEqual(string.Empty, change);
        }
    }
}