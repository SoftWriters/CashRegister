//OperandEquationException
using System;
namespace CCDS.res.ctrls.console.io.input.exceptions
{
    [Serializable()]
    public class OperandEquationException : Exception
    {
        public OperandEquationException() : base() { }
        protected OperandEquationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}