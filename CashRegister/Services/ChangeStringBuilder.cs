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

            AppendString(sb, dollars, dollarsLabel, false);
            AppendString(sb, quarters, quartersLabel, false);
            AppendString(sb, dimes, dimesLabel, false);
            AppendString(sb, nickels, nickelsLabel, false);
            AppendString(sb, pennies, penniesLabel, true);
            
            return sb.ToString();
        }

        public void AppendString(StringBuilder sb, decimal val, string label, bool last)
        {
            var numberFormat = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0
            };

            if (val != 0)
            {
                sb.Append($"{((int) val).ToString(numberFormat)} {label}");

                if (!last)
                {
                    sb.Append(", ");
                }
            }

        }
    }
}