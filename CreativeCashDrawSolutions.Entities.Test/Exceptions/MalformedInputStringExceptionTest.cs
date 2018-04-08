using System;
using CreativeCashDrawSolutions.Entities.Exceptions;
using Xunit;

namespace CreativeCashDrawSolutions.Entities.Test.Exceptions
{
    public class MalformedInputStringExceptionTest
    {
        [Fact]
        public void MalformedInputStringException_default_ctor()
        {
            const string expectedMessage = "Exception of type 'CreativeCashDrawSolutions.Entities.Exceptions.MalformedInputStringException' was thrown.";

            var exception = new MalformedInputStringException();

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string()
        {
            const string expectedMessage = "message";

            var exception = new MalformedInputStringException(expectedMessage);

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string_ex()
        {
            const string expectedMessage = "message";
            var innerEx = new Exception("oops");

            var exception = new MalformedInputStringException(expectedMessage, innerEx);

            Assert.Equal(innerEx, exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
