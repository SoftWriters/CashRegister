using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    // CashDemoninations is a enum for USD currency units, ranging from pennies to Dollar Bills.
    // Order here will not matter.
    public enum CashDenominations
    {
        Pennies = 1,
        Nickels = 5,
        Dimes = 10,
        Quarters = 25,
        Dollars = 100//,
        //TenDollarBills = 1000,
        //TwentyDollarBills = 2000,
        //FiftyDollarBills = 5000,
        //OneHundredDollarBills = 10000
    };

    // CashTransaction is a simple class that stores the information for a physical cash transaction
    // (amount owed, change, etc.) It has one method for returning the change as a string.
    public class CashTransaction
    {
        public int AmountOwed { get;  private set; }
        private int AmountPaid;
        public int ChangeTotal
        {
            get
            {
                return AmountPaid - AmountOwed;
            }
        }
        // Dictionary that stores the count for each currency unit.
        private Dictionary<CashDenominations, int> ChangeDenominationCounts;

        public CashTransaction(int amountOwed, int amountPaid)
        {
            this.AmountOwed = amountOwed;
            this.AmountPaid = amountPaid;

            ChangeDenominationCounts = new Dictionary<CashDenominations, int>();
            CashDenominations[] cashDenominationsSortedFromGreatestToLeast =
                Enum.GetValues(typeof(CashDenominations))
                .Cast<CashDenominations>()
                .Reverse<CashDenominations>()
                .ToArray<CashDenominations>();
            foreach (CashDenominations denomination in cashDenominationsSortedFromGreatestToLeast)
            {
                ChangeDenominationCounts.Add(denomination, 0);
            }
        }

        public void SetChangeDenominationCount(Dictionary<CashDenominations, int> changeDenominationCounts)
        {
            this.ChangeDenominationCounts.Clear();
            this.ChangeDenominationCounts = new Dictionary<CashDenominations, int>(changeDenominationCounts);
        }

        public string GetChangeAsString()
        {
            IEnumerable<KeyValuePair<CashDenominations, int>> sortedChangeDenominationCounts = 
                ChangeDenominationCounts.OrderByDescending(x => (int) (x.Key));
            StringBuilder result = new StringBuilder();
            foreach (var count in sortedChangeDenominationCounts)
            {
                if (count.Value > 0)
                {
                    if (result.Length > 0)
                    {
                        result.Append(",");
                    }
                    result.Append(count.Value);
                    switch (count.Key)
                    {
                        case CashDenominations.Pennies:
                            result.Append(" penn");
                            if (count.Value == 1)
                            {
                                result.Append("y");
                            }
                            else
                            {
                                result.Append("ie");
                            }
                            break;
                        case CashDenominations.Nickels:
                            result.Append(" nickel");
                            break;
                        case CashDenominations.Dimes:
                            result.Append(" dime");
                            break;
                        case CashDenominations.Quarters:
                            result.Append(" quarter");
                            break;
                        case CashDenominations.Dollars:
                            result.Append(" dollar");
                            break;
                        default:
                            result.Append("Unkown denomination");
                            break;
                    }
                    if (count.Value != 1)
                    {
                        result.Append("s");
                    } 
                }
            }
            return result.ToString();
        }

    }

}

