using System;

namespace CreativeCashDrawSolutions.Entities.Exceptions
{
    [Serializable]
    public class MalformedInputStringException : Exception
    {
        public MalformedInputStringException() { }
        public MalformedInputStringException(string message) : base(message) { }
        public MalformedInputStringException(string message, Exception inner) : base(message, inner) { }
    }
}
