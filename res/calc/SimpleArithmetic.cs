//Math utility class for common program operations.
using System;
using CCDS.res.ctrls.console.io.input;

namespace CCDS.res.calc
{
    class SimpleArithmetic
    {
        private decimal _minuend;
        private decimal _subtrahend;
        private long _dividend;
        private long _divisor;
        private long _randoMinOperand;
        private long _randoMaxOperand;
        public long GetRandomNumber()
        {
            byte[] buf = new byte[8];  // creates rando number between provided range by filling an array of bytes to contain random numbers. 
            new Random().NextBytes(buf);
            return Math.Abs(BitConverter.ToInt64(buf, 0) % ((GetRandomNumberMax() + 1) - GetRandomNumberMin())) + GetRandomNumberMin(); 
        }
        public long GetRandomNumber(long min, long max)
        {
            SetRandomNumberMin(min);
            SetRandomNumberMax(max);
            return GetRandomNumber();
        }
        public void SetRandomNumberMin(long min)
        {
            _randoMinOperand = min;
        }
        public long GetRandomNumberMin()
        {
            return _randoMinOperand;
        }
        public long GetRandomNumberMax()
        {
            return _randoMaxOperand;
        }
        public void SetRandomNumberMax(long max)
        {
            _randoMaxOperand = max;
        }
        public void SetRandomNumberRange(long min, long max)
        {
            SetRandomNumberMin(min);
            SetRandomNumberMax(max);
        }
        private void SetSubtrahend(decimal operand)
        {
            _subtrahend = operand;
        }
        private void SetDivisor(long operand)
        {
            _divisor = operand;
        }
        private void SetDividend(long operand)
        {
            _dividend = operand;
        }
        public long GetDividend()
        {
            return _dividend;
        }
        public long GetDivisor()
        {
            return _divisor;
        }
        public long GetModulus()
        {
            return (GetDivisor() % GetDividend());
        }
        public long GetModulus(long divisor, long dividend)
        {
            SetDivisor(divisor);
            SetDividend(dividend);
            return GetModulus();
        }
        private void SetMinuend(decimal operand)
        {
            _minuend = operand;
        }
        public decimal GetSubtrahend()
        {
            return _subtrahend;
        }
        public decimal GetMinuend()
        {
            return _minuend;
        }
        public decimal GetDifference()
        {
            return (GetMinuend() - GetSubtrahend());
        }
        public decimal GetDifference(decimal minuend, decimal subtrahend)
        {
            SetMinuend(minuend);
            SetSubtrahend(subtrahend);
            return GetDifference();
        }
        public long GetSubtrahend(Parser convertType)
        {
            return convertType.ParseLong(_subtrahend);
        }
        public long GetMinuend(Parser convertType)
        {
            return convertType.ParseLong(_minuend);
        }
        public long GetDifference(Parser convertType)
        {
            return convertType.ParseLong(GetMinuend() - GetSubtrahend());
        }
        public long GetDifference(long minuend, long subtrahend, Parser convertType)
        {
            SetMinuend(minuend);
            SetSubtrahend(subtrahend);
            return GetDifference(convertType);
        }
    }
}