using System.Collections.Generic;
using System.Linq;
using CreativeCashDrawSolutions.Entities.Helpers;
using Xunit;

namespace CreativeCashDrawSolutions.Entities.Test.Helpers
{
    public class RadomNumberHelperTest
    {
        [Fact]
        public void ValidateRandomNumbersAreBeingRandom()
        {
            const int numbersToTry = 4;
            var randoms = new List<int>();
            for (var i = 0; i < numbersToTry; i++)
            {
                randoms.Add(RandomNumberHelper.RandomNumber(1, 100));
            }

            var countOfRandoms = randoms.Select(x => x).Distinct().Count();
            Assert.NotEqual(1, countOfRandoms);
        }
    }
}
