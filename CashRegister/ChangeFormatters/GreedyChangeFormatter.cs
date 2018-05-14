using System.Collections.Generic;

namespace CashRegister.ChangeFormatters
{
    public class GreedyChangeFormatter : IChangeFormatter
    {
        public string FormatChangeResult(Transaction transaction)
        {
            if (transaction.ChangeDue == 0m)
                return "No change due";

            decimal remainingChange = transaction.ChangeDue;

            var result = new List<string>();

            if (remainingChange >= 1.0m)
            {
                var dollars = (int)(remainingChange / 1.0m);
                if (dollars > 1)
                    result.Add($"{dollars} dollars");
                else
                    result.Add("1 dollar");
                remainingChange -= dollars;
            }
            if (remainingChange >= 0.25m)
            {
                var quarters = (int)(remainingChange / 0.25m);
                if (quarters > 1)
                    result.Add($"{quarters} quarters");
                else
                    result.Add("1 quarter");
                remainingChange -= quarters * 0.25m;
            }
            if (remainingChange >= 0.10m)
            {
                var dimes = (int)(remainingChange / 0.10m);
                if (dimes > 1)
                    result.Add($"{dimes} dimes");
                else
                    result.Add("1 dime");
                remainingChange -= dimes * 0.10m;
            }
            if (remainingChange >= 0.05m)
            {
                var nickels = (int)(remainingChange / 0.05m);
                if (nickels > 1)
                    result.Add($"{nickels} nickels");
                else
                    result.Add("1 nickel");
                remainingChange -= nickels * 0.05m;
            }

            var pennies = (int)(remainingChange * 100);
            if (pennies > 1)
                result.Add($"{pennies} pennies");
            else if (pennies == 1)
                result.Add("1 penny");

            return string.Join(",", result);
        }
    }
}
