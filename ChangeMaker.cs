using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CashRegister
{
    // Denominations which the CashRegister "contains" (max Twenty Dollar Bill).
    public enum Denomination
    {
        // The Description attribute contains the singular version.
        [Description("Penny")]
        Pennies = 1,
        [Description("Nickel")]
        Nickels = 5,
        [Description("Dime")]
        Dimes = 10,
        [Description("Quarter")]
        Quarters = 25,
        [Description("Dollar")]
        Dollars = 100,
        [Description("Five")]
        Fives = 500,
        [Description("Ten")]
        Tens = 1000,
        [Description("Twenty")]
        Twenties = 2000
    }

    /// <summary>
    /// Class that produces english version of change given an amount owed and 
    /// an amount paid. Also produces random denominations in change given
    /// if amount owed is divisible by 3 (cents).
    /// </summary>
    public class ChangeMaker
    {
        // Used for determining random change.
        private bool _makeChangeRandomly;

        // Amount of change not given out yet in cents.
        private int _remaining;
        
        /// <summary>
        /// Constructor for class.
        /// Initializes the class with information it needs to make change.
        /// </summary>
        /// <param name="owed">Amount owed for items bought.</param>
        /// <param name="payment">Amount given to pay for items.</param>
        public ChangeMaker(decimal owed, decimal payment)
        {
            if (owed < 0 || payment < 0 || payment < owed)
            {
                return;
            }

            _remaining = (int) ((payment - owed) * 100m);

            // Should we produce random change?
            var owedCents = (int) (owed * 100m);
            _makeChangeRandomly = owedCents%3 == 0;
        }

        /// <summary>
        /// Calculates English form of the change to be returned, 
        /// given an amount owed and an amount paid. 
        /// Also produces random denominations in change 
        /// given if amount owed is divisible by 3 (cents).
        /// </summary>
        /// <returns>English form of change to be returned.</returns>
        public string MakeChange()
        {
            var changeText = string.Empty;

            // Get an array of Denominations from largest to smallest.
            // GetValues() defaults to smallest to largest.
            var denominations = Enum.GetValues(typeof(Denomination));
            Array.Reverse(denominations);

            // Accumulate text output for all non-zero denominations.
            foreach (Denomination denomination in denominations)
            {
                // If change is random and this is the last denomination in the array,
                // turn off the _makeChangeRandomly flag so we return remaining amount.
                if (_makeChangeRandomly &&
                    denomination == (Denomination)denominations.GetValue(denominations.Length - 1))
                {
                    _makeChangeRandomly = false;
                }

                // How many of this denomination in the change given?
                var changeAmount = ChangeForDenomination(denomination);
                if (changeAmount > 0)
                {
                    if (changeText.Length > 0)
                        changeText += ",";

                    changeText += changeAmount + " " + 
                        (changeAmount > 1 ? denomination.ToString() :
                                            SingularDenominationName(denomination));
                }
            }

            return changeText;
        }

        // Return max number of Denominations passed in from the remaining 
        // amount. Then adjust remaining amount.
        // If amount owed is divisible by 3, randomly return a number 
        // equal to or less than the number normally returned.
        private int ChangeForDenomination(Denomination denomination)
        {
            // If _remaining < denomination, count = 0
            var count = _remaining / (int) denomination;

            if (_makeChangeRandomly)
            {
                // Get random number between 0 and count calculated previously.
                var random = new Random(1);        // Use seed for determinism (i.e. unit tests!).
                count = random.Next(0, count + 1); // Note second arg is exclusive
            }

            _remaining -= count * (int) denomination;

            return count;
        }

        // Gets the singular form of the denomination passed in.
        // Example: Dollars returns "Dollar"
        public string SingularDenominationName(Denomination denomination)
        {
            // Gets the info for the enum.
            var memberInfo = typeof(Denomination).GetMember(denomination.ToString());

            // Gets the attributes for the enum.
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            // Gets the "Description" attribute for the enum.
            return ((DescriptionAttribute)attrs[0]).Description;
        }
    }
}
