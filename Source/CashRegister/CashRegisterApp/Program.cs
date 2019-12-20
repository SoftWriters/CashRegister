using CashRegisterLib;
using System;
using System.IO;

namespace CashRegisterApp
{
    class Program
    {
        static int Main(string[] args)
        {
            // read args and validate file exists
            if (args.Length < 1)
            {
                Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} CSVFileName");
                return -1;
            }

            var fileName = args[0];
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"ERROR: File not found. \"{fileName}\"");
                return - 1;
            }

            try
            {
                // read file validate content and process change
                using (var file = new StreamReader(fileName))
                {
                    string line;
                    int lineCnt = 0;
                    var cashier = new Cashier();
                    while ((line = file.ReadLine()) != null)
                    {
                        lineCnt++;

                        if (!string.IsNullOrWhiteSpace(line)) // skip blank lines
                        {
                            var amounts = line.Split(',');
                            if (amounts.Length < 2)
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: File should contain two values separated by a comma.");
                                break;
                            }

                            var first = amounts[0].Trim();
                            var second = amounts[1].Trim();

                            decimal total;
                            if (!decimal.TryParse(first, out total))
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: \"{first}\" is not a numeric value.");
                                return -1;
                            }

                            decimal paid;
                            if (!decimal.TryParse(second, out paid))
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: \"{second}\" is not a numeric value.");
                                return -1;
                            }

                            if (total < 0)
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: Total amount should be a positive number.");
                                return -1;
                            }

                            if (total < 0)
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: Paid amount should be a positive number.");
                                return -1;
                            }

                            if (total > paid)
                            {
                                Console.WriteLine($"ERROR [Line: {lineCnt}]: Paid amount is less than the total amount.");
                                return -1;
                            }

                            var change = cashier.GetChange(total, paid);
                            Console.WriteLine(change);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return -1;
            }

            // Pause the console when debugging
            if (System.Diagnostics.Debugger.IsAttached)
                Console.ReadLine();

            return 0;
        }
    }
}
