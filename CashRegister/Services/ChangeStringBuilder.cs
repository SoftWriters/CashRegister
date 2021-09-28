using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class ChangeStringBuilder : IChangeStringBuilder
    {
        public string BuildChangeString(decimal dollars, decimal quarters, decimal dimes, decimal nickels, decimal pennies)
        {
            var dollarsLabel = dollars == 1 ? "dollar" : "dollars";
            var quartersLabel = quarters == 1 ? "quarter" : "quarters";
            var dimesLabel = dimes == 1 ? "dime" : "dimes";
            var nickelsLabel = nickels == 1 ? "nickel" : "nickels";
            var penniesLabel = pennies == 1 ? "penny" : "pennies";

            StringBuilder sb = new StringBuilder();
            List<string> strings = new List<string>(); 

            AppendString(strings, dollars, dollarsLabel);
            AppendString(strings, quarters, quartersLabel);
            AppendString(strings, dimes, dimesLabel);
            AppendString(strings, nickels, nickelsLabel);
            AppendString(strings, pennies, penniesLabel);
            
            return sb.AppendJoin(", ", strings).ToString();
        }

        private void AppendString(List<string> strings, decimal val, string label)
        {
            var numberFormat = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0
            };

            if (val != 0)
            {
                strings.Add($"{((int) val).ToString(numberFormat)} {label}");
            }

        }
    }
}