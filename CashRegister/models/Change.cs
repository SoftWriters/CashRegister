using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class Change
    {
        //private decimal Dollar { get; } = 1.00M;
        //private decimal Quarter { get; } = 0.25M;
        //private decimal Dime { get; } = 0.10M;
        //private decimal Nickel { get; } = 0.05M;
        //private decimal Penny { get; } = 0.01M;

        public int Dollar { get; private set; } 

        public int Quarter { get; private set; } 
        public int Dime { get; private set; } 
        public int Nickel { get; private set; }
        public int Penny { get; private set; } 

        public Change()
        {
            Dollar = 0;
            Quarter = 0;
            Dime = 0;
            Nickel = 0;
            Penny = 0;
        }

        public void AddDollar()
        {
            Dollar++;
        }

        public void AddQuarter()
        {
            Quarter++;
        }

        public void AddDime()
        {
            Dime++;
        }

        public void AddNickel()
        {
            Nickel++;
        }

        public void AddPenny()
        {
            Penny++;
        }



    }
}
