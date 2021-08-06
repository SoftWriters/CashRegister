using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class CashRegister
    {
        private decimal Change;

        public Change GetChange(decimal price, decimal totalPaid)
        {
            // Return Empty Change Object if inputs are less than 0
            if(price < 0 || totalPaid < 0)
            {
                return new Change();
            }
            this.Change = totalPaid - price;
            if ((price * 100) % 3 == 0)
            {
                return RandomChange();
            }
            else
            {
                return RegularChange();
            }

        }

        private Change RandomChange()
        {
            Change ChangeReturn = new Change();
            int randomNumber;
            while (Change > 0)
            {

                randomNumber = new Random().Next(1, 6);

                switch (randomNumber)
                {
                    case 1:
                        if (Change >= 1.00M)
                        {
                            ChangeReturn.AddDollar();
                            Change -= 1.00M;
                        }
                        break;
                    case 2:
                        if (Change >= 0.25M)
                        {
                            ChangeReturn.AddQuarter();
                            Change -= 0.25M;
                        }
                        break;
                    case 3:
                        if (Change >= 0.10M)
                        {
                            ChangeReturn.AddDime();
                            Change -= 0.10M;
                        }
                        break;
                    case 4:
                        if (Change >= 0.05M)
                        {
                            ChangeReturn.AddNickel();
                            Change -= 0.05M;
                        }
                        break;
                    case 5:
                        if (Change >= 0.01M)
                        {
                            ChangeReturn.AddPenny();
                            Change -= 0.01M;
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
            Change ChangeReturn = new Change();
            while (Change > 0)
            {
                if (Change >= 1.00M)
                {
                    ChangeReturn.AddDollar();
                    Change -= 1.00M;
                }
                else if (Change >= 0.25M)
                {
                    ChangeReturn.AddQuarter();
                    Change -= 0.25M;
                }
                else if (Change >= 0.10M)
                {
                    ChangeReturn.AddDime();
                    Change -= 0.10M;
                }
                else if (Change >= 0.05M)
                {
                    ChangeReturn.AddNickel();
                    Change -= 0.05M;
                }
                else if (Change >= 0.01M)
                {
                    ChangeReturn.AddPenny();
                    Change -= 0.01M;
                }
            }
            return ChangeReturn;
        } 
    }
}
