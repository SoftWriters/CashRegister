using System;
using CreativeCashDrawSolutions.Entities.Exceptions;
using Xunit;

namespace CreativeCashDrawSolutions.Entities.Test.Exceptions
{
    public class BadDataTypeInInputStringExceptionTest
    {
        [Fact]
        public void MalformedInputStringException_default_ctor()
        {
            const string expectedMessage = "Exception of type 'CreativeCashDrawSolutions.Entities.Exceptions.BadDataTypeInInputStringException' was thrown.";

            var exception = new BadDataTypeInInputStringException();

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string()
        {
            const string expectedMessage = "message";

            var exception = new BadDataTypeInInputStringException(expectedMessage);

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string_ex()
        {
            const string expectedMessage = "message";
            var innerEx = new Exception("oops");

            var exception = new BadDataTypeInInputStringException(expectedMessage, innerEx);

            Assert.Equal(innerEx, exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
