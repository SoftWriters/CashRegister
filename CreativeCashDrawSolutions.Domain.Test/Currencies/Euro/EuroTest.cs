using System.Linq;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies.Euro
{
    public class EuroTest
    {

        [Fact]
        public void Euro_Denominations_AreOrdered()
        {
            // This test will check that the implemented denominations are ordered correctly.
            var expected = new Domain.Currencies.Euro.Euro().GetDenominationTypes().Select(x => x.Value).OrderByDescending(x => x).ToArray();
            var actual = new Domain.Currencies.Euro.Euro().GetDenominationTypes().Select(x => x.Value).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}
