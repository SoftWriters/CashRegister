using CashRegisterProject.Model;

namespace CashRegisterProject.Business
{
    public class CashRegister
    {
        
       
        /*
             2. Output the change the cashier should return to the customer
                 +	1. The return string should look like: 1 dollar,2 quarters,1 nickel, etc ...
                 +	2. Each new line in the input file should be a new line in the output file
          */
        public decimal CalculateChange(TransactionAmounts transAmounts)
        {
            decimal difference = transAmounts.AmountPaid - transAmounts.AmountOwed;
            return difference;
        }
        



      
    }
    
}
