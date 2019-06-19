//NonCommaDelimitedStringException class
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class NonCommaDelimitedStringException : Exception
    {
        public NonCommaDelimitedStringException(string message) : base(message) { }
        protected NonCommaDelimitedStringException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}