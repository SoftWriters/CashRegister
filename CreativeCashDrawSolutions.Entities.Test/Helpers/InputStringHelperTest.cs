using CreativeCashDrawSolutions.Entities.Exceptions;
using CreativeCashDrawSolutions.Entities.Helpers;
using Xunit;

namespace CreativeCashDrawSolutions.Entities.Test.Helpers
{
    public class InputStringHelperTest
    {
        [Fact]
        public void InputStringToInts_ConvertsCorrectly()
        {
            const int expected1 = 100, expected2 = 412;
            int actual1, actual2;
            const string inputString = "4.12,1.00";
            InputStringHelper.InputStringToInts(inputString, out actual1, out actual2);
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Theory]
        [InlineData("2.12,3.00", false)]
        [InlineData("1.97,2.00", false)]
        [InlineData("3.33,5.00", true)]
        [InlineData("3.00,5.00", true)]
        public void ShouldBeRandom(string input, bool expectedResult)
        {
            var actual = InputStringHelper.ShouldBeRandom(input);
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void InputStringToInts_ThrowsExceptionWhenTooFewElements()
        {
            int actual1, actual2;
            const string inputString = "4.12";
            var exception = Record.Exception(() => InputStringHelper.InputStringToInts(inputString, out actual1, out actual2));
            Assert.IsType(typeof(MalformedInputStringException), exception);
            Assert.Equal("Missing elements in the input string", exception.Message);
        }

        [Fact]
        public void InputStringToInts_ThrowsExceptionWhenTooManyElements()
        {
            int actual1, actual2;
            const string inputString = "4.12,5.00,6.12";
            var exception = Record.Exception(() => InputStringHelper.InputStringToInts(inputString, out actual1, out actual2));
            Assert.IsType(typeof(MalformedInputStringException), exception);
            Assert.Equal("Too many elements in the input string", exception.Message);
        }

        [Fact]
        public void InputStringToInts_ThrowsExceptionWhenFirstElementIsNotDecimal()
        {
            int actual1, actual2;
            const string inputString = "boom,1.00";
            var exception = Record.Exception(() => InputStringHelper.InputStringToInts(inputString, out actual1, out actual2));
            Assert.IsType(typeof(BadDataTypeInInputStringException), exception);
            Assert.Equal("boom is not a valid decimal for paid", exception.Message);
        }

        [Fact]
        public void InputStringToInts_ThrowsExceptionWhenSecondElementIsNotDecimal()
        {
            int actual1, actual2;
            const string inputString = "4.12,boom";
            var exception = Record.Exception(() => InputStringHelper.InputStringToInts(inputString, out actual1, out actual2));
            Assert.IsType(typeof(BadDataTypeInInputStringException), exception);
            Assert.Equal("boom is not a valid decimal for due", exception.Message);
        }
    }
}
