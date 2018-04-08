using CreativeCashDrawSolutions.Domain.Currencies.Euro;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies.Euro
{
    public class EuroProcessorTest
    {
        [Theory]
        [InlineData("2.12,3.00", "1 50 cent,1 20 cent,1 10 cent,1 5 cent,1 2 cent,1 1 cent")]
        [InlineData("1.97,2.00", "1 2 cent,1 1 cent")]
        public void VerifyChangeIsCorrect(string inputString, string expectedOutput)
        {
            // This test is responsible for taking predictable input values and returning the output values
            var processor = new EuroProcessor();
            var actual = processor.GetOutputString(inputString);
            Assert.Equal(expectedOutput, actual);
        }

        [Fact]
        public void VerifyRandomChangeIsCorrect()
        {
            // This test is responsible for taking the random change that is returned and verifying its correctness
            // 3.33,5.00
            var processor = new EuroProcessor();
            var run1 = processor.GetOutputString("3.33,5.00");
            var run2 = processor.GetOutputString("3.33,5.00");
            Assert.NotEqual(run1, run2);
        }
    }
}
