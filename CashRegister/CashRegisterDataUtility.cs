using System;
using System.Collections.Generic;
using System.IO;

namespace CashRegister
{
    public static class CashRegisterDataUtility
    {
        public static IList<OwedPaid> ReadEntriesFromFile(string fileName)
        {
            var entries = new List<OwedPaid>();

            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                var amounts = line.Split(',');
                entries.Add(new OwedPaid(Convert.ToDouble(amounts[0]), Convert.ToDouble(amounts[1])));
            }

            return entries;
        }

        public static void WriteEntriesToFile(string fileName, IList<IList<ChangeAmount>> changeAmountLists)
        {
            var outputs = new List<string>();

            foreach (var changeAmounts in changeAmountLists)
            {
                var output = "";
                foreach(var changeAmount in changeAmounts)
                {
                    output += string.Format("{0}, ", changeAmount.ToString());
                }

                outputs.Add(output.Substring(0, output.Length - 2));
            }

            File.WriteAllLines(fileName, outputs);
        }
    }
}
