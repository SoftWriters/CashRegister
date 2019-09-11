using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    // Class to process the data in each transaction and determine the necessary change
    class TransactionProcessor
    {
        //dictionary that maps each denomination of US currency to its value in cents
        Dictionary<string, int> currencyValues = new Dictionary<string, int>
        {
            ["hundred"] = 10000,
            ["fifty"] = 5000,
            ["twenty"] = 2000,
            ["ten"] = 1000,
            ["five"] = 500,
            ["dollar"] = 100,
            ["quarter"] = 25,
            ["dime"] = 10,
            ["nickel"] = 5,
            ["penny"] = 1
        };

        public LinkedList<Transaction> determineChange(LinkedList<Transaction> transactions)
        {
            int changeInCents;
            foreach(Transaction t in transactions)
            {
                //denominations will hold the quantity of each denomination needed to make the optimal choice of change
                //for a given transaction. Note: sorted so that higher denominations are first (for ease of printing format)
                SortedDictionary<string, int> denominations = 
                    new SortedDictionary<string, int>(Comparer<string>.Create((a,b) => -currencyValues[a].CompareTo(currencyValues[b])));

                changeInCents = t.getAmountPaid() - t.getAmountOwed();

                if (changeInCents < 0)
                    throw new Exception("An amount paid is less than amount owed");

                if (t.getAmountOwed() % 3 == 0)
                    //determines the change randomly only if amount owed is divisible by 3
                    randomChange(denominations, changeInCents);
                else
                    normalChange(denominations, changeInCents);
                     
                t.setChange(denominations);
            }
            return transactions;
        }  

        private void normalChange(SortedDictionary<string, int> denominations, int changeInCents)
        {
            foreach (string curr in currencyValues.Keys)
            {
                if ((changeInCents / currencyValues[curr]) > 0)
                    denominations[curr] = changeInCents / currencyValues[curr];
                changeInCents %= currencyValues[curr];
            }
        }

        private void randomChange(SortedDictionary<string, int> denominations, int changeInCents)
        {
            //keeps track of which denominations could actually be used as change for the current value of the change needed
            List<string> possibleDenominations = new List<string>(currencyValues.Keys);

            Random r = new Random();

            while (changeInCents != 0)
            {
                possibleDenominations.RemoveAll(i => currencyValues[i] > changeInCents);
                string chosenDenom = possibleDenominations[r.Next(possibleDenominations.Count)];
                int multiplicityOfChosenDenom = r.Next(1, changeInCents / currencyValues[chosenDenom]);
                changeInCents -= (currencyValues[chosenDenom] * multiplicityOfChosenDenom);
                denominations.TryGetValue(chosenDenom, out int existing);
                denominations[chosenDenom] = existing + multiplicityOfChosenDenom;
            }
        }
    }
}
