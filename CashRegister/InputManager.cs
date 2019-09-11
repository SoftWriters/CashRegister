using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace CashRegister
{
    class InputManager
    {
        private string input;

        public InputManager(string inputSource)
        {
            input = inputSource;
        }
        public LinkedList<Transaction> readFromInput()
        {
            //stores all of the transactions we get from reading the input file
            LinkedList<Transaction> transactions = new LinkedList<Transaction>();

            string line;

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@input);

                /*pattern that allows for whitespace on either side of each number (owed and paid) that has
                 *at least one digit before the decimal and exactly two after the decimal. owed and paid
                 *amounts must be separated by a comma
                 */
                Regex pattern = new Regex(@"([ \t]*[\d]+\.\d{2}[ \t]*),([ \t]*[\d]+\.\d{2}[ \t]*)");

                //tries to match each line of the input file with the pattern above
                while ((line = file.ReadLine()) != null)
                {
                    var match = pattern.Match(line);
                    if (match.Success)
                    {
                        int owed = (int) Math.Round(float.Parse(match.Groups[1].Value) * 100);
                        int paid = (int) Math.Round(float.Parse(match.Groups[2].Value) * 100);
                        transactions.AddLast(new Transaction(owed, paid));
                    } else
                    {
                        throw new Exception("Incorrectly formatted line encountered in input source.");
                    }
                }

                file.Close();
            }
            catch (System.IO.IOException e)
            {
                //If an exception related to the opening/accessing of the input file is thrown,
                //throw a new Exception with a descriptive message
                throw new Exception("Error accessing the input source.");
            }
            catch (Exception e)
            {
                //If an exception related to the reading of the input file or some other exception 
                //is thrown, let the exception be handled in whatever called this function.
                throw;
            }
            return transactions;
        }
    }
}
