using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


//Reads in a config file with the possible currency types in it
//and will return a sorted list of all the currency types for 
//this run.

namespace CashRegister
{
    class CurrencyReaderClass
    {
        public List<CurrencyClass> ReadCurrencyFile(String fileName)
        {
            if (fileName == String.Empty)
            {
                //TODO: Add Error Message/loging
                Debug.WriteLine("FATAL: No transaction filename provided.");
                return null;
            }
            try
            {
                List<CurrencyClass> currencyList = new List<CurrencyClass>();
                using (StreamReader streamReader = new StreamReader(fileName))
                {

                    String inputFile = streamReader.ReadToEnd();
                    String[] lines = inputFile.Split('\n');
                    foreach (String line in lines)
                    {
                        String[] currencyLine = line.Split(',');
                        if (currencyLine.Length == 3)
                        {
                            if ((currencyLine[0] != string.Empty) && (currencyLine[1] != String.Empty) && (currencyLine[1] != String.Empty))
                            {
                                Decimal value;
                                Decimal.TryParse(currencyLine[0].Trim(),out value); 
                                currencyList.Add(new CurrencyClass(currencyLine[1].Trim(),currencyLine[2].Trim(),value));
                            }
                        }
                    }
                }
                List<CurrencyClass> sortedCurrency = currencyList.OrderByDescending(currency => currency.Value).ToList();
                return sortedCurrency;
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
