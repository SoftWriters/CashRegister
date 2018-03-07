using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeMaker
{
    /// <summary>
    /// Transaction object for the processing of a cost and amount tendered.
    /// </summary>
    public class Transaction
    {
        private readonly decimal _cost;
        private readonly decimal _amtTendered;
        private readonly decimal _rawChange;
        private static int RandomizationDivisibility => 3;

        //'Change' consists of a list of Currencies and how many of each Currency there are to be provided to the customer.
        private List<Tuple<Currency, int>> Change;

        /// <summary>
        /// Transaction Constructor. Must provide a Cost and Amount Tendered.
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="amtTendered"></param>
        public Transaction(decimal cost, decimal amtTendered)
        {
            //Error checking
            if (cost < 0)
            {
                throw new InvalidOperationException("Error - cost cannot be less than 0");
            }

            if (amtTendered < 0)
            {
                throw new InvalidOperationException("Error - amt tendered cannot be less than 0");
            }

            if (amtTendered < cost)
            {
                throw new InvalidOperationException("Error - cost cannot exceed amt tendered");
            }

            _cost = cost;
            _amtTendered = amtTendered;
            _rawChange = Math.Round(_amtTendered - _cost, 2);
            Change = new List<Tuple<Currency, int>>();
        }

        #region Public methods

        /// <summary>
        /// Calculate the change for a transaction. If the cost is divisible by <RandomizationDivisibility> (default 3), a randomization is provided for what change to give the customer.
        /// </summary>
        public void CalculateChange()
        {
            if (ValidCurrencies.CurrencyList == null)
            {
                ValidCurrencies.Initialize();
            }

            var totalCurrencies = ValidCurrencies.CurrencyList.Count;
            if (totalCurrencies == 0)
            {
                throw new InvalidOperationException("No currencies to choose from. Cannot continue.");
            }

            if ((_cost * 100) % RandomizationDivisibility > 0)
            {
                CalculateChangeNormal();
            }
            else
            {
                CalculateChangeRandom();
            }
        }

        /// <summary>
        /// Display the change for a transaction.
        /// </summary>
        public void DisplayChange()
        {
            //Error handling
            if (Change == null)
            {
                Console.WriteLine("Error - Change is null");
                return;
            }

            if (Change.Count == 0)
            {
                Console.WriteLine("Change paid with exact change. No change necessary.");
                return;
            }

            if (ValidCurrencies.CurrencyList.Count == 0)
            {
                throw new InvalidOperationException("No currencies were loaded with which to create change");
            }

            //Start displaying the change
            var output = "";
            for (var i = 0; i < Change.Count; i++)
            {
                //Determine whether to output singular or plural denomination name
                var displayDenominationNamePluralOrSingular = Change[i].Item2 == 1 ? Change[i].Item1.Denomination : Change[i].Item1.DenominationPlural;

                //Write the line
                output += $"{Change[i].Item2} {displayDenominationNamePluralOrSingular}";

                //Write a comma if we're not done
                if (i < Change.Count - 1)
                {
                    output += ", ";
                }
            }

            Console.WriteLine(output);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Calculate the change in a normal fashion, by highest denomination to lowest.
        /// </summary>
        private void CalculateChangeNormal()
        {
            var currencyList = ValidCurrencies.CurrencyList.OrderByDescending(c => c.Value).ToList();
            var rollingChange = _rawChange;

            foreach (var currency in currencyList)
            {
                //For each denomination, if there can be at least one of that denomination in the amount of change to be provided, add it to the Change list and deduct it from the remaining change to be calculated.
                //Keep track of the remaining change as "Rolling Change".
                var totalForThisCurrency = CalculateNumberOfCurrencyInAmount(rollingChange, currency);
                if (totalForThisCurrency > 0)
                {
                    Change.Add(new Tuple<Currency, int>(currency, totalForThisCurrency));
                }

                rollingChange -= Math.Round(currency.Value * totalForThisCurrency, 2, MidpointRounding.ToEven);

                //Short-circuit the breaking of this loop so it doesn't waste time if the correct change is already calculated.
                if (rollingChange == 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Calculate the change in a random fashion. Calculates random denominations and random amounts of each denomination.
        /// </summary>
        private void CalculateChangeRandom()
        {
            //Get a list of all of the currencies to provide to the recursive change deduction method
            var allCurrenciesList = ValidCurrencies.CurrencyList.OrderByDescending(c => c.Value).ToList();

            //Recursively determine a randomized sequence of change to be provided
            DeductFromChange(_rawChange, allCurrenciesList);

            //Flatten the list of change so it doesn't have duplicate denominations
            AggregateChange();
        }

        /// <summary>
        /// Recursive method to provide support for change randomization.
        /// </summary>
        /// <param name="rollingChange"></param>
        /// <param name="currentCurrencyList"></param>
        private void DeductFromChange(decimal rollingChange, List<Currency> currentCurrencyList)
        {
            //Remove currencies that are worth more than the raw change value, as we may have already deducted some change, or started below the highest-valued denomination
            var validCurrencyList = new List<Currency>();

            foreach (var currency in currentCurrencyList)
            {
                if (currency.Value <= rollingChange)
                {
                    validCurrencyList.Add(currency);
                }
            }

            //Get a random denomination (i.e. "Dollar", "Dime")
            var validCurrencyCount = validCurrencyList.Count - 1;
            var randomCurrencyNumber = Utils.GetRandomNumber(0, validCurrencyCount);
            var randomCurrencyToUse = validCurrencyList[randomCurrencyNumber];

            //Get a random amount of that denomination (i.e. 27 Nickels). Limit the random number to how many of that denomination can fit inside the current "Rolling Change" amount.
            var totalDenominationsForThisCurrency = CalculateNumberOfCurrencyInAmount(rollingChange, randomCurrencyToUse);
            var randomNumberOfCurrency = Utils.GetRandomNumber(1, totalDenominationsForThisCurrency);

            //If at least one of the random denomination can fit in the remaining "Rolling Change" amount, add it to the Change list, then deduct it from the "Rolling Change".
            if (totalDenominationsForThisCurrency > 0)
            {
                Change.Add(new Tuple<Currency, int>(randomCurrencyToUse, randomNumberOfCurrency));
                rollingChange -= Math.Round(randomCurrencyToUse.Value * randomNumberOfCurrency, 2);
            }

            //Keep repeating until the change is down to 0
            if (rollingChange == 0)
            {
                return;
            }

            DeductFromChange(rollingChange, validCurrencyList);
        }

        /// <summary>
        /// Flatten the Change list so there are no duplicates after the change is calculated within the Randomization function, i.e. flatten "3 Quarters" and "1 Quarter" to "4 Quarters".
        /// </summary>
        private void AggregateChange()
        {
            var newChangeList = new List<Tuple<Currency, int>>();

            //Basically just zip through the Valid Currency list and add each denomination if it's in the Change list, along with the sum of each of that denomination in the Change list.
            //Could be done with additional LINQ stuff but this seems more readable.
            foreach (var c in ValidCurrencies.CurrencyList)
            {
                var currentCurrency = Change.Where(change => change.Item1.Denomination.Equals(c.Denomination));
                var totalCur = currentCurrency.Sum(cur => cur.Item2);

                if (totalCur > 0)
                {
                    newChangeList.Add(new Tuple<Currency, int>(c, totalCur));
                }
            }

            Change = newChangeList;
        }

        /// <summary>
        /// Get the total number of distinct instances of a currency that could be made from a provided amount.
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        private static int CalculateNumberOfCurrencyInAmount(decimal amount, Currency currency)
        {
            var dividend = Math.Floor(amount / currency.Value);
            return Convert.ToInt32(dividend);
        }

        #endregion
    }
}
