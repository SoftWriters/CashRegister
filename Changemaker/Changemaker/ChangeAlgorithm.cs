using Changemaker.Models;
using Common;

namespace Changemaker
{
    public class ChangeAlgorithm
    {
        /// <summary>
        /// Check usage for current denomination, add appropriate counts for denomination, and process the next lower denomination via recursion.
        /// </summary>
        /// <param name="change">Current change amounts</param>
        /// <param name="denominations">Denominations available</param>
        /// <returns></returns>
        public static ChangeAmounts Process(ChangeAmounts change, Denominations denominations)
        {
            var denominationAmount = denominations.changeDenominationValues[denominations.index]; // value of coin or bill.
            if (change.remaining >= denominationAmount) // If this denomination can be used.
            {
                int numberCoinsAllowed = (change.remaining / denominationAmount).ToInt();
                #region randomize
                if (change.isRandom && denominations.index > 0) // Cannot randomize the lowest denomination. ie. pennies 
                {
                    numberCoinsAllowed = numberCoinsAllowed.RandomizeIntTo();
                }
                #endregion
                change.numberCoins[denominations.index] = numberCoinsAllowed;
                change.remaining = change.remaining - (numberCoinsAllowed * denominationAmount);
            }
            if (denominations.index > 0 && change.remaining > 0) // continue recursion if change remains and if not the last denomination. ie. pennies 
            {
                denominations.index--; // use the next denomination in list.
                Process(change, denominations);
            }
            return change;
        }
    }
}