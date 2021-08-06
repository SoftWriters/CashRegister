using NUnit.Framework;
using static CashRegister.Main;

namespace CashRegister.Test
{
    public class CashRegisterTest
    {

        [Test]
        [TestCase(1.97, 2.00, "3 pennies")]
        [TestCase(3.34, 5.00, "1 dollar, 2 quarters, 1 dime, 1 nickel, 1 penny")]
        [TestCase(6.49, 7.00, "2 quarters, 1 penny")]
        [TestCase(1.97, 4.00, "2 dollars, 3 pennies")]
        [TestCase(9.97, 10.00, "3 pennies")]
        [TestCase(1234.57, 2000.00, "7 hundreds, 1 fifty, 1 ten, 1 five, 1 quarter, 1 dime, 1 nickel, 3 pennies")]
        public void GetChangeTest(decimal cost, decimal given, string expected)
        {
            var output = GetChange(cost, given);
            Assert.AreEqual(output, expected);
        }

        [Test]
        [TestCase(3.00, 4.00)]
        public void GetRandomChangeTest(decimal cost, decimal given)
        {
            var randomOutput = GetChange(cost, given);
            var otherRandomOutput = GetChange(cost, given);
            Assert.AreNotEqual(randomOutput, otherRandomOutput);
        }
    }
}