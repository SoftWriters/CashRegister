using CashRegister.Enums;
using CashRegister.Extensions;
using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CashRegister.Businesses
{
    /// <summary>
    /// Performs back-end calculations and processes for Cash Register. Called by CashRegisterController.
    /// </summary>
    public class CashRegisterBusiness
    {
        /// <summary>
        /// Process the uploaded file contents and return a list of records with completed calculations
        /// </summary>
        /// <param name="fileContents"></param>
        /// <returns></returns>
        public IEnumerable<CashRegisterRecord> ProcessFile(string fileContents)
        {
            // Parse the file contents to get a list of records
            IEnumerable<CashRegisterRecord> records = ParseFileContents(fileContents);

            // Calculate change and denominations for each record
            foreach (CashRegisterRecord record in records)
            {
                try
                {
                    record.Change = CalculateChange(record.Owed, record.Paid);
                    // Client's "twist"
                    // If amount owed is divisible by 3, use random algorithm to determine bills and coins
                    BillsAndCoinsAlgorithm algorithm = BillsAndCoinsAlgorithm.Greedy;
                    if ((record.Owed * 100) % 3 == 0)
                    {
                        algorithm = BillsAndCoinsAlgorithm.Random;
                    }
                    record.ChangeText = GetBillsAndCoins(record.Change, algorithm);
                }
                catch (Exception ex)
                {
                    // Label this record as having an error
                    // Continue processing the rest of the records
                    record.Error = true;
                }
            }

            return records;
        }

        /// <summary>
        /// Parse file contents to get a list of records
        /// </summary>
        /// <param name="fileContents"></param>
        /// <returns></returns>
        protected IEnumerable<CashRegisterRecord> ParseFileContents(string fileContents)
        {
            // This regular expression matches 2 decimal number groups separated by a comma and any number of spaces
            string rx = @"(?<owed>[0-9,]*.?[0-9]+)\s*,\s*(?<paid>[0-9,]*.?[0-9]+)";

            // Match the file contents
            // This will produce 2 named Groups, "owed" and "paid" for each match
            MatchCollection matches = Regex.Matches(fileContents, rx);

            // Create a list of records
            List<CashRegisterRecord> records = new List<CashRegisterRecord>();
            foreach (Match match in matches)
            {
                CashRegisterRecord record = new CashRegisterRecord();

                try
                {
                    // Get and parse the amount owed
                    string owed = match.Groups["owed"].Value;
                    record.Owed = Decimal.Parse(owed);
                    // If necessary, round to 2 decimal places. Some data might be lost.
                    //record.Owed = Math.Round(record.Owed, 2);

                    // Get and parse the amount paid
                    string paid = match.Groups["paid"].Value;
                    record.Paid = Decimal.Parse(paid);
                    // If necessary, round to 2 decimal places. Some data might be lost.
                    //record.Paid = Math.Round(record.Paid);
                }
                catch (Exception ex)
                {
                    // Label this record as having an error
                    // Do not stop the rest of the matches from being processed
                    record.Error = true;
                }

                records.Add(record);
            }

            return records;
        }

        /// <summary>
        /// Calculate change using amount owed and amount paid. 
        /// Override if change needs to be calculated differently (promotions, rounding etc.)
        /// </summary>
        /// <param name="owed"></param>
        /// <param name="paid"></param>
        /// <returns></returns>
        protected virtual decimal CalculateChange(decimal owed, decimal paid)
        {
            // This is a separate method so it can be inherited and adapted for different situations
            // For example:
            // Round up to the nearest dollar and donate the difference to charity
            // Round up to the nearest 5 cents because 1 cent coins are out of circulation (Canada)
            decimal change = paid - owed;
            return change;
        }

        /// <summary>
        /// Determine how many of each currency denomination is needed to make the provided amount
        /// </summary>
        /// <param name="amount"></param>
        protected virtual string GetBillsAndCoins(decimal amount, BillsAndCoinsAlgorithm algorithm = BillsAndCoinsAlgorithm.Greedy)
        {
            try
            {
                // Get all denominations (ordered by value descending)
                Denomination[] denominations = GetDenominations();

                // String with bills and change written out
                StringBuilder sb = new StringBuilder();

                if (amount < 0)
                {
                    // Data isn't right...
                    sb.Append("Customer still owes $" + (0 - amount));
                }
                else if (amount == 0)
                {
                    // There is nothing to calculate
                    sb.Append("No change");
                }
                else
                {
                    // Starting amount, when a matching bill or coin is found, their value will be subtracted from this amount
                    decimal amountLeft = amount;

                    switch (algorithm)
                    {
                        case BillsAndCoinsAlgorithm.Greedy:
                            // Use greedy algorithm to determine the minimum amount of bills and change
                            // If I recall correctly, in this case, greedy algorithm will always produce the best result
                            
                            // Start with the highest denomination
                            foreach (Denomination denomination in denominations)
                            {
                                decimal value = denomination.Value;
                                string name = denomination.Name;

                                // Calculate how many times this denomination fits in amount left
                                int count = Convert.ToInt32(Math.Truncate(amountLeft / value));
                                if (count > 0)
                                {
                                    // Append the amount to the result string
                                    sb.Append((sb.Length > 1 ? ", " : "") + count + " " + (count > 1 ? name.ToPlural() : name));

                                    // Substract the amount from the running amount left
                                    amountLeft -= count * value;
                                }
                            }
                            break;
                        case BillsAndCoinsAlgorithm.Random:
                            // Random algorithm
                            // To make sure that bills and coins add up correctly and implementation is efficient and easy,
                            // follow the same pattern as greedy algorithm, but randomly choose the number of bills / coins at each step.
                            // At the end, get all the available pennies (or lowest denomination)
                            // This will produce a correct result, but will add a degree of randomess

                            Random rng = new Random();

                            // Start with the highest denomination
                            for (int i = 0; i < denominations.Length; i++)
                            {
                                decimal value = denominations[i].Value;
                                string name = denominations[i].Name;

                                // Calculate how many times this denomination fits in amount left
                                int count = Convert.ToInt32(Math.Truncate(amountLeft / value));

                                // Randomize if this is not the lowest denomination (penny)
                                if (i < denominations.Length - 1)
                                {
                                    count = rng.Next(count);
                                }

                                if (count > 0)
                                {
                                    // Append the amount to the result string
                                    sb.Append((sb.Length > 1 ? ", " : "") + count + " " + (count > 1 ? name.ToPlural() : name));

                                    // Substract the amount from the running amount left
                                    amountLeft -= count * value;
                                }
                            }
                            break;
                        default:
                            throw new Exception("Unknown algorithm to determine bills and coins.");
                    }
                    
                    // Note any amount that we were unable to process
                    // This could only happen if user entered values under 1 cent (or similar situation)
                    if (amountLeft > 0)
                    {
                        sb.Append((sb.Length > 1 ? " " : "") + "($" + amountLeft + " that cannot be given in change)");
                    }
                }
                
                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to determine bills and change for " + amount + ".", ex);
            }
        }

        /// <summary>
        /// Initialize a list of currency denominations, USD by default. Override to use a different currency.
        /// </summary>
        /// <returns></returns>
        protected virtual Denomination[] GetDenominations()
        {
            // Due to how denominations are used in algorithms above, array is sufficient
            // It's possible to use List or even SortedList if quick lookup is necessary.
            // Sorted in descending order
            Denomination[] denominations =
            {
                new Denomination(100, "hundred-dollar bill"),
                new Denomination(50, "fifty-dollar bill"),
                new Denomination(20, "twenty-dollar bill"),
                new Denomination(10, "ten-dollar bill"),
                new Denomination(5, "five-dollar bill"),
                new Denomination(1, "dollar"),
                new Denomination(0.25m, "quarter"),
                new Denomination(0.10m, "dime"),
                new Denomination(0.05m, "nickel"),
                new Denomination(0.01m, "penny")
            };

            return denominations;
        }
    }
}