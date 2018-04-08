using CreativeCashDrawSolutions.Domain.Currencies.UnitedStatesDollar;
using Xunit;

namespace CreativeCashDrawSolutions.Domain.Test.Currencies.UnitedStatesDollar
{
    public class UnitedStatesDollarProcessorTest
    {
        [Theory]
        [InlineData("2.12,3.00", "3 quarters,1 dime,3 pennies")]
        [InlineData("1.97,2.00", "3 pennies")]
        [InlineData("3.33,5.00", "1 dollar,2 quarters,1 dime,1 nickle,2 pennies")] //BUG: Instructions state this is supposed to trigger a random which is likely incorrect 5-3.33 is not divisible by 3
        public void VerifyChangeIsCorrect(string inputString, string expectedOutput)
        {
            // This test is responsible for taking predictable input values and returning the output values
            var processor = new UnitedStatesDollarProcessor();
            var actual = processor.GetOutputString(inputString);
            Assert.Equal(expectedOutput, actual);
        }

        [Fact]
        public void VerifyRandomChangeIsCorrect()
        {
            // This test is responsible for taking the random change that is returned and verifying its correctness
            // 3.33,5.00
            var processor = new UnitedStatesDollarProcessor();
            var run1 = processor.GetOutputString("2.00,5.00");
            var run2 = processor.GetOutputString("2.00,5.00");
            Assert.NotEqual(run1, run2);
        }
    }
}
