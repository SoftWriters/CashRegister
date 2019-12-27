using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace SWCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            
            if (!System.IO.File.Exists("input.txt"))
            {
                Console.WriteLine("Could not find file input.txt.");
                return;
            }

            try
            {
                using (var input = new StreamReader("input.txt"))
                using (var output = new StreamWriter("output.txt"))
                {
                    while ((line = input.ReadLine()) != null)
                    {
                        if (!ValidateLine(line))
                        {
                            Console.WriteLine($"Found invalid value: {line}");
                            continue;
                        }

                        var values = line.Split(',');
                        int price = (int)(Convert.ToDecimal(values[0]) * 100);
                        int amountPaid = (int)(Convert.ToDecimal(values[1]) * 100);

                        if (amountPaid < price)
                        {
                            Console.WriteLine($"Insufficient funds: {line}");
                            continue;
                        }

                        int changeAmount = amountPaid - price;

                        IChangeCalculator calculator = ChangeCalculatorFactory.GetChangeCalculator(price);
                        output.WriteLine(PrintChange(calculator.GetChange(changeAmount)));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Returns true if the line contains two decimal values, separated by a comma
        /// </summary>
        /// <param name="line"></param>
        /// <returns>True if line is correctly formatted</returns>
        public static bool ValidateLine(string line)
        {
            var regex = new Regex(@"^\d+\.\d{2}\,\d+\.\d{2}$");
            return regex.IsMatch(line) ;
        }

        /// <summary>
        /// Gets a text description of change quantities.
        /// </summary>
        /// <param name="change">A list mapping a currency to a quantity</param>
        /// <returns>Description of change.</returns>
        public static string PrintChange(IList<(Currency Currency, int Quantity)> change)
        {
            List<string> changeText = new List<string>();

            var sortedChange = change
                .GroupBy(x => x.Currency)
                .Select(g => new {
                    Currency = g.Key,
                    Quantity = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.Currency.Value);

            foreach (var denomination in sortedChange)
            {
                changeText.Add($"{denomination.Quantity} {(denomination.Quantity == 1 ? denomination.Currency.Name : denomination.Currency.Plural)}");
            }

            return String.Join(",", changeText);
        }
    }
}
