using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    /*Class that represents one transaction, which stores the amount owed, 
     *paid, as well as the calculated change
    */
    class Transaction
    {
        //The amounts owed and paid in cents, respectively
        private int amountOwed;
        private int amountPaid;

        //a dictionary that stores the amount (int) of each denomination (sring) to return
        private SortedDictionary<string, int> change;

        public Transaction(int owed, int paid)
        {
            this.amountOwed = owed;
            this.amountPaid = paid;
        }

        public int getAmountOwed()
        {
            return amountOwed;
        }

        public int getAmountPaid()
        {
            return amountPaid;
        }

        public SortedDictionary<string, int> getChange()
        {
            return change;
        }

        public void setChange(SortedDictionary<string, int> ch)
        {
            this.change = ch;
        }
    }
}
