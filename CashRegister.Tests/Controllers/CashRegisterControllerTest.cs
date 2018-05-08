using CashRegister.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CashRegister.Tests.Controllers
{
    [TestClass]
    public class CashRegisterControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CashRegisterController controller = new CashRegisterController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
