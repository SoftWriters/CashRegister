using CashDrawer.App.FileReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.App.Tests.FileReaderTests
{

    [TestClass]
    public class LineParserTests
    {

        [TestMethod]
        public void parser_can_parse_line_with_good_due_and_paid_values()
        {
            var line = "10.00,12.00";

            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsFalse(result.HasError);
            Assert.AreEqual(10.00m, result.Due);
            Assert.AreEqual(12.00m, result.Paid);
        }



        [TestMethod]
        public void parser_ignores_white_space()
        {
            var line = "  10.00   ,   12.00  ";

            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsFalse(result.HasError);
            Assert.AreEqual(10.00m, result.Due);
            Assert.AreEqual(12.00m, result.Paid);
        }



        [TestMethod]
        [DataRow("1.00")]
        [DataRow("1.00,")]
        [DataRow("1.00, 2.00, 3.00")]
        [DataRow("")]
        [DataRow(",")]
        public void parser_returns_error_if_not_two_amounts_on_line(string line)
        {
            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual("Invalid line. Expected format <due>,<paid>", result.Error);
        }



        [TestMethod]
        public void parser_returns_error_if_invalid_due_amount()
        {
            var line = "X.XX, 1.00";

            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual("Invalid amount 'X.XX'", result.Error);
        }



        [TestMethod]
        public void parser_returns_error_if_invalid_paid_amount()
        {
            var line = "1.00, X.XX";

            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual("Invalid amount 'X.XX'", result.Error);
        }



        [TestMethod]
        [DataRow("1   , 0.00", "Invalid amount '1'. Amount must have 2 digits after the decimal.")]
        [DataRow("1.  , 0.00", "Invalid amount '1.'. Amount must have 2 digits after the decimal.")]
        [DataRow("1.1 , 0.00", "Invalid amount '1.1'. Amount must have 2 digits after the decimal.")]
        public void parser_returns_error_if_due_amount_does_not_have_exactly_two_digits_after_decimal(string line, string expectedError)
        {
            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual(expectedError, result.Error);
        }



        [TestMethod]
        [DataRow("0.00, 1   ", "Invalid amount '1'. Amount must have 2 digits after the decimal.")]
        [DataRow("0.00, 1.  ", "Invalid amount '1.'. Amount must have 2 digits after the decimal.")]
        [DataRow("0.00, 1.1 ", "Invalid amount '1.1'. Amount must have 2 digits after the decimal.")]
        public void parser_returns_error_if_paid_amount_does_not_have_exactly_two_digits_after_decimal(string line, string expectedError)
        {
            var parser = new LineParser();
            var result = parser.Parse(line);

            Assert.IsTrue(result.HasError);
            Assert.AreEqual(expectedError, result.Error);
        }

    }

}
