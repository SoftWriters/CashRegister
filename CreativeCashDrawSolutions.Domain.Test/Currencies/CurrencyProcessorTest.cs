using System.Collections.Generic;
using CreativeCashDrawSolutions.Domain.Currencies;
using CreativeCashDrawSolutions.Entities;
using CreativeCashDrawSolutions.Entities.Exceptions;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies
{
    public class CurrencyProcessorTest
    {
        private class MyFakeNoSolutionCurrency : CurrencyType
        {
            private readonly List<DenominationType> _denominations = new List<DenominationType>
            {
                new DenominationType { NameSingular = "seven", NamePlural = "sevens", Value = 7 }
            };

            protected override IEnumerable<DenominationType> Denominations
            {
                get { return _denominations; }
            }
        }

        private class MyFakeNoSolutionProcessor : CurrencyProcessor
        {
            public MyFakeNoSolutionProcessor() : base(new MyFakeNoSolutionCurrency()) { }
        }

        [Fact]
        public void WhenNoDenominationsExistToCompleteOnNormal_ThrowsException()
        {
            // In the event a denomination amount cannot be completed to give the change, throw an exception
            // ie. we need provide 3 back and the smallest demo. is 5
            var processor = new MyFakeNoSolutionProcessor();
            var exception = Record.Exception(() => processor.GetOutputString("1.95,2.00"));

            Assert.IsType(typeof(NoPossibleSolutionException), exception);
            Assert.Equal("Not completed due to not enough currency denominations.", exception.Message);
        }

        [Fact]
        public void WhenNoDenominationsExistToCompleteOnRandom_ThrowsException()
        {
            // In the event a denomination amount cannot be completed to give the change, throw an exception
            // ie. we need provide 3 back and the smallest demo. is 5
            var processor = new MyFakeNoSolutionProcessor();
            var exception = Record.Exception(() => processor.GetOutputString("3.00,4.00"));

            Assert.IsType(typeof(NoPossibleSolutionException), exception);
            Assert.Equal("Not completed due to not enough currency denominations.", exception.Message);
        }

        private class MyFakeMinimumCurrency : CurrencyType
        {
            private readonly List<DenominationType> _denominations = new List<DenominationType>
            {
                new DenominationType { NameSingular = "five", NamePlural = "fives", Value = 5 },
                new DenominationType { NameSingular = "three", NamePlural = "threes", Value = 3 },
                new DenominationType { NameSingular = "one", NamePlural = "ones", Value = 1 }
            };

            protected override IEnumerable<DenominationType> Denominations
            {
                get { return _denominations; }
            }
        }

        private class MyFakeMinimumProcessor : CurrencyProcessor
        {
            public MyFakeMinimumProcessor() : base(new MyFakeMinimumCurrency()) { }
        }

        [Fact]
        public void EnsureThatTheLeastAmountOfCoinsAreReturned()
        {
            // Ensure that if the coin denominations were 1, 3 and 4, then to make 6 we would use 3 and 3 and not 4, 1, 1
            const string expectedOutput = "2 threes";
            var processor = new MyFakeMinimumProcessor();
            var actual = processor.GetOutputString("0.04,0.10");
            Assert.Equal(expectedOutput, actual);
        }

        private class MyFakeMaximumCurrency : CurrencyType
        {
            private readonly List<DenominationType> _denominations = new List<DenominationType>
            {
                new DenominationType { NameSingular = "nine", NamePlural = "nines", Value = 9 },
                new DenominationType { NameSingular = "six", NamePlural = "sixes", Value = 6 },
                new DenominationType { NameSingular = "two", NamePlural = "twos", Value = 2 },
                new DenominationType { NameSingular = "one", NamePlural = "ones", Value = 1 }
            };

            protected override IEnumerable<DenominationType> Denominations
            {
                get { return _denominations; }
            }
        }

        private class MyFakeMaximumProcessor : CurrencyProcessor
        {
            public MyFakeMaximumProcessor() : base(new MyFakeMaximumCurrency()) { }
        }

        [Fact]
        public void EnsureThatTheLeastAmountOfCoinsReturnedWithTheLargestOneBeingUsed()
        {
            // If we had a two possible sets that were considered the minimum amounts, we should use the one with the highest coins
            const string expectedOutput = "1 nine,2 twos"; // The other possibility is 2 sixes and 1 one, our expected has the bigger number
            var processor = new MyFakeMaximumProcessor();
            var actual = processor.GetOutputString("0.02,0.15");
            Assert.Equal(expectedOutput, actual);
        }
    }
}
