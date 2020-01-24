using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CashRegister.Interfaces;

namespace CashRegister.BL
{
    public class ProcessChangeGenerator : IProcessChangeGenerator
    {
        private readonly IUtilities _ut = new Utilities();
        private string _denominationsToReturn = string.Empty;
        private string _errorMessage = string.Empty;

        #region Output Change To Customer

        /// <summary>
        /// Build output containing valid change amount owed to customer if data is valid.
        /// If data is not valid, print 'Invalid Input' for that line of data.
        /// </summary>
        /// <param name="inputFileContents">Contents of Input File</param>
        /// <returns>Data for printing to output file</returns>
        public string OutputChangeToCustomer(List<string[]> inputFileContents)
        {
            try
            {
                var denominationsDictionary = _ut.GenerateDenominationsDictionary();
                var fundsToReturn = string.Empty;

                _denominationsToReturn = string.Empty;  // reset each time method is called

                foreach (var item in inputFileContents)
                {
                    // Try to parse two decimals from each line of file.
                    // If not possible or amount customer paid is more than total price then line of data is invalid.
                    if (item.Length == 2 &&
                        decimal.TryParse(item[0], out var totalDue) &&
                        decimal.TryParse(item[1], out var amountPaid) &&
                        amountPaid > totalDue)
                    {
                        var changeDue = amountPaid - totalDue;
                        var totalDueInCents = totalDue * 100;  //Dollar Amount * 100

                        if (totalDueInCents % 3 == 0)
                        {
                            //Randomize Dictionary to get random change denominations
                            var randomizedDenominationsDictionary = _ut.RandomizeDenominationsDictionary(denominationsDictionary);
                            fundsToReturn = GetMonetaryDenominationsDue(randomizedDenominationsDictionary, changeDue, true);
                        }
                        else
                        {
                            fundsToReturn = GetMonetaryDenominationsDue(denominationsDictionary, changeDue, false);
                        }
                    }
                    else
                    {
                        // Invalid input data
                        _denominationsToReturn += "Invalid Input" + Environment.NewLine;
                        fundsToReturn = _denominationsToReturn;
                    }
                }

                return fundsToReturn;
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhenExecutingOutputChangeToCustomer");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Output Change To Customer

        #region Get Monetary Denominations Due to Customer

        /// <summary>
        /// Calculate monetary denominations due to customer
        /// </summary>
        /// <param name="denominationsDictionary"></param>
        /// <param name="changeDue"></param>
        /// <param name="isDivisibleByThree"></param>
        /// <returns>string containing monetary denominations due to customer</returns>
        public string GetMonetaryDenominationsDue(Dictionary<string, decimal> denominationsDictionary, decimal changeDue, bool isDivisibleByThree)
        {
            try
            {
                foreach (var item in denominationsDictionary)
                {
                    // Count of each denomination to return to customer
                    var countOfDenomination = (int)(changeDue / item.Value);

                    // Update changeDue after each iteration with remaining amount due to customer
                    changeDue -= (countOfDenomination * item.Value);

                    // If more than one denomination is to be returned, pluralize denomination name
                    var denominationName = countOfDenomination > 1 ? _ut.ReplaceWithPlurals(item.Key) : item.Key;

                    // Create string containing monetary denominations to return to customer
                    if (countOfDenomination != 0)
                    {
                        _denominationsToReturn += countOfDenomination + " " + denominationName + ", ";
                    }
                }

                // remove last blank space and last comma
                _denominationsToReturn = _denominationsToReturn.Remove(_denominationsToReturn.Length - 2);

                if (isDivisibleByThree)
                {
                    _denominationsToReturn += " (Total due in cents was divisible by 3; Denominations are randomly generated.)";
                }

                _denominationsToReturn += Environment.NewLine;

                return _denominationsToReturn;
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhenExecutingGetMonetaryDenominationsDue");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Get Monetary Denominations Due to Customer
    }
}