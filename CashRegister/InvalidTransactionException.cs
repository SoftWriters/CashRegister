using System;

namespace CashRegister
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base(message) { }

        public InvalidTransactionException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidTransactionException() { }
    }
}
