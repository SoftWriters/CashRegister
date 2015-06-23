using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    class Helper
    {
        static public void ParseChange(StreamWriter sw, decimal amount,bool randomFormat)
        {
            int randomNumber = 0;
            //  Counts will be calculated in calcDenominationCount
            int quarterCount = 0;
            int dimeCount = 0;
            int nickleCount = 0;
            int pennyCount = 0;

            int dollarcount = (int) amount;
            int remainder = (int) ((amount - (decimal) dollarcount) * 100) ;


            if (randomFormat)
            {
                Random random = new Random();
                randomNumber = random.Next(0, 100);
                // Based on the random number generatet format the cants portion of the change 
                if ((randomNumber > 0) && (randomNumber <= 33))
                {
                    calcDenominationCount(remainder, 25, ref quarterCount, ref remainder);
                }
                if ((randomNumber > 33) && (randomNumber <= 66))
                {
                    calcDenominationCount(remainder, 10, ref dimeCount, ref remainder);
                }
                if ((randomNumber > 66) && (randomNumber < 100))
                {
                    calcDenominationCount(remainder, 5, ref nickleCount, ref remainder);
                }
            }
            else
            {
                calcDenominationCount(remainder, 25, ref quarterCount, ref remainder);
                calcDenominationCount(remainder, 10, ref dimeCount, ref remainder);
                calcDenominationCount(remainder, 5, ref nickleCount, ref remainder);
            }
            calcDenominationCount(remainder, 1, ref pennyCount, ref remainder);

            // Build the output string
            StringBuilder sb = new StringBuilder();
            formatchange(dollarcount, "dollar", sb);
            formatchange(quarterCount, "quarter", sb);
            formatchange(dimeCount, "dime", sb);
            formatchange(nickleCount, "nickel", sb);
            formatchange(pennyCount, "penny", sb);

            sw.WriteLine(sb.ToString());
        }

        static void calcDenominationCount(int amt, int divisor, ref int count, ref int remainder)
        {
            count = amt / divisor; // Determine the number of times the divisor fits into the amount
            remainder = amt - (divisor * count); //subtracte the value from the amount
            remainder = remainder % divisor; // set the modelo based on the divisor
        }

        static void formatchange(int denominationCount, string denomination, StringBuilder sb)
        {
            // if the count of the denomination is 0 ignore it for formatting
            if (denominationCount == 0)
            {
                return;
            }
            if (denominationCount > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                if (denomination.ToUpper() == "PENNY")
                {
                    denomination = "pennies";
                }
                else
                {
                    if (denominationCount > 1)
                    {

                    denomination = denomination + "s";
                    }
                }
            }
            sb.Append(denominationCount.ToString() + " " + denomination );
            return;
        }

        public static bool CheckAmount(decimal amt, int factor)
        {
            bool retvalue = false;
            int modelo = -1;
            // See if the dollar amount of the change change is divisible by 3
            // populate randomNumber if so
            if (amt > 0)
            {
                modelo = (int)((amt * 100) % factor);
            }
            if (modelo == 0)
            {
                retvalue = true;
            }
            return retvalue;
        }

    }
}
