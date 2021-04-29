using System.Collections.Generic;
using CashRegister.Core.Denominations;
using CashRegister.Generators;

namespace CashRegister.Core
{
    public static class ChangeMaker
    {
        #region Private Members

        //Instructions say for values divisible by 3 to use the random change.
        private const int RandomnessDivisor = 3;

        //List of all denominations of coins to be used for change.
        //In order from smallest to largest.
        private static readonly List<Coin> AllDenominations = new List<Coin>
        {
            new Penny(),
            new Nickel(),
            new Dime(),
            new Quarter(),
            new Dollar()
        };
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Determines whether to return "perfect" change or "random" change.
        /// </summary>
        /// <param name="amountOwedInCents">Int for amount owed in cents.</param>
        /// <param name="amountOfChangeInCents">Int for amount of change needed in cents.</param>
        /// <returns>Returns a CoinPurse object containing the denominations comprising the correct change.</returns>
        public static CoinPurse GetChange(int amountOwedInCents, int amountOfChangeInCents)
        {
            //Check to see if we need to randomize change given back
            var returnValue = amountOwedInCents % RandomnessDivisor == 0 ?
                GetRandomChange(amountOfChangeInCents) :
                GetPerfectChange(amountOfChangeInCents);

            return returnValue;
        }
        #endregion

        #region Private Methods

        #region Methods for Random Change
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Generates the proper change required with random coins chosen.
        /// </summary>
        /// <param name="amountOfChange">The total amount of change required, in cents.</param>
        /// <returns>Returns a CoinPurse containing proper change in random denominations.</returns>
        private static CoinPurse GetRandomChange(int amountOfChange)
        {
            //With random, on each pass, pick a single coin of a random value and subtract from total until complete.
            //Do checks for new ranges of randomness so we don't have wasted passes.
            //We don't want be able to select a coin that is higher than the change left to give out.
            var returnedCoins = new Dictionary<Coin, int>();
            var currentChangeAmount = amountOfChange;

            //There is still change to be given out, so...
            while (currentChangeAmount > 0)
            {
                var currentCoin = GetRandomCoin(currentChangeAmount);
                var currentCoinCount = 1; //Returning a single coin of random type
                if (returnedCoins.ContainsKey(currentCoin))
                {
                    returnedCoins[currentCoin] = returnedCoins[currentCoin] + currentCoinCount;
                }
                else
                {
                    returnedCoins.Add(currentCoin, currentCoinCount);
                }
                //We don't allow the ability to pick coins with values higher than the change remaining, so this will never be negative.
                currentChangeAmount = currentChangeAmount - (currentCoinCount * currentCoin.CentValue);
            }
            return new CoinPurse(returnedCoins);
        }

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Returns the maximum upper bound for the amount of change remaining.
        ///             For example, there is no point to potentially randomly select dollars,
        ///             if the total change left is less than 100 cents.
        /// </summary>
        /// <param name="currentChangeAmount">The remaining amount of change required, in cents.</param>
        /// <returns></returns>
        private static int GetDenominationUpperBound(int currentChangeAmount)
        {
            //This is the default selection that will get replaced from the loop later
            Coin holdCoin = new Penny();

            //Start with largest denomination and work the way down the chain
            for (var i = AllDenominations.Count - 1; i >= 0; i--)
            {
                var currentCoin = AllDenominations[i];

                if (currentChangeAmount >= currentCoin.CentValue)
                {
                    holdCoin = currentCoin;
                    break;
                }
            }

            //We are adding +1 for passing to the randomness method,
            //because the upper bound is exclusive,
            //meaning that it will never pick that number randomly.
            var returnValue = AllDenominations.LastIndexOf(holdCoin) + 1;

            return returnValue;
        }

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Get a random coin, based on how much change remains to be paid.
        ///             We want to avoid trying to pick a coin that is higher than the remaining amount.
        /// </summary>
        /// <param name="currentChangeAmount">Current amount of change to be paid.</param>
        /// <returns>Returns a Coin object representing a random coin denomination.</returns>
        private static Coin GetRandomCoin(int currentChangeAmount)
        {
            //Pick a random number in the valid range (current valid denominations)
            //Determine upper bound of random range
            var upperBound = GetDenominationUpperBound(currentChangeAmount);
            var lowerBound = 0;  //Always 0, which is the lowest index in the collection

            var randomCoinIndex = RandomIntegerGenerator.GetRandomNumber(lowerBound, upperBound);
            var currentCoin = AllDenominations[randomCoinIndex];
            return currentCoin;
        }

        #endregion

        #region Methods for Perfect Change
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Generates the proper change required with the most efficient coins chosen.
        /// </summary>
        /// <param name="amountOfChange">The total amount of change required, in cents.</param>
        /// <returns>Returns a CoinPurse containing proper change using least amount of possible coins.</returns>
        private static CoinPurse GetPerfectChange(int amountOfChange)
        {
            var returnedCoins = new Dictionary<Coin, int>();
            var currentChangeAmount = amountOfChange;

            //Start with largest denomination and work the way down the chain
            for (int i = AllDenominations.Count - 1; i >= 0; i--)
            {
                var currentCoin = AllDenominations[i];
                var currentCoinCount = GetCountOfCoins(currentCoin, currentChangeAmount);
                returnedCoins.Add(currentCoin, currentCoinCount);
                currentChangeAmount = currentChangeAmount - (currentCoinCount * currentCoin.CentValue);
            }
            return new CoinPurse(returnedCoins);
        }

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Returns the most amount of coins possible to be returned for a particular denomination.
        /// </summary>
        /// <param name="currentCoin">The desired denomination.</param>
        /// <param name="currentChangeAmount">The remaining amount of change required, in cents.</param>
        /// <returns></returns>
        private static int GetCountOfCoins(Coin currentCoin, int currentChangeAmount)
        {
            var coinsToReturn = 0;

            if (currentChangeAmount > currentCoin.CentValue)
            {
                coinsToReturn = currentChangeAmount / currentCoin.CentValue;
            }
            return coinsToReturn;
        }
        #endregion

        #endregion
    }
}
