// EmptyStringException class
// A constructor is needed for serialization when an exception propagates from a remoting server to the client.
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class EmptyStringException : Exception
    {
        public EmptyStringException() : base() { }
        protected EmptyStringException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}