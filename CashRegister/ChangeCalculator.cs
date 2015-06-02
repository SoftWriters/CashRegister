using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// Class that implements a change calculator for a cash register
    /// </summary>
    public class ChangeCalculator : IChangeCalculator
    {
        private string _errorMessage = string.Empty;
        private List<Denomination> _denominations;

        /// <summary>
        /// If an error occurs, the error message will be populated here
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        /// <summary>
        /// The list of denominations to use to make change
        /// </summary>
        public List<Denomination> Denominations
        {
            get
            {
                if (_denominations == null)
                {
                    _denominations = PopulateDefaultDenominations();
                }
                return _denominations;
            }

            set { _denominations = value; }
        } 

        /// <summary>
        /// Proceses a file of cash register transactions.  
        /// The file is comma delimitted, 
        /// contains one transaction per line and 
        /// each line contains the amount charged and then the amount tendered
        /// </summary>
        /// <param name="inputFilePath">The full path to the input transaction file</param>
        /// <param name="outputFilePath">The full path to the output file</param>
        /// <returns>True if successfully processed, false otherwise.  
        /// If the return value is false, 
        /// the error message will be contained in the ErrorMessage property.</returns>
        public bool ProcessBatchFile(string inputFilePath, string outputFilePath)
        {
            bool isSuccess = true;
            try
            {
                using (var inputStream = new StreamReader(inputFilePath))
                {
                    var transactions = TransactionFile.GetTransactions(inputStream);
                    using (var outputStream = new StreamWriter(outputFilePath))
                    {
                        for (var i = 0; i < transactions.Count; i++)
                        {
                            outputStream.WriteLine(CalculateChange(transactions[i]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                isSuccess = false;
            }

            return isSuccess;
        }

        private string CalculateChange(Transaction transaction)
        {
            string changeToGive;
            var centsCharged = (int)(transaction.Charged * 100);
            var centsTendered = (int)(transaction.Tendered * 100);
            
            if ((centsTendered - centsCharged) % 3 == 0)
            {
                changeToGive = RandomChange(centsTendered - centsCharged);
            }
            else
            {
                changeToGive = BestChange(centsTendered - centsCharged);
            }

            return changeToGive;
        }
        
        private List<Denomination> PopulateDefaultDenominations()
        {
            var denominations = new List<Denomination>();
            denominations.Add(new Denomination(2000, "Twenty Dollar Bill", "Twenty Dollar Bills"));
            denominations.Add(new Denomination(1000, "Ten Dollar Bill", "Ten Dollar Bills"));
            denominations.Add(new Denomination(500, "Five Dollar Bill", "Five Dollar Bills"));
            denominations.Add(new Denomination(100, "One Dollar Bill", "One Dollar Bills"));
            denominations.Add(new Denomination(25, "Quarter", "Quarters"));
            denominations.Add(new Denomination(10, "Dime", "Dimes"));
            denominations.Add(new Denomination(5, "Nickel", "Nickels"));
            denominations.Add(new Denomination(1, "Penny", "Pennies"));

            return denominations;
        }

        private string BestChange(int change)
        {
            var bestChange = string.Empty;
            ZeroDenominationCounts();
            var denominations = Denominations.OrderByDescending(x => x.Value).ToList();
            var index = 0;
            while (change > 0)
            {
                if (denominations[index].Value < change)
                {
                    denominations[index].Count = change / denominations[index].Value;
                    change = change % denominations[index].Value;
                    bestChange = string.Format("{0}, {1}", bestChange, denominations[index].Display);
                }
                ++index;
            }

            return bestChange.Substring(2);
        }

        private string RandomChange(int change)
        {
            var rnd = new Random();
            var randomChange = string.Empty;
            ZeroDenominationCounts();
            var denominations = Denominations.OrderBy(x => x.Value).ToList();
            var limit = denominations.Count;
            while (change > 0)
            {
                while (denominations[limit-1].Value > change)
                {
                    --limit;
                }
                var index = rnd.Next(limit);
                ++denominations[index].Count;
                change -= denominations[index].Value;
            }
            for (var index = denominations.Count - 1; index >= 0; --index)
            {
                if (denominations[index].Count > 0)
                {
                    randomChange = string.Format("{0}, {1}", randomChange, denominations[index].Display);
                }
            }

            return randomChange.Substring(2);
        }

        private void ZeroDenominationCounts()
        {
            foreach (var denomination in Denominations)
            {
                denomination.Count = 0;
            }
        }
    }

    /// <summary>
    /// struct to hold the transaction information
    /// </summary>
    public struct Transaction
    {
        public double Charged;
        public double Tendered;
    }
}
