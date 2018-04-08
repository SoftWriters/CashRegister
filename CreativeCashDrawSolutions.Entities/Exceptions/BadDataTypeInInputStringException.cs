using System;

namespace CreativeCashDrawSolutions.Entities.Exceptions
{
    [Serializable]
    public class BadDataTypeInInputStringException : Exception
    {
        public BadDataTypeInInputStringException() { }
        public BadDataTypeInInputStringException(string message) : base(message) { }
        public BadDataTypeInInputStringException(string message, Exception inner) : base(message, inner) { }
    }
}
