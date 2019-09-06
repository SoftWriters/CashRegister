using System;
using Xunit;
using FluentAssertions;

namespace JasonCable.CashRegister.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CurrencyAmount ca = 10000.23m;
            ca.TotalPennies.Should().Be(1000023);
        }

        [Fact]
        public void Test2()
        {
            CurrencyAmount ca = 123.45m;
            ca.TotalOnes.Should().Be(123);
            ca.TotalTwenties.Should().Be(6);
            ca.TotalTens.Should().Be(12);
            ca.TotalFifties.Should().Be(2);
        }

        [Fact]
        public void Test3()
        {
            CurrencyAmount ca1 = new CurrencyAmount(123, 45);
            CurrencyAmount ca2 = new CurrencyAmount(1.1m);
            var ca3 = ca1 - ca2;
            ca3.Value.Should().Be(122.35m);
        }

        [Fact]
        public void Test4()
        {
            CurrencyAmount ca = new CurrencyAmount(1, 2, 3, 4);
            ca.Value.Should().Be(0.64m);
        }

        [Fact]
        public void Test5()
        {
            CurrencyAmount ca1 = new CurrencyAmount(5284.49m);
            CurrencyAmount ca2 = new CurrencyAmount(5500m);
            var result = ca1 - ca2;
            var change = result.LowestCommonDenominations();

            result.TotalPennies.Should().Be(21551);

            change.Hundreds.Should().Be(2);
            change.Tens.Should().Be(1);
            change.Fives.Should().Be(1);
            change.Quarters.Should().Be(2);
            change.Pennies.Should().Be(1);

            change.ToString().Should().Be("2 x $100; 1 x $10; 1 x $5; 2 x 25¢; 1 x 1¢; ");
        }

        [Fact]
        public void Test6()
        {   // 3.69
            CurrencyAmount ca1 = new CurrencyAmount(5m);
            CurrencyAmount ca2 = new CurrencyAmount(1.31m);
            var result = ca1 - ca2;
            var change1 = result.LowestCommonDenominations();
            var change2 = result.MixedUpDenominations();
            var change3 = result.MixUpDenominationsIfModThreePennies();

            change1.Ones.Should().Be(3);
            change1.Quarters.Should().Be(2);
            change1.Dimes.Should().Be(1);
            change1.Nickels.Should().Be(1);
            change1.Pennies.Should().Be(4);

            int change2Result = change2.Ones * CurrencyConversion.PenniesToDollar +
                change2.Quarters * CurrencyConversion.PenniesToQuarter +
                change2.Dimes * CurrencyConversion.PenniesToDime +
                change2.Nickels * CurrencyConversion.PenniesToNickel +
                change2.Pennies;

            change2Result.Should().Be(369);

            int change3Result = change3.Ones * CurrencyConversion.PenniesToDollar +
                change3.Quarters * CurrencyConversion.PenniesToQuarter +
                change3.Dimes * CurrencyConversion.PenniesToDime +
                change3.Nickels * CurrencyConversion.PenniesToNickel +
                change3.Pennies;

            change3Result.Should().Be(369);
        }
    }
}
