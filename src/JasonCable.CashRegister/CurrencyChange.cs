using System;
using System.Collections.Generic;
using System.Text;

namespace JasonCable.CashRegister
{
    public struct CurrencyChange
    {
        public int Hundreds { get; set; }
        public int Fifties { get; set; }
        public int Twenties { get; set; }
        public int Tens { get; set; }
        public int Fives { get; set; }
        public int Ones { get; set; }
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }

        public override string ToString()
        {
            char cents = '\u00A2';
            string returnValue = String.Empty;

            if (Hundreds > 0)
                returnValue += $"{Hundreds} x $100; ";
            if (Twenties > 0)
                returnValue += $"{Twenties} x $20; ";
            if (Tens > 0)
                returnValue += $"{Tens} x $10; ";
            if (Fives > 0)
                returnValue += $"{Fives} x $5; ";
            if (Ones > 0)
                returnValue += $"{Ones} x $1; ";
            if (Quarters > 0)
                returnValue += $"{Quarters} x 25{cents}; ";
            if (Dimes > 0)
                returnValue += $"{Dimes} x 10{cents}; ";
            if (Nickels > 0)
                returnValue += $"{Nickels} x 5{cents}; ";
            if (Pennies > 0)
                returnValue += $"{Pennies} x 1{cents}; ";

            if (returnValue.Length == 0)
                return "No change due.";

            return returnValue;
        }
    }
}
