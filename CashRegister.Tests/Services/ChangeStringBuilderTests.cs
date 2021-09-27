using CashRegister.Services;
using NUnit.Framework;

namespace CashRegister.Tests.Services
{
    [TestFixture]
    public class ChangeStringBuilderTests
    {
        private ChangeStringBuilder uut;
        
        public ChangeStringBuilderTests()
        {
            uut = new ChangeStringBuilder();
        }

        [Test]
        [TestCase(1, 1, 1, 1, 1, "1 dollar, 1 quarter, 1 dime, 1 nickel, 1 penny")]
        [TestCase(2, 2, 2, 2, 2, "2 dollars, 2 quarters, 2 dimes, 2 nickels, 2 pennies")]
        [TestCase(0, 1, 1, 1, 1, "1 quarter, 1 dime, 1 nickel, 1 penny")]
        [TestCase(1, 0, 1, 1, 1, "1 dollar, 1 dime, 1 nickel, 1 penny")]
        [TestCase(1, 1, 0, 1, 1, "1 dollar, 1 quarter, 1 nickel, 1 penny")]
        [TestCase(1, 1, 1, 0, 0, "1 dollar, 1 quarter, 1 dime")]
        [TestCase(0, 0, 0, 0, 0, "")]
        public void ChangeStringBuilder_ShouldReturn_ExpectedStringWithIndividualResults(
            decimal dollars,
            decimal quarters,
            decimal dimes,
            decimal nickels,
            decimal pennies,
            string expectedString
        )
        {
            var result = uut.BuildChangeString(dollars, quarters, dimes, nickels, pennies);

            Assert.AreEqual(expectedString, result);
        }
    }
}