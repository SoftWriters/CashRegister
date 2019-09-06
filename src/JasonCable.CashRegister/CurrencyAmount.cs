using System;
using MathNet.Numerics;
using MathNet.Numerics.Random;

namespace JasonCable.CashRegister
{
    public struct CurrencyAmount :
        IEquatable<CurrencyAmount>,
        IComparable<CurrencyAmount>,
        IComparable<decimal>
    {
        public decimal Value { get; private set; }
        public static CurrencyAmount Zero => default;

        public CurrencyAmount(decimal amount) => Value = Math.Abs(amount);
        public CurrencyAmount(int dollars, int cents) => Value = Math.Abs((decimal)dollars + (decimal)cents / (decimal)100);

        public CurrencyAmount(int hundreds, int fifties, int twenties, int tens, int fives, int ones, int quarters, int dimes, int nickels, int pennies)
        {
            int dollars = 0;
            int cents = 0;
            dollars += hundreds * CurrencyConversion.OnesToHundred;
            dollars += fifties * CurrencyConversion.OnesToFifty;
            dollars += twenties * CurrencyConversion.OnesToTwenty;
            dollars += tens * CurrencyConversion.OnesToTen;
            dollars += fives * CurrencyConversion.OnesToFive;
            dollars += ones;
            cents += quarters * CurrencyConversion.PenniesToQuarter;
            cents += dimes * CurrencyConversion.PenniesToDime;
            cents += nickels * CurrencyConversion.PenniesToNickel;
            cents += pennies;

            this.Value = Math.Abs((decimal)dollars + (decimal)cents / 100m);
        }

        public CurrencyAmount(int dollars, int quarters, int dimes, int nickels, int pennies) :
            this(0, 0, 0, 0, 0, dollars, quarters, dimes, nickels, pennies) { }

        public CurrencyAmount(int quarters, int dimes, int nickels, int pennies) :
            this(0, 0, 0, 0, 0, 0, quarters, dimes, nickels, pennies)
        { }

        public int TotalPennies => Decimal.ToInt32(this.Value * 100m);
        public int TotalNickels => TotalPennies / CurrencyConversion.PenniesToNickel;
        public int TotalDimes => TotalPennies / CurrencyConversion.PenniesToDime;
        public int TotalQuarters => TotalPennies / CurrencyConversion.PenniesToQuarter;
        public int TotalOnes => Decimal.ToInt32(this.Value);
        public int TotalFives => Decimal.ToInt32(this.Value) / CurrencyConversion.OnesToFive;
        public int TotalTens => Decimal.ToInt32(this.Value) / CurrencyConversion.OnesToTen;
        public int TotalTwenties => Decimal.ToInt32(this.Value) / CurrencyConversion.OnesToTwenty;
        public int TotalFifties => Decimal.ToInt32(this.Value) / CurrencyConversion.OnesToFifty;
        public int TotalHundreds => Decimal.ToInt32(this.Value) / CurrencyConversion.OnesToHundred;

        public CurrencyChange LowestCommonDenominations()
        {
            if (this.Value * 100 % 1 != 0)
                throw new ApplicationException("Partial pennies found!!!");

            int penniesLeft = Decimal.ToInt32(this.Value * 100m);
            CurrencyChange change = new CurrencyChange();

            change.Hundreds = CalcPart(CurrencyConversion.PenniesToHundred, ref penniesLeft);
            change.Fifties = CalcPart(CurrencyConversion.PenniesToFifty, ref penniesLeft);
            change.Twenties = CalcPart(CurrencyConversion.PenniesToTwenty, ref penniesLeft);
            change.Tens = CalcPart(CurrencyConversion.PenniesToTen, ref penniesLeft);
            change.Fives = CalcPart(CurrencyConversion.PenniesToFive, ref penniesLeft);
            change.Ones = CalcPart(CurrencyConversion.PenniesToDollar, ref penniesLeft);
            change.Quarters = CalcPart(CurrencyConversion.PenniesToQuarter, ref penniesLeft);
            change.Dimes = CalcPart(CurrencyConversion.PenniesToDime, ref penniesLeft);
            change.Nickels = CalcPart(CurrencyConversion.PenniesToNickel, ref penniesLeft);
            change.Pennies = penniesLeft;

            return change;
        }

        public CurrencyChange MixedUpDenominations()
        {
            if (this.Value * 100 % 1 != 0)
                throw new ApplicationException("Partial pennies found!!!");

            int penniesLeft = Decimal.ToInt32(this.Value * 100m);
            CurrencyChange change = new CurrencyChange();

            change.Hundreds = CalcRandomPart(CurrencyConversion.PenniesToHundred, ref penniesLeft);
            change.Fifties = CalcRandomPart(CurrencyConversion.PenniesToFifty, ref penniesLeft);
            change.Twenties = CalcRandomPart(CurrencyConversion.PenniesToTwenty, ref penniesLeft);
            change.Tens = CalcRandomPart(CurrencyConversion.PenniesToTen, ref penniesLeft);
            change.Fives = CalcRandomPart(CurrencyConversion.PenniesToFive, ref penniesLeft);
            change.Ones = CalcRandomPart(CurrencyConversion.PenniesToDollar, ref penniesLeft);
            change.Quarters = CalcRandomPart(CurrencyConversion.PenniesToQuarter, ref penniesLeft);
            change.Dimes = CalcRandomPart(CurrencyConversion.PenniesToDime, ref penniesLeft);
            change.Nickels = CalcRandomPart(CurrencyConversion.PenniesToNickel, ref penniesLeft);
            change.Pennies = penniesLeft;

            return change;
        }

        public CurrencyChange MixUpDenominationsIfModThreePennies()
        {
            if (this.Value * 100 % 1 != 0)
                throw new ApplicationException("Partial pennies found!!!");

            bool isModThree = Decimal.ToInt32(this.Value * 100m) % 3 == 0;

            if (isModThree)
                return MixedUpDenominations();
            else
                return LowestCommonDenominations();
        }

        private int CalcRandomPart(int divisor, ref int amountLeft)
        {
            if (amountLeft == 0)
                return 0;

            var random = new MersenneTwister(RandomSeed.Robust());
            var max = amountLeft / divisor;
            if (max == 0)
                return 0;

            var i = Math.Abs(random.NextFullRangeInt32() % max);

            amountLeft -= divisor * i;
            return i;
        }

        private int CalcPart(int divisor, ref int amountLeft)
        {
            if (amountLeft == 0)
                return 0;
            var i = amountLeft / divisor;
            amountLeft -= i * divisor;
            return i;
        }

        public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
        {
            return a.Value != b.Value;
        }

        public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
        {
            return new CurrencyAmount(Math.Abs(a.Value + b.Value));
        }

        public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
        {
            return new CurrencyAmount(Math.Abs(a.Value - b.Value));
        }

        public static implicit operator CurrencyAmount (decimal d)
        {
            return new CurrencyAmount(Math.Abs(d));
        }

        public bool Equals(CurrencyAmount other)
        {
            return other.Value == this.Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public int CompareTo(CurrencyAmount other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public int CompareTo(decimal other)
        {
            return this.Value.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return obj is CurrencyAmount && this.Value == ((CurrencyAmount)obj).Value;
        }
    }
}
