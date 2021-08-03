using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class CashRegister
    {
        private decimal Dollar { get; } = 1.00M;
        private decimal Quarter { get; } = 0.25M;
        private decimal Dime { get; } = 0.10M;
        private decimal Nickel { get; } = 0.05M;
        private decimal Penny { get; } = 0.01M;

        private int[] Change = { 0, 0, 0, 0, 0};

        public int[] GetChange(decimal amount)
        {
            //if(amount % 3 == 0)
            //{
                //Return Random Change
            //} else
            //{
                while(amount > 0)
                {
                    if(amount >= 1.00M)
                    {
                        Change[0]++;
                        amount -= 1.00M;
                    } else if(amount >= 0.25M)
                    {
                        Change[1]++;
                        amount -= 0.25M;
                    } else if(amount >= 0.10M)
                    {
                        Change[2]++;
                        amount -= 0.10M;
                    } else if(amount >= 0.05M)
                    {
                        Change[3]++;
                        amount -= 0.05M;
                    } else if(amount >= 0.01M)
                    {
                        Change[4]++;
                        amount -= 0.01M;
                    }
                }
                // Return Regular Change
            //}
            
            return Change;
        }
    }
}
