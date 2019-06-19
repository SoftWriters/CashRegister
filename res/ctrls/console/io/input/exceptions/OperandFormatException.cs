//OperandFormatException class
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class OperandFormatException : Exception
    {
        public OperandFormatException(string message) : base(message) { }
        protected OperandFormatException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}