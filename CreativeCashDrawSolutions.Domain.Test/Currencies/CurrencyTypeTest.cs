using System.Collections.Generic;
using CreativeCashDrawSolutions.Domain.Currencies;
using CreativeCashDrawSolutions.Entities;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies
{
    public class CurrencyTypeTest
    {
        private class MyFakeTestingCurrency : CurrencyType
        {
            private readonly List<DenominationType> _denominations = new List<DenominationType>
            {
                new DenominationType { NameSingular = "one", NamePlural = "ones", Value = 1 }
            };

            protected override IEnumerable<DenominationType> Denominations
            {
                get { return _denominations; }
            }
        }

        [Fact]
        public void EnsureThatWhenOneItemReturnedItIsSingular()
        {
            // 1 quarter should not be plural
            var actual = new MyFakeTestingCurrency().GetOutputStringByValue(1, 1);
            Assert.Equal("1 one", actual);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void EnsureThatWhenMultipleItemsReturnedItIsPlural(int count)
        {
            // 3 quarters should not be singular
            var actual = new MyFakeTestingCurrency().GetOutputStringByValue(1, count);
            Assert.Equal(string.Format("{0} ones", count), actual);
        }
    }
}
