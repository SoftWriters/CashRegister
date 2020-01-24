using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CashRegister.Interfaces;

namespace CashRegister.BL
{
    public class Utilities : IUtilities
    {
        private string _errorMessage = string.Empty;

        #region Generate Denominations Dictionary Containing Items Found In a Cash Register

        /// <summary>
        /// Creation of dictionary containing all monetary denominations generally found in
        /// a cash register.
        /// </summary>
        /// <returns>Dictionary of common cash register denominations</returns>
        public Dictionary<string, decimal> GenerateDenominationsDictionary()
        {
            try
            {
                return new Dictionary<string, decimal>
                {
                    {"Twenty Dollar Bill", 20.00m},
                    {"Ten Dollar Bill", 10.00m},
                    {"Five Dollar Bill", 5.00m},
                    {"One Dollar Bill", 1.00m},
                    {"Quarter", .25m},
                    {"Dime", .10m},
                    {"Nickel", .05m},
                    {"Penny", .01m}
                };
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorGeneratingCashDictionary");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Generate Denominations Dictionary Containing Items Found In a Cash Register

        #region Randomize Cash Dictionary

        /// <summary>
        /// Randomize Denominations Dictionary in order to provide customer with random change denominations
        /// </summary>
        /// <param name="denominationsDictionary"></param>
        /// <returns>Randomized dictionary of common cash register denominations</returns>
        public Dictionary<string, decimal> RandomizeDenominationsDictionary(Dictionary<string, decimal> denominationsDictionary)
        {
            try
            {
                var r = new Random();

                return denominationsDictionary.OrderBy(m => r.Next(0, denominationsDictionary.Count))
                                              .ToDictionary(item => item.Key, item => item.Value);
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorRandomizingCashDictionary");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Randomize Cash Dictionary

        #region Pluralize Denomination Value Names

        /// <summary>
        /// Pluralize monetary amount
        /// </summary>
        /// <param name="p">Denomination in Singular tense</param>
        /// <returns>Monetary amount string with pluralized ending</returns>
        public string ReplaceWithPlurals(string p)
        {
            try
            {
                var lastCharacter = p[p.Length - 1];

                // dollar bill(s), quarter(s), dime(s), nickel(s)
                if (lastCharacter == 'l' || lastCharacter == 'r' || lastCharacter == 'e')
                {
                    p += 's';
                }
                // penny to pennies
                else if (lastCharacter == 'y')
                {
                    // remove 'y' then append ies when count > 1
                    p = p.Remove(p.Length - 1);
                    p += "ies";
                }

                return p;
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhenApplyingReplaceWithPlurals");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Pluralize Denomination Value Names
    }
}