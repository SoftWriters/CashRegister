using System.Linq;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies.UnitedStatesDollar
{
    public class UnitedStatesDollarTest
    {
        [Fact]
        public void UnitedStatesDollar_Denominations_AreOrdered()
        {
            // This test will check that the implemented denominations are ordered correctly.
            var expected = new Domain.Currencies.UnitedStatesDollar.UnitedStatesDollar().GetDenominationTypes().Select(x => x.Value).OrderByDescending(x => x).ToArray();
            var actual = new Domain.Currencies.UnitedStatesDollar.UnitedStatesDollar().GetDenominationTypes().Select(x => x.Value).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}
