using System.Collections.Generic;
using System.Linq;
using CreativeCashDrawSolutions.Entities.Exceptions;
using CreativeCashDrawSolutions.Entities.Helpers;

namespace CreativeCashDrawSolutions.Domain.Currencies
{
    /// <summary>This class is responsible for defining how to process a currency in the library.</summary>
    public abstract class CurrencyProcessor
    {
        private readonly CurrencyType _type;
        private readonly int[] _coins;

        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <param name="type">The currency type to be used by the processor.</param>
        protected CurrencyProcessor(CurrencyType type)
        {
            _type = type;
            _coins = _type.GetDenominationTypes().Select(x => x.Value).ToArray();
        }

        /// <summary>This routine is reponsible for taking the defined pattern for an input string and providing the appropriate output.</summary>
        /// <param name="totalAndPaid">The value owed and paid seperated by a comma [x.xx, y.yy].</param>
        /// <returns>A string description of the denominations that are needed to make correct change.</returns>
        public string GetOutputString(string totalAndPaid)
        {
            int due, paid;
            InputStringHelper.InputStringToInts(totalAndPaid, out due, out paid);
            var difference = due - paid;
            return InputStringHelper.ShouldBeRandom(totalAndPaid) ? GetOutputString(difference, true) : GetOutputString(difference);
        }

        /// <summary>This routine is responsible for ordering, grouping and counting the denominations.</summary>
        /// <param name="total">The total amount of change that is due to the caller.</param>
        /// <param name="randomize">true if the denominations should be randomized.</param>
        /// <returns>A collection of the denomination amount along with the count of items in each.</returns>
        private Dictionary<int, int> GetChangeSolution(int total, bool randomize = false)
        {
            var solution = EvaluateDenomination(total, randomize);

            // We have a list of minimum coins needed, count and order them
            var result = solution
                .GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .Select(g => new
                {
                    Currency = g.Key,
                    Total = g.Count()
                });

            return result.ToDictionary(x => x.Currency, x => x.Total);
        }

        /// <summary>
        /// This routine is reponsible for taking the amount due to the caller and providing the
        /// appropriate output.
        /// </summary>
        /// <param name="total">The total amount of change that is due to the caller.</param>
        /// <param name="random">true if the denominations should be randomized.</param>
        /// <returns>
        /// A string description of the denominations that are needed to make correct change.
        /// </returns>
        private string GetOutputString(int total, bool random = false)
        {
            var strings = new List<string>();
            var change = GetChangeSolution(total, random);
            foreach (var i in change)
            {
                strings.Add(_type.GetOutputStringByValue(i.Key, i.Value));
            }
            return string.Join(",", strings);
        }

        /// <summary>This routine is responsible for getting a grid of all possible solutions for owed amount and denominations supported.</summary>
        /// <param name="solutions">A reference to the solution grid.</param>
        /// <param name="currentSum">The total amount of change that needs to be evaluated.</param>
        /// <param name="minCoin">The minimum coin.</param>
        /// <param name="commmaSeperatedList">Running commma seperated string of coins to return.</param>
        private void GetEntireGrid(ICollection<List<int>> solutions, int currentSum, int minCoin, string commmaSeperatedList)
        {
            // TODO: This needs to be optimized, this could take a considerable amount of time
            for (var i = minCoin; i < _coins.Length; i++)
            {
                var change = commmaSeperatedList;
                var sum = currentSum;

                while (sum > 0)
                {
                    if (!string.IsNullOrEmpty(change)) change += ",";
                    change += _coins[i];

                    sum -= _coins[i];
                    if (sum > 0)
                    {
                        GetEntireGrid(solutions, sum, i + 1, change);
                    }
                }

                if (sum != 0) continue;

                // When we are done with the current run, add it to the solutions list
                var items = change.Split(',').Select(int.Parse).ToList();
                solutions.Add(items);
            }
        }

        /// <summary>
        /// This routine is responsible for evaluating which type of calculation needs to be performed on
        /// the data.
        /// </summary>
        /// <exception cref="NoPossibleSolutionException">
        /// Thrown when no possible solution can be found.
        /// </exception>
        /// <param name="total">The total amount of change that is due to the caller.</param>
        /// <param name="random">true if the denominations should be randomized.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process evaluate denomination in this
        /// collection.
        /// </returns>
        private IEnumerable<int> EvaluateDenomination(int total, bool random = false)
        {
            // Taking a slow route by calculating all the possibilities and grabbing a random one out of it O(n < 20) solutions do not randomize very well
            if (random)
            {
                var solutionGrid = new List<List<int>>();
                GetEntireGrid(solutionGrid, total, 0, string.Empty);
                var countOfSolutions = solutionGrid.Count;
                if (countOfSolutions == 0)
                {
                    throw new NoPossibleSolutionException("Not completed due to not enough currency denominations.");
                }
                var itemToGet = RandomNumberHelper.RandomNumber(1, countOfSolutions);
                return solutionGrid[itemToGet];
            }


            // Building a couple of scratch tables to perform evaluations
            var workingGrid = new int[total + 1];
            var coinPlaceholder = new int[total + 1];

            workingGrid[0] = 0;

            for (var i = 1; i <= total; i++)
            {
                // This will fail if someone ever makes a currency this large
                workingGrid[i] = int.MaxValue - 1;
                coinPlaceholder[i] = -1;
            }

            // Evaluate using DP technique
            for (var j = 0; j < _coins.Length; j++)
            {
                for (var i = 1; i <= total; i++)
                {
                    if (i < _coins[j]) continue;

                    if (workingGrid[i - _coins[j]] + 1 >= workingGrid[i]) continue;

                    workingGrid[i] = 1 + workingGrid[i - _coins[j]];
                    coinPlaceholder[i] = j;
                }
            }
            
            if (coinPlaceholder[coinPlaceholder.Length - 1] == -1)
            {
                throw new NoPossibleSolutionException("Not completed due to not enough currency denominations.");
            }
            var start = coinPlaceholder.Length - 1;

            var neededDenominations = new List<int>();
            while (start != 0)
            {
                var j = coinPlaceholder[start];
                neededDenominations.Add(_coins[j]);
                start = start - _coins[j];
            }

            return neededDenominations;
        }

    }
}
