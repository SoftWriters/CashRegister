using System;
using System.Text;

namespace CashRegisterLib
{
    sealed public class Cashier
    {
        int hundreds = 0;
        int fifties = 0;
        int twenties = 0;
        int tens = 0;
        int fives = 0;
        int dollars = 0;
        int quarters = 0;
        int dimes = 0;
        int nickels = 0;
        int pennies = 0;

        static Random random = new Random();

        public string GetChange(decimal total, decimal paid)
        {
            // round to the penny
            total = Math.Round(total, 2);
            paid = Math.Round(paid, 2);

            // validate
            if (total < 0)
                throw new Exception("Total amount should be a positive amount.");

            if (paid < 0)
                throw new Exception("Paid amount should be a positive amount.");

            if (paid < total)
                throw new Exception("Please pay more. Paid amount is less than the total amount.");

            if (paid - total > Int32.MaxValue / 100m)
                throw new Exception($"Change amount is too large to be calculated. Must be less than or equal to {Int32.MaxValue / 100m}.");

            // clear and calculate
            Reset();

            var change = paid - total;
            if ((total % 0.03m) != 0)
            {
                // the minimum amount of physical change
                CalcChange(change);
            }
            else
            {
                // if the total due in cents is divisible by 3, the app should randomly generate the change denominations
                var cnt = 0;
                while (change > 0 && cnt < 3)
                {
                    var subChange = random.Next(Convert.ToInt32(change * 100)) / 100.0m;
                    CalcChange(subChange);
                    change -= subChange;
                    cnt++;
                }
                CalcChange(change);
            }
            return GetDisplayString();
        }

        private void Reset()
        {
            hundreds = 0;
            fifties = 0;
            twenties = 0;
            tens = 0;
            fives = 0;
            dollars = 0;
            quarters = 0;
            dimes = 0;
            nickels = 0;
            pennies = 0;
        }

        private void CalcChange(decimal change)
        {
            var c = Math.Floor(change / 100);
            if (c > 0)
            {
                hundreds += (int)c;
                change -= c * 100;
            }

            c = Math.Floor(change / 50);
            if (c > 0)
            {
                fifties = (int)c;
                change -= c * 50;
            }

            c = Math.Floor(change / 20);
            if (c > 0)
            {
                twenties += (int)c;
                change -= c * 20;
            }

            c = Math.Floor(change / 10);
            if (c > 0)
            {
                tens += (int)c;
                change -= c * 10;
            }

            c = Math.Floor(change / 5);
            if (c > 0)
            {
                fives += (int)c;
                change -= c * 5;
            }

            c = Math.Floor(change / 1);
            if (c > 0)
            {
                dollars += (int)c;
                change -= c;
            }

            c = Math.Floor(change / 0.25m);
            if (c > 0)
            {
                quarters += (int)c;
                change -= c * 0.25m;
            }

            c = Math.Floor(change / 0.10m);
            if (c > 0)
            {
                dimes += (int)c;
                change -= c * 0.10m;
            }

            c = Math.Floor(change / 0.05m);
            if (c > 0)
            {
                nickels += (int)c;
                change -= c * 0.05m;
            }

            c = change / 0.01m;
            if (c > 0)
            {
                pennies += (int)c;
            }
        }

        private string GetDisplayString()
        {
            var changeStr = new StringBuilder();
            if (hundreds > 0)
            {
                changeStr.Append(hundreds == 1 ? $"{hundreds} hundred" : $"{hundreds} hundreds");
            }
            if (fifties > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(fifties == 1 ? $"{fifties} fifty" : $"{fifties} fifties");
            }
            if (twenties > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(twenties == 1 ? $"{twenties} twenty" : $"{twenties} twenties");
            }
            if (tens > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(tens == 1 ? $"{tens} ten" : $"{tens} tens");
            }
            if (fives > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(fives == 1 ? $"{fives} five" : $"{fives} fives");
            }
            if (dollars > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(dollars == 1 ? $"{dollars} dollar" : $"{dollars} dollars");
            }
            if (quarters > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(quarters == 1 ? $"{quarters} quarter" : $"{quarters} quarters");
            }
            if (dimes > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(dimes == 1 ? $"{dimes} dime" : $"{dimes} dimes");
            }
            if (nickels > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(nickels == 1 ? $"{nickels} nickel" : $"{nickels} nickels");
            }
            if (pennies > 0)
            {
                if (changeStr.Length > 0) changeStr.Append(",");
                changeStr.Append(pennies == 1 ? $"{pennies} penny" : $"{pennies} pennies");
            }

            if (changeStr.Length > 0)
                return changeStr.ToString();

            return "Exact change. Nothing to be returned.";
        }
    }
}
