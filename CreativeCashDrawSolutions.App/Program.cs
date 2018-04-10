using System;
using System.Collections.Generic;
using CreativeCashDrawSolutions.Domain.Currencies;
using CreativeCashDrawSolutions.Domain.Currencies.Canada;
using CreativeCashDrawSolutions.Domain.Currencies.Euro;
using CreativeCashDrawSolutions.Domain.Currencies.UnitedStatesDollar;
using CreativeCashDrawSolutions.Domain.Files;

namespace CreativeCashDrawSolutions.App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2) PrintHelp(); 
            try
            {
                var inputFile = args[0];
                var outputFile = args[1];
                var currencyCode = "USD";
                if (args.Length > 2)
                {
                    currencyCode = args[2];
                }

                var fileProcessor = new FileProcessor();
                var transactions = fileProcessor.ImportTransactions(inputFile);

                CurrencyProcessor currencyProcessor;
                switch (currencyCode)
                {
                    case "EURO":
                        currencyProcessor = new EuroProcessor();
                        break;
                    case "CAD":
                        currencyProcessor = new CanadaProcessor();
                        break;
                    default:
                        currencyProcessor = new UnitedStatesDollarProcessor();
                        break;
                }

                var outputStrings = new List<string>();
                foreach (var transaction in transactions)
                {
                    outputStrings.Add(currencyProcessor.GetOutputString(transaction));
                }

                fileProcessor.WriteTransactions(outputFile, outputStrings);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                PrintHelp();
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("args[0] => input file path");
            Console.WriteLine("args[1] => output file path");
            Console.WriteLine("args[2] => optional currency code (USD is default)");
        }
    }
}
