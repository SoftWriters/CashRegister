using System;
using CreativeCashDrawSolutions.Entities.Exceptions;
using Xunit;

namespace CreativeCashDrawSolutions.Entities.Test.Exceptions
{
    public class NoPossibleSolutionExceptionTest
    {
        [Fact]
        public void NoPossibleSolutionException_Default_Constructor()
        {
            const string expectedMessage = "Exception of type 'CreativeCashDrawSolutions.Entities.Exceptions.NoPossibleSolutionException' was thrown.";

            var exception = new NoPossibleSolutionException();

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string()
        {
            const string expectedMessage = "message";

            var exception = new NoPossibleSolutionException(expectedMessage);

            Assert.Null(exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AuthorizationRequiredException_ctor_string_ex()
        {
            const string expectedMessage = "message";
            var innerEx = new Exception("oops");

            var exception = new NoPossibleSolutionException(expectedMessage, innerEx);

            Assert.Equal(innerEx, exception.InnerException);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
