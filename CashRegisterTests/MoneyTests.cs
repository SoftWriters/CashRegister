using CashRegisterConsumer;
using Moq;
using Xunit;

namespace MoneyTests
{
    public class MoneyTests
    {
        #region Setup

        public MoneyTests()
        {
        }

        #endregion Setup

        [Fact]
        public void MoneyConstructionSetsDenominationAccurately()
        {
            decimal expected = 0.01m;
            Money money = new MoneyTestMoney(0.01m, "test", "tests", 3);

            Assert.Equal(expected, money.Denomination);
        }

        [Fact]
        public void MoneyConstructionSetsSingularNameAccurately()
        {
            string expected = "test";
            Money money = new MoneyTestMoney(0.01m, "test", "tests", 1);

            Assert.Equal(expected, money.Name);
        }

        [Fact]
        public void MoneyConstructionSetsPluralNameAccurately()
        {
            string expected = "tests";
            Money money = new MoneyTestMoney(0.01m, "test", "tests");

            Assert.Equal(expected, money.Name);
        }

        [Fact]
        public void MoneyConstructionSetsPluralNameWithZeroCount()
        {
            string expected = "tests";
            Money money = new MoneyTestMoney(0.01m, "test", "tests");

            Assert.Equal(expected, money.Name);
        }

        [Fact]
        public void MoneyAddsCorrectAmount()
        {
            Money money = new MoneyTestMoney(1, "test", "tests");
            Assert.Equal(0, money.Count);

            money.Add(1);
            Assert.Equal(1, money.Count);

            money.Add(-1);
            Assert.Equal(0, money.Count);
        }

        [Fact]
        public void MoneySubtractsCorrectAmount()
        {
            Money money = new MoneyTestMoney(1, "test", "tests", 5);
            Assert.Equal(5, money.Count);

            money.Subtract(1);
            Assert.Equal(4, money.Count);

            money.Subtract(-1);
            Assert.Equal(5, money.Count);
        }

        [Fact]
        public void MoneyClearsCount()
        {
            Money money = new MoneyTestMoney(1, "test", "tests", 5);
            Assert.Equal(5, money.Count);

            money.Clear();
            Assert.Equal(0, money.Count);
        }

        [Fact]
        public void MoneyCompareToReturnsZeroWhenEqual()
        {
            Mock<Money> moneyToCompare = new Mock<Money>(1m, "compare", "compares");
            Mock<Money> moneyToCompareTo = new Mock<Money>(1m, "compare", "compares");

            Assert.Equal(0, moneyToCompare.Object.CompareTo(moneyToCompareTo.Object));
        }

        [Fact]
        public void MoneyCompareToReturnsOneWhenMoreThan()
        {
            Mock<Money> moneyToCompare = new Mock<Money>(1m, "compare", "compares");
            Mock<Money> moneyToCompareTo = new Mock<Money>(0.50m, "compare", "compares");

            Assert.Equal(1, moneyToCompare.Object.CompareTo(moneyToCompareTo.Object));
        }

        [Fact]
        public void MoneyCompareToReturnsMinusOneWhenLessThan()
        {
            Mock<Money> moneyToCompare = new Mock<Money>(0.5m, "compare", "compares");
            Mock<Money> moneyToCompareTo = new Mock<Money>(1m, "compare", "compares");

            Assert.Equal(-1, moneyToCompare.Object.CompareTo(moneyToCompareTo.Object));
        }
    }

    #region MoneyTestClass

    public class MoneyTestMoney : Money
    {
        public MoneyTestMoney(decimal denomination, string singleName, string pluralName) : base(denomination, singleName, pluralName)
        {
        }

        public MoneyTestMoney(decimal denomination, string singleName, string pluralName, int count) : base(denomination, singleName, pluralName, count)
        {
        }
    }

    #endregion MoneyTestClass
}