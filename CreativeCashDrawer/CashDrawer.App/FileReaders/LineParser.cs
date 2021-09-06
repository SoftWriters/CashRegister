using CashDrawer.Core.Readers;
using System;

namespace CashDrawer.App.FileReaders
{
    public class LineParser : ILineParser
    {
        public ReadResult Parse(string line)
        {
            var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length != 2)
            {
                return ReadResult.Failed("Invalid line. Expected format <due>,<paid>");
            }

            var dueResult = ParseAmount(parts[0]);
            if(dueResult.Error != null)
            {
                return ReadResult.Failed(dueResult.Error);
            }

            var paidResult = ParseAmount(parts[1]);
            if (paidResult.Error != null)
            {
                return ReadResult.Failed(paidResult.Error);
            }

            return ReadResult.Ok(dueResult.Amount, paidResult.Amount);
        }



        private (decimal Amount, string Error) ParseAmount(string s)
        {
            if (decimal.TryParse(s, out var amount) == false)
            {
                return (0, $"Invalid amount '{s}'");
            }

            if (DigitsAfterDecimal(s) != 2)
            {
                return (0, $"Invalid amount '{s}'. Amount must have 2 digits after the decimal.");
            }

            return (amount, null);
        }



        private int DigitsAfterDecimal(string paidString)
        {
            var i = paidString.IndexOf('.');
            if(i == -1)
            {
                return 0;
            }
            return paidString.Length - i - 1;
        }
    }
}
