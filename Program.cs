using System;
using System.IO;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("There must be exactly 1 argument (input file path)");
                return;
            }

            var amountsFilePath = args[0];
            try
            {
                // Read each line in file.
                using (var sr = new StreamReader(amountsFilePath))
                {
                    // Write output file, with a ".out" extension.
                    using (var sw = new StreamWriter(amountsFilePath + ".out"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (string.IsNullOrEmpty(line))
                            {
                                // Nothing to do.
                                continue;
                            }

                            // Get amount-owed string and amount-paid string.
                            var tokens = line.Split(",".ToCharArray());
                            if (tokens.Length != 2)
                            {
                                // Write error for this line but continue processing lines...
                                Console.WriteLine("Error reading input file: line does not contain 2 comma-separated strings: " + line);
                                continue;
                            }

                            var amountOwed = Convert.ToDecimal(tokens[0].Trim());
                            var amountPaid = Convert.ToDecimal(tokens[1].Trim());

                            if (amountOwed < 0 || amountPaid < 0 || amountPaid < amountOwed)
                            {
                                Console.WriteLine("Invalid values found while reading line: " + line);
                                continue;
                            }

                            // Make change and write it to output file.
                            var changeMaker = new ChangeMaker(amountOwed, amountPaid);
                            var change = changeMaker.MakeChange();

                            sw.WriteLine(change);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while reading the input file: " + e.Message);
            }
        }
    }
}
