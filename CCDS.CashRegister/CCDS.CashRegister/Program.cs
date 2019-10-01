using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDS.CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("File not found.");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File not found.");
                return;
            }

            //if (args.Length > 1) {
            // var currency = ...
            //} else {
            var currencyAmounts = Currency.USCurrencyAmounts;
            var currency = Currency.USCurrency;

            CashRegister register = new CashRegister(currencyAmounts);

            using (var inFile = new StreamReader(args[0]))
            using (var outFile = File.CreateText("output.txt"))
            {
                string line;
                while ((line = inFile.ReadLine()) != null)
                {
                    line = line.Replace(".", "");
                    string[] values = line.Split(',');
                    long cost, payment;

                    if (long.TryParse(values[0], out cost) && long.TryParse(values[1], out payment))
                    {
                        string errorMessage;
                        if ((errorMessage = register.TransactionErrorMessage(cost, payment)) == null)
                        {
                            register.AddTransaction(cost, payment);
                            var change = register.GiveChange();
                            var outFileLine = WriteDenominations(change, currency);
                            outFile.WriteLine(outFileLine);
                        }

                        else
                        {
                            Console.WriteLine(errorMessage);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Error: line could not be read correctly.");
                    }
                }
            }
        }

        private static string WriteDenominations(long[] change, List<KeyValuePair<string, string>> currency)
        {
            StringBuilder result = new StringBuilder();
            bool hadPrevious = false;
            for (int i = 0; i < change.Length; ++i)
            {
                if (hadPrevious) {
                    result.Append(",");
                }

                hadPrevious = change[i] != 0 ? true : false;

                //appends # and plural currency
                if (change[i] > 1)
                {
                    result.Append(change[i]);
                    result.Append(" ");
                    result.Append(currency[i].Value);
                }

                //appends 1 and singular currency
                else if (change[i] > 0)
                {
                    result.Append(change[i]);
                    result.Append(" ");
                    result.Append(currency[i].Key);
                }
            }

            return result.ToString();
        }
    }
}
