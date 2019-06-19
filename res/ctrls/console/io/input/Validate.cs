//Utility class dedicated to validating the input used for program operations.
using System.Configuration;
using System.Text.RegularExpressions;
using CCDS.res.ctrls.console.io.input.exceptions;

namespace CCDS.res.ctrls.console.io.input
{
    class Validate
    {
        public void CommaDelimitation(string str)
        {
            if (!str.Contains(",")) throw new NonCommaDelimitedStringException($"{Program.CarriageReturnLineFeed}{str}{Program.CarriageReturnLineFeed}^ is not a recognized as a valid comma-delimited string.");
        }
        public void Equation(string[] array)
        {
            if (array[0] == array[1]) throw new OperandEquationException();
        }
        public void Input(string str)
        {
            Substantiation(str);
            Negation(str);
            CommaDelimitation(str);
        }
        public void Negation(string str)
        {
            if (str.Contains("-")) throw new NegativeNumberException($"{Program.CarriageReturnLineFeed}{str}{Program.CarriageReturnLineFeed}^ was not a natural number.");
        }
        public void Substantiation(string str)
        {
            decimal dec;
            if (str.Trim().Length == 0) throw new EmptyStringException();
            if (!(decimal.TryParse(str, out dec))) throw new OperandFormatException($"{Program.CarriageReturnLineFeed}{str}{Program.CarriageReturnLineFeed}^ is not a valid Decimal format.");
            if (ConfigurationManager.AppSettings["CurrencyCode"].ToUpper().Equals("USD") && !(new Regex(@"^\d*[.]\d{2}?$").IsMatch(str))) throw new OperandFormatException($"{Program.CarriageReturnLineFeed}{str}{Program.CarriageReturnLineFeed}^ is not in valid USD format.");
        }
        public void Subtraction(decimal subtrahend, decimal minuend)
        {
            if (subtrahend > minuend) throw new InvalidSubtractionException(($"{Program.CarriageReturnLineFeed}{subtrahend},{minuend}{Program.CarriageReturnLineFeed}^ {subtrahend} is greater than {minuend}."));
        } 
    }
}