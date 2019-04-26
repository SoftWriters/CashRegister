using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Businesses;
using CashRegister.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegister.Tests.Controllers
{
    [TestClass]
    public class CashRegisterTests
    {
        [TestMethod]
        public void TestCalculateChangeNoChange()
        {
            // Edge case - no change
            CashRegisterBusiness business = new CashRegisterBusiness();
            IEnumerable<CashRegisterRecord> records = business.ProcessFile("1.00, 1.00");
            Assert.AreEqual(0, records.First().Change);
            Assert.AreEqual("No change", records.First().ChangeText);
        }

        [TestMethod]
        public void TestCalculateChange1Penny()
        {
            // Regular test - one penny
            CashRegisterBusiness business = new CashRegisterBusiness();
            IEnumerable<CashRegisterRecord> records = business.ProcessFile("1.99, 2.00");
            Assert.AreEqual(0.01m, records.First().Change);
            Assert.AreEqual("1 penny", records.First().ChangeText);
        }

        [TestMethod]
        public void TestCalculateChangePlural()
        {
            // Test plural nouns
            CashRegisterBusiness business = new CashRegisterBusiness();
            IEnumerable<CashRegisterRecord> records = business.ProcessFile("1.88, 4.00");
            Assert.AreEqual(2.12m, records.First().Change);
            Assert.AreEqual("2 dollars, 1 dime, 2 pennies", records.First().ChangeText);
        }

        [TestMethod]
        public void TestCalculateChangeOneOfEach()
        {
            // Test each USD denomination
            CashRegisterBusiness business = new CashRegisterBusiness();
            IEnumerable<CashRegisterRecord> records = business.ProcessFile("13.58, 200.00");
            Assert.AreEqual(186.42m, records.First().Change);
            Assert.AreEqual("1 hundred-dollar bill, 1 fifty-dollar bill, 1 twenty-dollar bill, 1 ten-dollar bill, 1 five-dollar bill, 1 dollar, 1 quarter, 1 dime, 1 nickel, 2 pennies", records.First().ChangeText);
        }

        [TestMethod]
        public void TestCalculateChangeDivisibleBy3()
        {
            // Test client's request
            // If amount owed is divisible by 3, generate the change denominations randomly
            CashRegisterBusiness business = new CashRegisterBusiness();
            IEnumerable<CashRegisterRecord> records = business.ProcessFile("5.52, 10.00");
            Assert.AreEqual(4.48m, records.First().Change);
            Assert.AreNotEqual("4 dollars, 1 quarter, 2 dimes, 3 pennies", records.First().ChangeText); // This exact scenario is not likely
        }
    }
}
