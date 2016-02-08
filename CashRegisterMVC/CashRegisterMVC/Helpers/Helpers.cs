using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace CashRegisterMVC.Helpers
{
    public class MonetaryHelper : CashRegisterMVC.Models.Money
    {
        #region Constructor
        public MonetaryHelper()
        {
            // Populate Dictionary with all possible monetary denominations that can be returned to customer
            // Cash registers usually only contain the following bills and coins
            CashDictionary.Add("twenty dollar bill", 20.00m);
            CashDictionary.Add("ten dollar bill", 10.00m);
            CashDictionary.Add("five dollar bill", 5.00m);
            CashDictionary.Add("dollar", 1.00m);
            CashDictionary.Add("quarter", .25m);
            CashDictionary.Add("dime", .10m);
            CashDictionary.Add("nickel", .05m);
            CashDictionary.Add("penny", .01m);

            // Read data from file line by line and store results in array.
            // Split on comma so that each value of each line can be accessed
            IEnumerable<string[]> resultArray1 = System.IO.File.ReadAllLines(Path).Select(x => x.Split(','));

            // iterate through array doing calculations where necessary and ultimately getting the correct change amount
            // as desired
            foreach (string[] item in resultArray1)  // each outer item
            {
                InputData += item[0] + ", " + item[1] + "\r\n";
                AmountOwed = Convert.ToDecimal(item[0]);
                TotalCost = Convert.ToDecimal(item[1]);
                Change = TotalCost - AmountOwed;

                // Generate monetary denominations
                if ((int)AmountOwed % 3 == 0)
                {
                     GetChangeAmount(Change, CashDictionary, true);
                }
                else
                {
                    GetChangeAmount(Change, CashDictionary, false);
                }
            }
        }
        #endregion


        #region GetChangeAmount
        /// <summary>
        /// If Amount Owed is divisible by 3, Randomize denominations and call method to calculate change to be paid. Otherwise
        /// just call method to calculate change to be paid using least possible physical change.
        /// </summary>
        /// <param name="Change">Change to be paid to customer</param>
        /// <param name="CashDictionary">Monetary denominations available</param>
        /// <param name="random">Generate using random denominations?</param>
        public void GetChangeAmount(decimal Change, Dictionary<string, decimal> CashDictionary, bool random)
        {            

            // Randomize monetary denominations, then retrieve denominations of change to be paid
            if (random == true)
            {
                RandomCashDictionary = Randomizer(CashDictionary);
                GetMonetaryDemoniationsDue(RandomCashDictionary, Change);

            }
            // Retrieve denominations of change to be paid using least physical change
            else
            {
                GetMonetaryDemoniationsDue(CashDictionary, Change);

            }


            ChangeGiven = ChangeGiven.Remove(ChangeGiven.Length - 2);   // remove last blank space and last comma
            ChangeGiven += "\r\n";                                      // add line breaks for each output
        }
        #endregion

        #region Calculate Change and output amount
        /// <summary>
        /// Logic to determine monetary denominations to pay customer
        /// </summary>
        /// <param name="ChangeAmountsDictionary">Dictionary of denominations(randomized if amount owed divisible by 3)</param>
        /// <param name="Change">Amount of change due to customer</param>
        private void GetMonetaryDemoniationsDue(Dictionary<string, decimal> ChangeAmountsDictionary, decimal Change)
        {
            // Loop over pairs with foreach.
            foreach (KeyValuePair<string, decimal> pair in ChangeAmountsDictionary)
            {
                #region calculation explanation
                // ex: Change = .88 and current iteration for pair.Value is quarter so
                //     count = (int)(.88 / .25) = 3 (when casting to int), meaning 3 quarters
                //     Change = .88 - (3 *.25) = .13 so we now need to pay 3 quarters + .13 which will be determined in next iterations.
                #endregion
                int count = (int)(Change / pair.Value);
                Change -= count * pair.Value;

                // make amounts plural if more than 1 bill or coin of same type
                if (count > 1)
                {
                     PairKey = ReplaceWithPlurals(pair.Key);
                }
                else
                {
                    PairKey = pair.Key;
                }

                // Insert or Append number of dollars or coins in current iteration to change due amount to customer
                if (count != 0)
                {
                    ChangeGiven += count + " " + PairKey + ", ";
                }
            }
        }
        #endregion

        #region Randomize CashDictionary
        /// <summary>
        /// Randomizing entries in dictionary will allow for a random monetary value to be given in change
        /// instead of the least physical change.
        /// </summary>
        /// <param name="CashDictionary">Dictionary of monetary descriptions and amounts</param>
        /// <returns>Randomized dictionary of monetary descriptions and amounts</returns>
        public Dictionary<string, decimal> Randomizer(Dictionary<string, decimal> CashDictionary)
        {
            Random r = new Random();
            
            // Since OrderBy returns an IOrderedEnumerable collection, must cast back to Dictionary if you want a dictionary object
            CashDictionary = CashDictionary.OrderBy(m => r.Next(0, CashDictionary.Count)).ToDictionary(dItem => dItem.Key, dItem => dItem.Value);
            return CashDictionary;

        }
        #endregion

        #region ReplaceWithPlurals function
        public string ReplaceWithPlurals(string p)
        {

            char lastCharacter = p[p.Length - 1];

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
        #endregion
    }
}