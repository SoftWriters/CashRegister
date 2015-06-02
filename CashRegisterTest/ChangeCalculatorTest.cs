using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegisterTest
{
    [TestClass]
    public class ChangeCalculatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var changeCalculator = new ChangeCalculator();
            var returnValue = changeCalculator.ProcessBatchFile("changeInput.txt", "changeOutput.txt");
            Assert.AreEqual(string.Empty, changeCalculator.ErrorMessage);
            Assert.IsTrue(returnValue);
        }
    }
}
