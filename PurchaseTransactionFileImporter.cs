using System;
using System.Collections.Generic;
using System.IO;

namespace CashRegister
{
    public class PurchaseTransactionFileImporter : IPurchaseTransactionImporter
    {
        private const string UNEXPECTED_INPUT = "Unexpected input of {0} on line {1} of the file {2}";
        private string _filePath;
        public PurchaseTransactionFileImporter(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<PurchaseTransaction> GetPurchaseTransactions()
        {
            List<PurchaseTransaction> purchaseTransactions = new List<PurchaseTransaction>();

            using (StreamReader fileStreamReader = File.OpenText(_filePath))
            {
                int fileLineNumber = 1;
                string transactionLine;

                while ((transactionLine = fileStreamReader.ReadLine()) != null)
                {
                    // Assume any blank line is the end of the file, so that we can skip any remaining new lines at the end of the file.
                    if (String.IsNullOrWhiteSpace(transactionLine))
                    {
                        break;
                    }

                    string[] transactionAmounts = transactionLine.Split(',');

                    // Check for an incorrect number of parameters for our expected input
                    if (transactionAmounts.Length != 2)
                    {
                        throw new Exception(String.Format(UNEXPECTED_INPUT, transactionLine, fileLineNumber, _filePath));
                    }

                    PurchaseTransaction transaction = new PurchaseTransaction();
                    decimal amountOwed;
                    decimal amountReceived;
                    bool amountOwedParseSuccess = Decimal.TryParse(transactionAmounts[0], out amountOwed);
                    bool amountReceivedParseSuccess = Decimal.TryParse(transactionAmounts[1], out amountReceived);

                    // Check that the values received are decimal values
                    if (!amountOwedParseSuccess || !amountReceivedParseSuccess)
                    {
                        throw new Exception(String.Format(UNEXPECTED_INPUT, transactionLine, fileLineNumber, _filePath));
                    }

                    transaction.AmountOwed = amountOwed;
                    transaction.AmountReceived = amountReceived;

                    purchaseTransactions.Add(transaction);

                    fileLineNumber++;
                }
            }

            return purchaseTransactions;
        }
    }
}
