using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CashRegister
{
    //NOTE: Normally a cash register would have other fields such as balance of each currency type and
    // this information would be pulled from a database.
    // For this example I will assume the register has unlimited of each currency to make change with.
    public class CashRegister
    {
        private IEnumerable<ICurrencyDenomination> _denominationsInRegister;

        public IEnumerable<ICurrencyDenomination> DenominationsInRegister
        {
            get { return _denominationsInRegister; }
            set
            {
                if (value != null && value.Any())
                {
                    _denominationsInRegister = value;
                }
                else
                {
                    throw new Exception("There must be at least one denomination type in the register.");
                }
            }
        }

        private IChangeCalculationStrategy _changeCalculationStrategy;
        private const string NO_CHANGE_REQUIRED_MESSAGE = "No change required.";
        private const string INSUFFICIENT_FUNDS_RECEIVED = "Insufficient funds received. {0} is still required.";
        private const string NEGATIVE_RECEIVED_AMOUNT = "A negative amount cannot be received.";

        public CashRegister()
        {
            DenominationsInRegister = GetDefaultDenominationsInRegister();

            _changeCalculationStrategy = new LargestDenominationFirstChangeCalculationStrategy();
        }

        public CashRegister(IChangeCalculationStrategy changeCalculationStrategy)
        {
            DenominationsInRegister = GetDefaultDenominationsInRegister();

            _changeCalculationStrategy = changeCalculationStrategy;
        }

        public CashRegister(IEnumerable<ICurrencyDenomination> denominationsInRegister, IChangeCalculationStrategy changeCalculationStrategy)
        {
            DenominationsInRegister = denominationsInRegister;
            _changeCalculationStrategy = changeCalculationStrategy;
        }

        public string CalculateChange(PurchaseTransaction transaction)
        {
            string output;

            if (transaction.AmountReceived < 0)
            {
                output = NEGATIVE_RECEIVED_AMOUNT;
            }
            else if (transaction.AmountReceived > transaction.AmountOwed)
            {
                IDictionary<ICurrencyDenomination, int> denominationsDue = _changeCalculationStrategy.GetChange(transaction, DenominationsInRegister);
                StringBuilder denominationAmountsStringBuilder = new StringBuilder();

                foreach (KeyValuePair<ICurrencyDenomination, int> denomination in denominationsDue)
                {
                    int numberOfTheDenomination = denomination.Value;
                    string denominationName;
                    if (denomination.Key is UsCurrencyDenomination)
                    {
                        UsCurrencyDenomination usCurrencyDenomination = (UsCurrencyDenomination) denomination.Key;
                        denominationName = numberOfTheDenomination > 1
                            ? usCurrencyDenomination.PluralizedName
                            : usCurrencyDenomination.Name;
                    }
                    else
                    {
                        denominationName = denomination.Key.Name;
                    }

                    denominationAmountsStringBuilder.Append(numberOfTheDenomination + " " + denominationName + ", ");
                }

                // Remove trailing comma
                output = denominationAmountsStringBuilder.Remove(denominationAmountsStringBuilder.Length - 2, 2).ToString();
            }
            else if (transaction.AmountReceived == transaction.AmountOwed)
            {
                output = NO_CHANGE_REQUIRED_MESSAGE;
            }
            else
            {
                decimal amountStillDue = transaction.AmountOwed - transaction.AmountReceived;
                output = String.Format(INSUFFICIENT_FUNDS_RECEIVED, amountStillDue.ToString("C", NumberFormatInfo.CurrentInfo));
            }

            return output;
        }

        // Normally, this information would be pulled from a database.
        private List<ICurrencyDenomination> GetDefaultDenominationsInRegister()
        {
            return new List<ICurrencyDenomination>
            {
                new UsCurrencyDenomination(1, "Penny", "Pennies"),
                new UsCurrencyDenomination(5, "Nickel", "Nickels"),
                new UsCurrencyDenomination(10, "Dime", "Dimes"),
                new UsCurrencyDenomination(25, "Quarter", "Quarters"),
                new UsCurrencyDenomination(50, "Half Dollar", "Half Dollars"),
                new UsCurrencyDenomination(100, "Dollar Bill", "Dollar Bills"),
                new UsCurrencyDenomination(200, "Two Dollar Bill", "Two Dollar Bills"),
                new UsCurrencyDenomination(500, "Five Dollar Bill", "Five Dollar Bills"),
                new UsCurrencyDenomination(1000, "Ten Dollar Bill", "Ten Dollar Bills"),
                new UsCurrencyDenomination(2000, "Twenty Dollar Bill", "Twenty Dollar Bills"),
                new UsCurrencyDenomination(5000, "Fifty Dollar Bill", "Fifty Dollar Bills"),
                new UsCurrencyDenomination(10000, "Hundred Dollar Bill", "Hundred Dollar Bills")
            };
        }

    }
}
