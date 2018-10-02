using System;
using Cash;
using System.Collections.Generic;
using System.Linq;

namespace Cash
{
    public class USD : Currency
    {
        //TODO: account for empty lists
        //flags
        public const int NO_FLAGS = 0x00;
        public const int UNCOMMON_DENOMINATIONS = 0x01;
        public const int MORE_BILLS = 0x02;
        public const int HIGH_VALUES = 0x04;
        public const int DISCONTINUED = 0x08;

        //variables
        private List<Denomination> denominations;

        //functions
        public USD(int flags) //TODO: create functions to handle adding denominations to clarify this constructor
        {
            Denomination temp;

            denominations = new List<Denomination> { new Denomination(0.01,        "Penny",       "Pennies"),
                                                     new Denomination(0.05,       "Nickel",       "Nickels"),
                                                     new Denomination(0.10,         "Dime",         "Dimes"),
                                                     new Denomination(0.25,      "Quarter",      "Quarters"),
                                                     new Denomination(1.00,  "Dollar Bill",  "Dollar Bills") };
            if ((flags & UNCOMMON_DENOMINATIONS) != 0)
            {
                temp = new Denomination(0.50, "Half Dollar", "Half Dollars");
                denominations.Add(temp);
                temp = new Denomination(2.00, "Two Dollar Bill", "Two Dollar Bills");
                denominations.Add(temp);
            }
            if ((flags & MORE_BILLS) != 0)
            {
                temp = new Denomination(5, "Five Dollar Bill", "Five Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(10, "Ten Dollar Bill", "Ten Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(20, "Twenty Dollar Bill", "Twenty Dollar Bills");
                denominations.Add(temp);
            }
            if ((flags & HIGH_VALUES) != 0)
            {
                temp = new Denomination(50, "Fifty Dollar Bill", "Fifty Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(100, "Hundred Dollar Bill", "Hundred Dollar Bills");
                denominations.Add(temp);
            }
            if ((flags & DISCONTINUED) != 0)
            {
                temp = new Denomination(500, "Five Hundred Dollar Bill", "Five Hundred Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(1000, "Thousand Dollar Bill", "Thousand Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(5000, "Five Thousand Dollar Bill", "Five Thousand Dollar Bills");
                denominations.Add(temp);
                temp = new Denomination(10000, "Ten Thousand Dollar Bill", "Ten Thousand Dollar Bills");
                denominations.Add(temp);
            }

            denominations = (from d in denominations
                             orderby d.value descending
                             select d).ToList();
        }

        public Denomination get_closest_denomination(double input)
        {
            foreach (Denomination d in denominations)
            {
                if (d.value <= input)
                {
                    return d;
                }
            }
            return null;
        }

        public Denomination get_closest_denomination_safe(double input)
        { //TODO: write a safer version that accounts for unsorted lists
            return null;
        }

        public Denomination get_denomination( int index )
        {
            if ((index >= 0) && (index < denominations.Count))
            {
                return denominations[index];
            }
            else
            {
                return null;
            }
        }
    }
}