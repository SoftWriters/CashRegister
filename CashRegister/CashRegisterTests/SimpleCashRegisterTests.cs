using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;

namespace CashRegisterTests
{
    [TestClass]
    public class SimpleCashRegisterTests
    {
        // SimpleCasRegister.MinimizeAmountsOfChange() tests.
        [TestMethod]
        public void MinimizeAmountsOfChange_WithOneDollarAndFourtyOneCents_SetsChangeToOneDollarBillAndOneQuarterAndOneDimeAndOneNickelAndOnePenny()
        {
            CashTransaction ct = new CashTransaction(0, 141);
            SimpleCashRegister scr = new SimpleCashRegister();

            Dictionary<CashDenominations, int> expected = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 1},
                {CashDenominations.Quarters, 1},
                {CashDenominations.Dimes, 1},
                {CashDenominations.Nickels, 1},
                {CashDenominations.Pennies, 1}
            };

            CollectionAssert.AreEqual(expected, scr.CalculateMinimumAmountsOfChange(ct));
        }

        [TestMethod]
        public void MinimizeAmountsOfChange_WithOneCent_SetsChangeToOnePenny()
        {
            CashTransaction ct = new CashTransaction(0, 1);
            SimpleCashRegister scr = new SimpleCashRegister();

            Dictionary<CashDenominations, int> expected = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0},
                {CashDenominations.Pennies, 1}
            };

            CollectionAssert.AreEqual(expected, scr.CalculateMinimumAmountsOfChange(ct));
        }

        [TestMethod]
        public void MinimizeAmountsOfChange_WithZeroChange_SetsChangeToZeroForEachDenomination()
        {
            CashTransaction ct = new CashTransaction(0, 0);
            SimpleCashRegister scr = new SimpleCashRegister();

            Dictionary<CashDenominations, int> expected = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 0},
                {CashDenominations.Nickels, 0},
                {CashDenominations.Pennies, 0}
            };

            CollectionAssert.AreEqual(expected, scr.CalculateMinimumAmountsOfChange(ct));
        }

        [TestMethod]
        public void MinimizeAmountsOfChange_WithNinetyFourCents_SetsChangeToThreeQuartersOneDimeOneNickelFourPennies()
        {
            CashTransaction ct = new CashTransaction(0, 94);
            SimpleCashRegister scr = new SimpleCashRegister();

            Dictionary<CashDenominations, int> expected = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 0},
                {CashDenominations.Quarters, 3},
                {CashDenominations.Dimes, 1},
                {CashDenominations.Nickels, 1},
                {CashDenominations.Pennies, 4}
            };

            CollectionAssert.AreEqual(expected, scr.CalculateMinimumAmountsOfChange(ct));
        }

        [TestMethod]
        public void MinimizeAmountsOfChange_WithOneHundredDollarsAndTwentyTwoCents_SetsChangeToOneHundredDollarsTwoDimesTwoPennies()
        {
            CashTransaction ct = new CashTransaction(0, 10022);
            SimpleCashRegister scr = new SimpleCashRegister();

            Dictionary<CashDenominations, int> expected = new Dictionary<CashDenominations, int>()
            {
                {CashDenominations.Dollars, 100},
                {CashDenominations.Quarters, 0},
                {CashDenominations.Dimes, 2},
                {CashDenominations.Nickels, 0},
                {CashDenominations.Pennies, 2}
            };

            CollectionAssert.AreEqual(expected, scr.CalculateMinimumAmountsOfChange(ct));
        }

        // SimpleCashRegister.RandomizeAmountsOfChange() tests.
        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithFiveHundredDollars_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 50000;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithOneDollar_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 100;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithTwentyFiveCents_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 25;
            const int numberOfIterations = 25;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithTenCents_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 10;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithFiveCents_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 5;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithOneCent_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 1;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        // Check test standard output for randomness.
        public void RandomizeAmountsOfChange_WithZeroCents_ReturnsChangeThatAddsUpCorrectlyForOneHundredIterations()
        {
            const int expected = 0;
            const int numberOfIterations = 100;
            CashTransaction ct = new CashTransaction(0, expected);
            SimpleCashRegister scr = new SimpleCashRegister();
            for (int i = 0; i < numberOfIterations; ++i)
            {
                Dictionary<CashDenominations, int> randomChange = scr.CalculateRandomAmountsOfChange(ct);
                int result = 0;
                foreach (var count in randomChange)
                {
                    result += (int)count.Key * count.Value;
                    Console.Write("{0} {1}  ", count.Key, count.Value);
                }
                Console.Write("\n");
                Assert.AreEqual(expected, result);
            }
        }

        // SimpleCashRegister.IsDivisibleByThree() tests.
        [TestMethod]
        public void IsDivisibleByThree_WithSix_ReturnsTrue()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsTrue(scr.IsDivsibleByThree(6));
        }

        [TestMethod]

        public void IsDivsibleByThree_WithZero_ReturnsTrue()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsTrue(scr.IsDivsibleByThree(0));
        }

        [TestMethod]

        public void IsDivsibleByThree_WithThree_ReturnsTrue()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsTrue(scr.IsDivsibleByThree(3));
        }

        [TestMethod]

        public void IsDivsibleByThree_WithNegativeOneHundredandTwo_ReturnsTrue()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsTrue(scr.IsDivsibleByThree(-102));
        }

        [TestMethod]

        public void IsDivsibleByThree_WithOneHundredandOne_ReturnsFalse()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsFalse(scr.IsDivsibleByThree(101));
        }

        [TestMethod]

        public void IsDivsibleByThree_WithNegativeSeven_ReturnsFalse()
        {
            SimpleCashRegister scr = new SimpleCashRegister();
            Assert.IsFalse(scr.IsDivsibleByThree(-7));
        }
    }
}
