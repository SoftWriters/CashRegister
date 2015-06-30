using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegisterProject.Business;

namespace CashRegisterProject
{

    public class TranslatorUSDRandom : AbsTranslator 
    {

        /*       
   +3 quarters,1 dime,3 pennies
   +3 pennies
   +1 dollar,1 quarter,6 nickels,12 pennies
  */
        readonly StringBuilder _response = new StringBuilder();
        decimal[] money = new decimal[5] { MoneyConstants.Dollar, MoneyConstants.Quarter, MoneyConstants.Dime, MoneyConstants.Nickel, MoneyConstants.Penny };

        
        public override string TranslateAmount(decimal number)
        {
            decimal denomination;
            int dollar = 0;
            int dime = 0;
            int quarter = 0;
            int nickel = 0;
            int penny = 0;
            Random rnd = new Random();
            
            while (number > 0)
            {
                denomination = ChooseDenomitaion(number, rnd);
                number -= denomination;
                if (denomination == MoneyConstants.Dollar)
                    dollar++;
                else if (denomination == MoneyConstants.Quarter)
                    quarter++;
                else if (denomination == MoneyConstants.Dime)
                    dime++;
                else if (denomination == MoneyConstants.Nickel)
                    nickel++;
                else penny++;
                               
            }
            

            if (dollar > 0)
                _response.Append(AddComma(_response.ToString()) + dollar + " " + ((dollar > 1) ? "Dollars" : "Dollar"));
            if (quarter > 0)
                _response.Append(AddComma(_response.ToString()) + quarter + " " + ((quarter > 1) ? "Quarters" : "Quarter"));
            if (dime > 0)
                _response.Append(AddComma(_response.ToString()) + dime + " " + ((dime > 1) ? "Dimes" : "Dime"));
            if (nickel > 0)
                _response.Append(AddComma(_response.ToString()) + nickel + " " + ((nickel > 1) ? "Nickels" : "Nickel"));
            if (penny > 0)
                _response.Append(AddComma(_response.ToString()) + penny + " " + ((penny > 1) ? "Pennies" : "Penny"));
             
            
            return _response.ToString();
        }

       

        private decimal ChooseDenomitaion(decimal number, Random rnd)
        {
         
            decimal denomition=0;

            if (number < MoneyConstants.Nickel)
            {
                denomition = MoneyConstants.Penny;
            }
            else if (number < MoneyConstants.Dime)
            {
                denomition = money[rnd.Next(3, 5)];
            }
            else if (number < MoneyConstants.Quarter)
            {
                denomition = money[rnd.Next(2, 5)];
            }
            else if (number < MoneyConstants.Dollar)
            {
                denomition = money[rnd.Next(1, 5)];
            }
            else
            {
                denomition = money[rnd.Next(0, 5)];
            }
            return denomition;

        }
    }
}
