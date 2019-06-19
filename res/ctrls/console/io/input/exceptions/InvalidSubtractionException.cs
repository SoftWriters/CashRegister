//InvalidSubtractionException class
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class InvalidSubtractionException : Exception
    {
        public InvalidSubtractionException(string message) : base(message) { }
        protected InvalidSubtractionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}