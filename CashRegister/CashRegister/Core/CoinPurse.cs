using System.Collections.Generic;
using System.Text;

namespace CashRegister.Core
{
    public class CoinPurse
    {
        #region Private Members
        private readonly IDictionary<Coin, int> _coinCollection;
        #endregion

        #region Constructors / Factory Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Constructor for CoinPurse which forces a IDictionary to be sent to populate the internal _coinCollection.
        /// </summary>
        /// <param name="coinCollection">Dictionary representing a collection of coins and their respective counts.</param>
        public CoinPurse(IDictionary<Coin, int> coinCollection)
        {
            _coinCollection = coinCollection;
        }

        /// <summary>
        /// Keep this one private so we can only use in this class.
        /// </summary>
        private CoinPurse()
        {
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Method that returns CoinPurse containing change from string inputs for amount owed and amount paid.
        /// </summary>
        /// <param name="amountOwed">String representing amount of owed.</param>
        /// <param name="amountPaid">String representing amount paid.</param>
        /// <returns>Returns a CoinPurse containing change for the specified amounts.</returns>
        public static CoinPurse GetChangePurse(string amountOwed, string amountPaid)
        {
            var returnValue = new CoinPurse();
            var owedSuccess = int.TryParse(amountOwed.Replace(".", ""), out var amountOwedInCents);
            var paidSuccess = int.TryParse(amountPaid.Replace(".", ""), out var amountPaidInCents);

            if (owedSuccess && paidSuccess)
            {
                //If change is a positive number, get the change.
                //If expecting 0 change, return an empty coin purse.
                //Example shows that denominations with 0 are ignored.
                var amountOwedInChange = amountPaidInCents - amountOwedInCents;
                if (amountOwedInChange > 0)
                {
                    returnValue = ChangeMaker.GetChange(amountOwedInCents, amountPaidInCents - amountOwedInCents);
                }
            }
            return returnValue;
        }


        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Get a nicely printed string describing contents of CoinPurse.
        /// </summary>
        /// <returns>Returns a string representing the quantities of coins in the current CoinPurse in plain English.</returns>
        public string GetCollectionVerboseString()
        {
            var returnValue = string.Empty;

            if (_coinCollection != null)
            {
                //Ensure collection is sorted biggest to smallest
                var returnBuilder = new StringBuilder();
                var allKeys = new List<Coin>(_coinCollection.Keys);

                allKeys.Sort();     //Put in order from smallest to largest (random collection not guaranteed to be in order)
                allKeys.Reverse();  //Reverse that order so it becomes largest to smallest

                foreach (var currentCoin in allKeys)
                {
                    var verboseStringToAdd = currentCoin.ToVerboseString(_coinCollection[currentCoin]);

                    if (!string.IsNullOrEmpty(verboseStringToAdd))
                    {
                        returnBuilder.Append($",{verboseStringToAdd}");
                    }
                }
                //Remove starting comma
                returnValue = returnBuilder.ToString().Substring(1);
            }
            return returnValue;
        }
        #endregion
    }
}
