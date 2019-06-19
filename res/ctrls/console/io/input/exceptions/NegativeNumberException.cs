//NegativeNumberException class
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
        protected NegativeNumberException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}