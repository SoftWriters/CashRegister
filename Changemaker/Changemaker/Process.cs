using System.Text;
using Common;

namespace Changemaker
{

    public static class Process
    {
        /// <summary>
        /// Returns verbiage for the denominations to be used for change. 
        /// </summary>
        /// <param name="owed">Amount owed</param>
        /// <param name="paid">Amount paid</param>
        /// <returns></returns>
        public static string GetDenominations(string owed, string paid) => Start(owed.ToDecimal(), paid.ToDecimal());

        /// <summary>
        /// Returns verbiage for the denominations to be used for change. 
        /// </summary>
        /// <param name="owed">Amount owed</param>
        /// <param name="paid">Amount paid</param>
        /// <returns></returns>
        public static string Start(decimal owed, decimal paid)
        {
            var denominations = new Models.Denominations();
            var changeAmounts = new Models.ChangeAmounts(denominations);
            changeAmounts.remaining = paid - owed;
            changeAmounts.isRandom = ((owed * 100) % 3 == 0);  // true if divisible by 3
            var results = ChangeAlgorithm.Process(changeAmounts, denominations);
            #region Build string for return results.
            var sb = new StringBuilder();
            var comma = ""; // No leading comma.
            for (var index = denominations.changeItemsNames.Count - 1; index > -1; index--)
            {
                if (results.numberCoins[index] > 0) // if this specific denomination is used for this change collection.
                {
                    comma.Append(sb);
                    if (results.numberCoins[index] == 1)
                    {
                        "1 ".Append(sb);
                        denominations.changeItemsNames[index].Append(sb);
                    }
                    else
                    {
                        results.numberCoins[index].ToString().Append(sb);
                        " ".Append(sb);
                        denominations.changeItemsNamesPlural[index].Append(sb);
                    }
                    comma = ",";
                }
            }
            return sb.ToString();
            #endregion
        }
    }
}
