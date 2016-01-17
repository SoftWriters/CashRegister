using System;
using System.Collections.Generic;
using System.IO;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid number of arguments, correct usage is: CashRegister input_file output_file");
                Console.ReadLine();
                return;
            }

            var inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine(string.Format("File {0} does not exist.", inputFile));
                Console.ReadLine();
                return;
            }

            var entries = CashRegisterDataUtility.ReadEntriesFromFile(inputFile);
            var changeAmounts = new List<IList<ChangeAmount>>();

            foreach (var entry in entries)
            {
                changeAmounts.Add(CashRegister.MakeChange(entry));
            }

            var outputFile = args[1];
            CashRegisterDataUtility.WriteEntriesToFile(outputFile, changeAmounts);
        }
    }
}
