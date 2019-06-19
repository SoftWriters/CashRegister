//MissingOperandException class
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class MissingOperandException : Exception
    {
        public MissingOperandException(string message) : base(message) { }
        protected MissingOperandException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}