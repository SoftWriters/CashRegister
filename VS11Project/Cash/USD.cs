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
        public const int NO_FLAGS               = 0x00;
        public const int UNCOMMON_DENOMINATIONS = 0x01;
        public const int MORE_BILLS             = 0x02;
        public const int HIGH_VALUES            = 0x04;
        public const int DISCONTINUED           = 0x08;

        //variables
        private List<Denomination> denominations;

        //public functions
        public USD(int flags)//constructor
        {
            init_denominations(flags);

            sort_descending();
        }

        public Denomination get_closest_denomination(double input)//gets the closest denomination to the given value
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

        public Denomination get_denomination( int index )//returns the denomination at a given index. if the index is invalid, returns null
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

        public int get_count()//returns the number of denominations in the currency
        {
            return denominations.Count;
        }

        //private functions
        private void init_denominations(int flags) //fills the list of denominations based upon the flags input by the user
        {
            denominations = new List<Denomination> { new Denomination(0.01,            "Penny",           "Pennies"),
                                                     new Denomination(0.05,           "Nickel",           "Nickels"),
                                                     new Denomination(0.10,             "Dime",             "Dimes"),
                                                     new Denomination(0.25,          "Quarter",          "Quarters"),
                                                     new Denomination(1.00,  "One Dollar Bill",  "One Dollar Bills") };
            if ((flags & UNCOMMON_DENOMINATIONS) != 0)
            {
                init_uncommon_denominations();
            }
            if ((flags & MORE_BILLS) != 0)
            {
                init_more_bills();
            }
            if ((flags & HIGH_VALUES) != 0)
            {
                init_high_values();
            }
            if ((flags & DISCONTINUED) != 0)
            {
                init_discontinued();
            }
        }

        private void init_uncommon_denominations()//adds 2 dollar bills and half dollar coins to the list
        {
            Denomination temp;

            temp = new Denomination(0.50, "Half Dollar", "Half Dollars");
            denominations.Add(temp);
            temp = new Denomination(2.00, "Two Dollar Bill", "Two Dollar Bills");
            denominations.Add(temp);
        }

        private void init_more_bills()//adds 5s, 10s, and 20s
        {
            Denomination temp;

            temp = new Denomination(5, "Five Dollar Bill", "Five Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(10, "Ten Dollar Bill", "Ten Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(20, "Twenty Dollar Bill", "Twenty Dollar Bills");
            denominations.Add(temp);
        }

        private void init_high_values()//adds 50s and 100s
        {
            Denomination temp;

            temp = new Denomination(50, "Fifty Dollar Bill", "Fifty Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(100, "Hundred Dollar Bill", "Hundred Dollar Bills");
            denominations.Add(temp);
        }

        private void init_discontinued()//adds 500s, 1000s, 5000s, and 10000s
        {
            Denomination temp;

            temp = new Denomination(500, "Five Hundred Dollar Bill", "Five Hundred Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(1000, "Thousand Dollar Bill", "Thousand Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(5000, "Five Thousand Dollar Bill", "Five Thousand Dollar Bills");
            denominations.Add(temp);
            temp = new Denomination(10000, "Ten Thousand Dollar Bill", "Ten Thousand Dollar Bills");
            denominations.Add(temp);
        }

        private void sort_descending()//sorts the list in descending order by monetary value
        {
            denominations = (from d in denominations
                             orderby d.value descending
                             select d).ToList();
        }
    }
}