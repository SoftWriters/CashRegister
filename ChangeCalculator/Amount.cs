using System;
using System.Collections.Generic;
using System.IO;

namespace ChangeCalculator
{
    public class Amount
    {
        public double OwedAmount;
        public double PaidAmount;

        public int OwedAmountInPennies => (int)Math.Round(OwedAmount * 100, 0);
        public int PaidAmountInPennies => (int)Math.Round(PaidAmount * 100, 0);

        /// <summary>
        /// Parse a given line, return true if the line has exactly two values separated by comma.
        /// And only when the second value is larger than the first rounded to nearest penny.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool ParseFromLine(string line)
        {
            bool result = false;
            string[] lineElements = line.Split(',');

            if (lineElements.Length == 2)
            {
                if (double.TryParse(lineElements[0], out OwedAmount) &&
                    double.TryParse(lineElements[1], out PaidAmount) &&
                    PaidAmountInPennies > OwedAmountInPennies)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Parse a string with multiple lines, generate list of amounts.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public List<Amount> ParseFromText(string input)
        {
            List<Amount> result = new List<Amount>();

            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Amount lineValue = new Amount();

                    if (lineValue.ParseFromLine(line))
                    {
                        result.Add(lineValue);
                    }
                    else
                    {
                        // Add empty amount to get each line in the result match the lines in the input
                        result.Add(new Amount());
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// If the owed amount, in pennies, is divisable by 3 then return true.
        /// And the owed amount has to be larger than zero.
        /// </summary>
        /// <returns></returns>
        public bool DivisableByThree()
        {
            bool result = false;

            if (OwedAmountInPennies > 0 && OwedAmountInPennies % 3 == 0)
            {
                result = true;
            }

            return result;
        }
    }
}
