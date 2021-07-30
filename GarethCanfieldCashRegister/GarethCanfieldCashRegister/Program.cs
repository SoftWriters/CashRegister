using System;
using System.Collections.Generic;

namespace GarethCanfieldCashRegister
{
    /// <summary>
    /// Program.cs will read in cash values for the total cash due and total cash received from the Input File (located in Solution Items), and output the expected cash back using the least
    /// amount of US Currency possible (dollars, quarters, dimes, nickels, pennies) to the Output File (located in Solution Items). If the total due in cents is divisible by 3, random change denominations will be used.
    /// 
    /// Created By: Gareth Canfield
    /// 1/12/2020
    /// </summary>
    class Program
    {
        private static string path = System.IO.Path.Combine(Environment.CurrentDirectory);
        private static string inputFile = "InputFile.txt";
        private static string outputFile = "OutputFile.txt";
        private static Random rand = new Random();

        /// <summary>
        /// The basic transaction that will include the total due(double), total given(double), if the change will be in random denominations(bool), and if the format is correct(bool)
        /// </summary>
        private class Transaction
        {
            public double totalDue { get; set; }
            public double totalGiven { get; set; }
            public bool isRandom { get; set; }
            public bool isFormat { get; set; }
        }

        private static void Main(string[] args)
        {
            // List of every line on the Input file saved into a Transaction
            var transactionsList = _extractPrices();
            _printChangeDue(transactionsList);
        }

        /// <summary>
        /// Compiles and prints all lines that will be added to the Output file
        /// </summary>
        /// <param name="transactionsList">List of transactions that will be analyzed and printed</param>
        /// <param name="outputLines">List of strings that contain the text for each output line</param>
        private static void _printChangeDue(List<Transaction> transactionsList)
        {
            var outputLines = new List<string>();
            foreach (var transaction in transactionsList)
            {
                var changeDue = Math.Round(transaction.totalGiven - transaction.totalDue, 2);
                if (!transaction.isFormat)
                {
                    outputLines.Add("**INVALID FORMAT**");
                }
                else if (changeDue < 0)
                {
                    outputLines.Add($"ERROR: Insufficient funds were provided! Total due is ${transaction.totalDue.ToString("F" + 2)} but only received ${transaction.totalGiven.ToString("F" + 2)}.");
                }
                else if (changeDue == 0)
                {
                    outputLines.Add("Exact funds have been provided, no change will be given.");
                }
                else
                {
                    outputLines.Add(_computeChangeDue(changeDue, transaction.isRandom));
                }
            }
            System.IO.File.WriteAllLines($"{path}\\{outputFile}", outputLines);
        }

        /// <summary>
        /// Computes how the change due will be split up into US Currencies
        /// </summary>
        /// <param name="changeDue">Current amount of change that is due</param>
        /// <param name="isRandom">If true, the change denominations will be computed randomly</param>
        /// <returns>String containing the change due in formatted US currencies</returns>
        private static string _computeChangeDue(double changeDue, bool isRandom)
        {
            var endString = "";
            Dictionary<string, double> tenders = new Dictionary<string, double>();
            tenders.Add("dollar", 1.0);
            tenders.Add("quarter", 0.25);
            tenders.Add("dime", 0.1);
            tenders.Add("nickel", 0.05);
            tenders.Add("penny", 0.01);
            if (isRandom)
            {
                tenders = _randomizeTenders(tenders);
            }
            var firstPrint = true;
            foreach (KeyValuePair<string, double> tender in tenders)
            {
                long counter = 0;
                if (tender.Key.Equals("penny")) //Pennies will always be needed for certain values (ex. $1.87)
                {
                    if (changeDue != 0)
                    {
                        counter = Convert.ToInt64(changeDue / tender.Value);
                        changeDue = 0;
                    }
                }
                else if (!isRandom) //If this is not random, it will calculate the maximum amount of each specific tender for the current change due
                {
                    if (changeDue >= tender.Value)
                    {
                        counter = Convert.ToInt64(Math.Floor(changeDue / tender.Value));
                        changeDue -= (counter * tender.Value);
                    }
                }
                else    //If this is random, it will calculate a random amount of each specific tender for the current change do
                {
                    if (changeDue > tender.Value)
                    {
                        var maxTenderAmount = Convert.ToInt64(Math.Floor(changeDue / tender.Value));
                        counter = randomLong(0, maxTenderAmount + 1);
                        changeDue -= (counter * tender.Value);
                    }
                }
                if (counter != 0)
                {
                    if (!firstPrint)
                    {
                        endString += ", ";
                    }
                    firstPrint = false;
                    endString += $"{counter.ToString()} {tender.Key}";
                    if (counter > 1)
                    {
                        if (tender.Key.Equals("penny"))
                        {
                            endString = endString.TrimEnd('y');
                            endString += "ies";
                        }
                        else
                        {
                            endString += "s";
                        }
                    }
                }
            }
            return endString;
        }

        /// <summary>
        /// Randomizes the tenders that will be used to calculate change due
        /// </summary>
        /// <param name="tenders">List of all expected US tenders that are being used</param>
        /// <returns>List of random US tenders (always includes pennies)</returns>
        private static Dictionary<string, double> _randomizeTenders(Dictionary<string, double> tenders)
        {
            var tendersToRemove = new List<string> { };
            tenders.Remove("penny");
            foreach (KeyValuePair<string, double> tender in tenders)
            {
                var randomization = rand.Next(2);
                if (randomization == 0)
                {
                    tendersToRemove.Add(tender.Key);
                }
            }
            foreach (var tender in tendersToRemove)
            {
                tenders.Remove(tender);
            }
            tenders.Add("penny", 0.01);
            return tenders;
        }

        /// <summary>
        /// Calculates a random Long number between the given parameters
        /// </summary>
        /// <param name="min">Minimum number to be returned</param>
        /// <param name="max">Maximum number to be returned</param>
        /// <returns>Random long value</returns>
        private static long randomLong(long min, long max)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }

        /// <summary>
        /// Extracts the prices from every line in the Input file into a list of Transactions, calculating if the change denominations will be random and if the format is correct
        /// </summary>
        /// <returns>List of Transactions based off of the Input file's contents</returns>
        private static List<Transaction> _extractPrices()
        {
            var lineCounter = 1;
            string[] lines = System.IO.File.ReadAllLines($"{path}\\{inputFile}");
            var expectedValues = new List<Tuple<double, double, bool>> { };
            foreach (var line in lines)
            {
                var formatChecker = true;
                var inputNumbers = line.Split(',');
                try
                {
                    expectedValues.Add(Tuple.Create(Math.Round(Convert.ToDouble(inputNumbers[0]), 2), Math.Round(Convert.ToDouble(inputNumbers[1]), 2), formatChecker));
                }
                catch (FormatException fmex)
                {
                    Console.WriteLine($"ERROR: Input at line #{lineCounter} was not provided in the expected format.\r\n{fmex}");
                    expectedValues.Add(Tuple.Create(00.00, 00.00, false));
                }
                catch (IndexOutOfRangeException iore)
                {
                    Console.WriteLine($"ERROR: Input at line #{lineCounter} was not provided in the expected format.\r\n{iore}");
                    expectedValues.Add(Tuple.Create(00.00, 00.00, false));
                }
                ++lineCounter;
            }
            var pricesAndPayments = new List<Transaction> { };
            foreach (var expectedValue in expectedValues)
            {
                pricesAndPayments.Add(new Transaction { totalDue = expectedValue.Item1, totalGiven = expectedValue.Item2, isRandom = Convert.ToDecimal(expectedValue.Item1) % 0.03M == 0, isFormat = expectedValue.Item3 });
            }
            return pricesAndPayments;
        }
    }
}
