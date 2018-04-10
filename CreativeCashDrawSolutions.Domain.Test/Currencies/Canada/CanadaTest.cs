using System.Linq;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies.Canada
{
    public class CanadaTest
    {
        [Fact]
        public void Canada_Denominations_AreOrdered()
        {
            // This test will check that the implemented denominations are ordered correctly.
            var expected = new Domain.Currencies.Canada.Canada().GetDenominationTypes().Select(x => x.Value).OrderByDescending(x => x).ToArray();
            var actual = new Domain.Currencies.Canada.Canada().GetDenominationTypes().Select(x => x.Value).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}
