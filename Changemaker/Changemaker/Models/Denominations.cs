using System.Collections.Generic;

namespace Changemaker.Models
{
    /// <summary>
    /// Infomation for the denominations. 
    /// </summary>
    public class Denominations
    {
        #region Accessors
        /// <summary>
        /// Monetary values for each denomination.
        /// </summary>
        public List<decimal> changeDenominationValues { get;  }

        /// <summary>
        /// denomination verbiage
        /// </summary>
        public List<string> changeItemsNames { get;  }
        /// <summary>
        /// denomination plural verbiage
        /// </summary>
        public List<string> changeItemsNamesPlural { get;  }
        /// <summary>
        /// Which denomination is being considered.
        /// </summary>
        public int  index { get; set; }
#endregion

        /// <summary>
        /// Infomation for the denominations. 
        /// </summary>
        public Denominations()
        {
            this.changeDenominationValues = new List<decimal>() { .01m, .05m, .1m, .25m, 1m}; // Monetary values
            this.changeItemsNames = new List<string>() { "penny", "nickel", "dime", "quarter", "dollar" };  // Verbiage for resulting string
            this.changeItemsNamesPlural = new List<string>() { "pennies", "nickels", "dimes", "quarters",  "dollars" }; // Verbiage for resulting string
            this.index = this.changeDenominationValues.Count - 1; // Start with the largest amount.

        }
    }
}