using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class CashRegister
    {
        private decimal RunningTotal;
        public Change ChangeReturn = new Change();

        public Change GetChange(decimal amount)
        {
            this.RunningTotal = amount;
            if (RunningTotal % 3 == 0)
            {
                RandomChange();
            }
            else
            {
                RegularChange();
            }

            return ChangeReturn;
        }

        private Change RandomChange()
        {
            int randomNumber;
            while (RunningTotal > 0)
            {

                randomNumber = new Random().Next(1, 6);

                switch (randomNumber)
                {
                    case 1:
                        if (RunningTotal >= 1.00M)
                        {
                            ChangeReturn.AddDollar();
                            RunningTotal -= 1.00M;
                        }
                        break;
                    case 2:
                        if (RunningTotal >= 0.25M)
                        {
                            ChangeReturn.AddQuarter();
                            RunningTotal -= 0.25M;
                        }
                        break;
                    case 3:
                        if (RunningTotal >= 0.10M)
                        {
                            ChangeReturn.AddDime();
                            RunningTotal -= 0.10M;
                        }
                        break;
                    case 4:
                        if (RunningTotal >= 0.05M)
                        {
                            ChangeReturn.AddNickel();
                            RunningTotal -= 0.05M;
                        }
                        break;
                    case 5:
                        if (RunningTotal >= 0.01M)
                        {
                            ChangeReturn.AddPenny();
                            RunningTotal -= 0.01M;
                        }
                        break;
                    default:
                        break;
                }
            }

            return ChangeReturn;
        }

        private Change RegularChange()
        {
            while (RunningTotal > 0)
            {
                if (RunningTotal >= 1.00M)
                {
                    ChangeReturn.AddDollar();
                    RunningTotal -= 1.00M;
                }
                else if (RunningTotal >= 0.25M)
                {
                    ChangeReturn.AddQuarter();
                    RunningTotal -= 0.25M;
                }
                else if (RunningTotal >= 0.10M)
                {
                    ChangeReturn.AddDime();
                    RunningTotal -= 0.10M;
                }
                else if (RunningTotal >= 0.05M)
                {
                    ChangeReturn.AddNickel();
                    RunningTotal -= 0.05M;
                }
                else if (RunningTotal >= 0.01M)
                {
                    ChangeReturn.AddPenny();
                    RunningTotal -= 0.01M;
                }
            }
            return ChangeReturn;
        } 
    }
}
