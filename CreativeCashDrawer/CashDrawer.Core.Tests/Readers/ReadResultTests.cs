using CashDrawer.Core.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.Core.Tests.Readers
{
    [TestClass]
    public class ReadResultTests
    {

        [TestMethod]
        public void ok_returns_result_with_due_and_paid_values()
        {
            var result = ReadResult.Ok(10, 11);
            Assert.IsFalse(result.HasError);
            Assert.AreEqual(10, result.Due);
            Assert.AreEqual(11, result.Paid);
        }


        [TestMethod]
        public void failed_returns_result_with_error()
        {
            var result = ReadResult.Failed("this failed");
            Assert.IsTrue(result.HasError);
            Assert.AreEqual("this failed", result.Error);
        }

    }
}
