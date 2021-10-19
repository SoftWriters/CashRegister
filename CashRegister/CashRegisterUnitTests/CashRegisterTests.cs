using NUnit.Framework;
using CashRegister;
using System.Collections.Generic;
using System;
using System.IO;

namespace CashRegisterUnitTests
{
    public class CashRegisterTests
    {
        /// <summary>
        /// Reading multiple inputs from a text file
        /// </summary>
        [Test]
        public void Reading_Multiple_Lines()
        {
            // Arrange
            var utilities = new ChangeCalculations();
            List<string> costValue = new List<string>();
            List<string> paidValue = new List<string>();
            // Act
            utilities.Splittingvalues("Resources\\textinputfile.txt", costValue, paidValue);

            //Assert
            if((costValue.Count==paidValue.Count)&&(costValue.Count > 2) && (paidValue.Count > 2))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        /// <summary>
        /// checks to see randomization does occur
        /// </summary>
        [Test]
        public void Randomize_Change_Value()
        {
            // Arrange
            var utilities = new ChangeCalculations();
            string paid = "3.50";
            string cost = "2.10";

            // Act
            var test1 = utilities.RandomizeNumberofCoins(paid, cost);
            var test2 = utilities.RandomizeNumberofCoins(paid, cost);

            //Assert
            Assert.AreNotEqual(test1, test2);
        }

        /// <summary>
        /// Minimum amount of demonination is needed
        /// </summary>
        [Test]
        public void Exact_Change_Value()
        {
            // Arrange
            var utilities = new ChangeCalculations();
            string paid = "3.50";
            string cost = "2.10";

            // Act
            var test1 = utilities.CalculatingNumberofCoins(paid, cost);
            var test2 = "1 dollar,1 quarter,1 dime,1 nickel\n";

            //Assert
            Assert.AreEqual(test1, test2);
        }

        /// <summary>
        /// If paid was less than cost
        /// </summary>
        [Test]
        public void Paid_LessThan_Cost()
        {
            // Arrange
            var utilities = new ChangeCalculations();
            string paid = "1.50";
            string cost = "2.10";

            // Act
            var test = utilities.CalculatingNumberofCoins(paid, cost);
            //Assert
            Assert.AreEqual(test, "Not enough funds to give change\n");
        }
        /// <summary>
        /// randomization of paid was less than cost
        /// </summary>
        [Test]
        public void Randomize_Paid_LessThan_Cost()
        {
            // Arrange
            var utilities = new ChangeCalculations();
            string paid = "1.50";
            string cost = "2.10";

            // Act
            var test = utilities.RandomizeNumberofCoins(paid, cost);
            //Assert
            Assert.AreEqual(test, "Not enough funds to give change\n");
        }

        /// <summary>
        /// cost divisible by 3
        /// </summary>
        [Test]
        public void Divisibleby3()
        {
            // Arrange
            var utilities = new ChangeCalculations();

            List<string> paid = new List<string>();
            List<string> cost = new List<string>();
            List<string> change = new List<string>();
            paid.Add("3.00");
            cost.Add("2.10");
            


            // Act
            utilities.ChangeofCost(cost, paid, change);

            //Assert
            Assert.AreNotEqual(change[0], "3 quarters,1 dime,1 nickel\n");
            
        }

    }
}