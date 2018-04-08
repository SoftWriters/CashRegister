using System.Collections.Generic;
using System.Linq;
using CreativeCashDrawSolutions.Entities.Exceptions;
using CreativeCashDrawSolutions.Entities.Helpers;

namespace CreativeCashDrawSolutions.Domain.Currencies
{
    public abstract class CurrencyProcessor
    {
        private readonly CurrencyType _type;
        private readonly int[] _coins;

        protected CurrencyProcessor(CurrencyType type)
        {
            _type = type;
            _coins = _type.GetDenominationTypes().Select(x => x.Value).ToArray();
        }

        public string GetOutputString(string totalAndPaid)
        {
            int due, paid;
            InputStringHelper.InputStringToInts(totalAndPaid, out due, out paid);
            var difference = due - paid;
            return InputStringHelper.ShouldBeRandom(totalAndPaid) ? GetOutputString(difference, true) : GetOutputString(difference);
        }

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

        private IEnumerable<int> EvaluateDenomination(int total, bool random = false)
        {
            // Taking a slow route by calculating all the possibilities and grabbing a random one out of it O(n < 20) solutions do not randomize very well since the 
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
