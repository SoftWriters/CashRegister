using System;
using System.Runtime.Serialization;

namespace CashRegisterConsumer
{
    /// <summary>
    /// Custom exception for clarity of code and exception handling
    /// </summary>
    [Serializable]
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException()
        {
        }

        public InvalidCurrencyException(string message) : base(message)
        {
        }

        public InvalidCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}