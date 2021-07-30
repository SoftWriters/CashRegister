using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class CashRegisterApp
    {
        /*method that brings together input, output, and data processing functionalities
         *Note: optionally takes in an output file to print to if the user wants to specify one,
         *otherwise the default output.txt is used
         *Note: not just a static method since if future functioanlity was required, additional 
         *methods could simply be added to this class.
        */
        public void calculateChange(string input, string output = "output.txt")
        {
            OutputManager outputMan = new OutputManager(output);
            InputManager inputMan = new InputManager(input);
            TransactionProcessor processor = new TransactionProcessor();
            LinkedList<Transaction> transactions = new LinkedList<Transaction>();
            try
            {
                //get all transactions from input source
                transactions = inputMan.readFromInput();

                //Compute the change required for each transaction
                processor.determineChange(transactions);

                //print the change for all transactions to the output location
                outputMan.outputToFile(transactions);
            }
            catch (Exception e)
            {
                //Exceptions  that occur through the use of the program come to this point if raised,
                //Here, the error message is simply printed to the output file.
                outputMan.writeErrorMsg(e.Message);
            }
        }
    }
}
