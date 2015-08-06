using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;



//Basic class to read in the transactions and return them as a list

namespace CashRegister
{
    class InputReaderClass
    {

        public List<TransactionClass> ReadTranastionFile(String fileName)
        {
            if (fileName == String.Empty)
            {
                //TODO: Add Error Message/loging
                Debug.WriteLine("FATAL: No transaction filename provided.");
                return null;
            }
            try
            {
                List<TransactionClass> transactions = new List<TransactionClass>();
                using (StreamReader streamReader = new StreamReader(fileName))
                {

                    String inputFile = streamReader.ReadToEnd();
                    String[] lines = inputFile.Split('\n');
                    foreach (String line in lines)
                    {
                        String[] transactionLine = line.Split(',');
                        if (transactionLine.Length == 2)
                        {
                            if ((transactionLine[0] != string.Empty) && (transactionLine[1] != String.Empty))
                            {
                                Decimal charges; Decimal payment;
                                bool success1 = Decimal.TryParse(transactionLine[0].Trim(), out charges);
                                bool success2 = Decimal.TryParse(transactionLine[1].Trim(), out payment);
                                if (success1 && success2)
                                {
                                    transactions.Add(new TransactionClass(charges, payment));
                                }
                                else
                                {
                                    Debug.WriteLine("WARNING: Bad data in transaction file, skiping entry");
                                }
                            }
                        }
                        else
                        {
                            Debug.WriteLine("WARNING: Bad data in transaction file, skiping entry");
                        }
                    }
                }
                return transactions;
            }
            catch (Exception error)
            {
                //TODO: Add Error Message/loging
                Debug.WriteLine("FATAL: Error reading transaction file: " + Environment.NewLine + error.Message);
                return null;
            }

        }
    }
}
