using System.Text;

namespace CashRegisterProject.Business
{
    public class TranslatorUSD : AbsTranslator
    {
       /*       
       +3 quarters,1 dime,3 pennies
       +3 pennies
       +1 dollar,1 quarter,6 nickels,12 pennies
      */
        readonly StringBuilder _response = new StringBuilder();
        public override string TranslateAmount(decimal number)
        {
            int dollar = 0;
            int dime = 0;
            int quarter = 0;
            int nickel = 0;
            int penny = 0;

            while (number > 0)
            {
                if (number >= MoneyConstants.Dollar)
                {
                    dollar++;
                    number -= MoneyConstants.Dollar;
                    continue;
                }
                if (number >= MoneyConstants.Quarter)
                {
                    quarter++;
                    number -= MoneyConstants.Quarter;
                    continue;
                }
                if (number >= MoneyConstants.Dime)
                {
                    dime++;
                    number -= MoneyConstants.Dime;
                    continue;
                }
                if (number >= MoneyConstants.Nickel)
                {
                    nickel++;
                    number -= MoneyConstants.Nickel;
                    continue;
                }
                if (number >= MoneyConstants.Penny)
                {
                    penny++;
                    number -= MoneyConstants.Penny;
                    continue;
                }
            }
            
            if (dollar > 0)
                _response.Append(AddComma(_response.ToString()) + dollar + " "+((dollar > 1) ? "Dollars" : "Dollar"));
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
    
        
    }
    
}
