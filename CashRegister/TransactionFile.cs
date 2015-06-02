using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CashRegister
{
    /// <summary>
    /// This static class processes a cash register transaction file
    /// </summary>
    public static class TransactionFile
    {
        /// <summary>
        /// Gets the transactions from the batch transaction file
        /// </summary>
        /// <param name="streamReader">The StreamReader for the comma delimitted input file 
        /// with one transaction per line.</param>
        /// <returns>a list of Transactions extracted from the file</returns>
        public static List<Transaction> GetTransactions(StreamReader streamReader)
        {
            var results = new List<Transaction>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                bool isBaddata = true;
                var values = line.Split(',');
                if (values.Count() == 2)
                {
                    double charged;
                    double tendered;
                    if (double.TryParse(values[0], out charged) && NumberOfDecimalPlaces(values[0]) == 2 &&
                        double.TryParse(values[1], out tendered) && NumberOfDecimalPlaces(values[1]) == 2)
                    {
                        var transaction = new Transaction { Charged = charged, Tendered = tendered };
                        results.Add(transaction);
                        isBaddata = false;
                    }
                }
                if (isBaddata)
                {
                    throw new InvalidDataException("The transaction data file is not in the correct format.");
                }
            }

            return results;
        }

        private static int NumberOfDecimalPlaces(string numberString)
        {
            var parts = numberString.Split('.');
            return parts.Count() == 2 ? parts[1].Length : 0;
        }
    }
}
