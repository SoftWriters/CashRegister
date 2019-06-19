//Parser utility class to sanitize input for program operations.
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CCDS.res.ctrls.console.io.input
{
    internal class Parser
    {
        public string[] ParseOperands(string[] strArray) => strArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        public decimal ParseDecimal(string str) => Convert.ToDecimal(str);
        public string[] ParseDecimalIntoBillsAndCoins(decimal dec) => dec.ToString(CultureInfo.CurrentCulture).Split('.');
        public long ParseLong(string str) => Convert.ToInt64(str);
        public long ParseLong(decimal dec) => Convert.ToInt64(dec);
        public string RemoveAllWhitespaceFromString(string input) => Regex.Replace(input, @"\s", String.Empty);
    }
}