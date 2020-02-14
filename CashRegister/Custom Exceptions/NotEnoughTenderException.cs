using System;
using System.Runtime.Serialization;

namespace CashRegisterConsumer
{
    /// <summary>
    /// Custom exception for clarity of code and exception handling
    /// </summary>
    [Serializable]
    public class NotEnoughTenderException : Exception
    {
        public NotEnoughTenderException()
        {
        }

        public NotEnoughTenderException(string message) : base(message)
        {
        }

        public NotEnoughTenderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEnoughTenderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}