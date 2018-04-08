using System;
using CreativeCashDrawSolutions.Entities.Exceptions;

namespace CreativeCashDrawSolutions.Entities.Helpers
{
    public static class InputStringHelper
    {
        public static void InputStringToInts(string input, out int due, out int paid)
        {
            decimal amountDue, amountPaid;
            InputStringToDecimals(input, out amountDue, out amountPaid);

            // Convert the decimals to intergers
            due = CovertDecimalAmountToInt(amountDue);
            paid = CovertDecimalAmountToInt(amountPaid);
        }

        public static bool ShouldBeRandom(string input)
        {
            decimal amountDue, amountPaid;
            InputStringToDecimals(input, out amountPaid, out amountDue);
            return CovertDecimalAmountToInt(amountDue) % 3 == 0;
        }

        private static void InputStringToDecimals(string input, out decimal due, out decimal paid)
        {
            var inputTokens = input.Trim().Split(",".ToCharArray());
            if (inputTokens.Length < 2) throw new MalformedInputStringException("Missing elements in the input string");
            if (inputTokens.Length > 2) throw new MalformedInputStringException("Too many elements in the input string");
            if (!decimal.TryParse(inputTokens[0].Trim(), out paid)) throw new BadDataTypeInInputStringException(string.Format("{0} is not a valid decimal for paid", inputTokens[0].Trim()));
            if (!decimal.TryParse(inputTokens[1].Trim(), out due)) throw new BadDataTypeInInputStringException(string.Format("{0} is not a valid decimal for due", inputTokens[1].Trim()));
        }

        private static int CovertDecimalAmountToInt(decimal amount)
        {
            return Convert.ToInt32(Math.Round(amount, 2) * 100);
        }
    }
}
