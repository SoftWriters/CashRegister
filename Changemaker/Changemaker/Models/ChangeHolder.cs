using System.Collections.Generic;

namespace Changemaker.Models
{
    /// <summary>
    /// Amounts and settings for the change.
    /// </summary>
    public class ChangeAmounts
    {
        #region Accessors
        /// <summary>
        /// Is randomly generated change denominations requested?
        /// </summary>
        public bool isRandom { get; set; }
        /// <summary>
        /// Amount of change remaining
        /// </summary>
        public decimal remaining { get; set; }
        /// <summary>
        /// number of coins/bills for each denomination
        /// </summary>
        public List<int> numberCoins { get; set; }
#endregion

        /// <summary>
        /// Amounts and settings for the change.
        /// </summary>
        /// <param name="denominations">Denominations being used</param>
        public ChangeAmounts(Models.Denominations denominations)
        {
            this.isRandom = false; // default to false
            this.numberCoins = new List<int>();
            for (int i = 0; i < denominations.changeDenominationValues.Count;  i++) // add counter for each denomination
            {
                this.numberCoins.Add(0); // start coin/bill count at 0.
            }
        }


    }
}
