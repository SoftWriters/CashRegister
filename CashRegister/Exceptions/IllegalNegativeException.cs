using System;

namespace CashRegister.Exceptions
{
    public class IllegalNegativeException : Exception
    {
        public IllegalNegativeException(decimal value) : base($"{value} is not able to be null") { }
    }
}