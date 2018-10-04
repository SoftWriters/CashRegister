using System;
using System.Collections.Generic;
using System.Linq;
using Cash;

namespace Cash
{
    public class Transaction //TODO: clean up functions to clarify class, change from doubles to avoid errors
    {
        //variables
        public bool          failure;
        public bool          exact;
        private Currency     currency;
        private List<Change> change;
        private double       bill, payment, difference;
        private Random       generate;

        //public functions
        public Transaction(double bill, double payment, Currency currency)//constructor
        {
            this.bill       = bill;
            this.payment    = payment;
            this.difference = payment - bill;

            generate = new Random();

            change = new List<Change>();
            this.currency = currency;

            failure = false;
            exact   = false;

            try
            {
                calculate_change();
            }
            catch (ArgumentException)
            {
                failure = true;
            }
        }

        public List<Change> get_change()//returns the list of and count of current denomniations in the change
        {
            return change;
        }

        public string change_to_text()//returns a formatted string TODO:implement the use of expression matching for output
        {
            string output = "";
            if (failure)
            {
                output += "Cannot complete transaction";
            }
            else if (exact)
            {
                output += "Exact change";
            }
            else
            {
                foreach (Change c in change)
                {
                    output += c.count + " ";
                    if (c.count > 1)
                    {
                        output += c.plural;
                    }
                    else
                    {
                        output += c.name;
                    }
                    output += ", ";
                }
                output = output.Substring(0, output.Length - 2);
            }
            return output;
        }

        //private functions
        private void calculate_change()
        {
            if (difference < 0)
            {
                throw new System.ArgumentException("Payment too low.", "original");
            }
            else if( (int)(100 * difference) == 0 )
            {
                exact = true;
            }
            else if ((((int)(100 * bill)) % 3) == 0)
            {
                try
                {
                    make_random_change(difference);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                make_change(difference);
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }
        }

        private void make_change(double value)
        {
            Denomination tempd = null;
            Change       tempc = null;

            while (value >= 0)
            {
                tempd = currency.get_closest_denomination(value);
                if (tempd != null)
                {
                    tempc = new Change(tempd.value, tempd.name, tempd.plural);

                    while ((value - tempd.value) >= 0.0 )
                    {
                        tempc.count++;
                        value -= tempd.value;
                    }
                    change.Add(tempc);
                }
                else if ((value != 0) && (tempd != null))
                {
                    throw new System.ArgumentException("Change cannot be made with this currency for this transaction", "original");
                }
                else
                {
                    break;
                }
            }
            find_extra_penny(value);
        }

        private void make_random_change(double value) //makes random change by pseudo randomly selecting denominations that add up to the value
        {
            Denomination tempd;
            int max = currency.get_count()-1;
            int min = 0;
            int index;
            bool found;

            while ((value < currency.get_denomination(min).value)&&(min<max))
            {
                min++;
            }

            while ((value >= currency.get_denomination(max).value)&&((value-currency.get_denomination(max).value)>=0))
            {
                found = false;
                index = generate.Next(min, max);
                tempd = currency.get_denomination(index);
                if ((value - tempd.value) >= 0)
                {
                    foreach (Change c in change)
                    {
                        if (c.value == tempd.value)
                        {
                            found = true;
                            c.count++;
                            break;
                        }
                    }
                    if (!found)
                    {
                        change.Add(new Change(tempd.value, tempd.name, tempd.plural, 1));
                    }
                    value -= tempd.value;

                    while ((value < currency.get_denomination(min).value)&&(min<max))
                    {
                        min++;
                    }
                }
            }
            find_extra_penny(value);

            change = (from c in change
                      orderby c.value descending
                      select c).ToList();
        }

        private void find_extra_penny(double value) //function to deal with double precision errors
        {
            int  max   = currency.get_count() - 1;
            bool found = false;
            if ((value > 0) && (value < currency.get_denomination(max).value) && (value > 0.009))
            {
                foreach(Change c in change)
                {
                    if (c.value == currency.get_denomination(max).value)
                    {
                        c.count++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    change.Add(new Change(currency.get_denomination(max).value, currency.get_denomination(max).name, currency.get_denomination(max).plural, 1));
                }
            }
            
        }
    }
}
