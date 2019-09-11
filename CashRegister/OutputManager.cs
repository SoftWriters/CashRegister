using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    /* Handles all of the output functions of the project, such as printing change 
     * information and error messages to the output location 
     */
    class OutputManager
    {
        private System.IO.StreamWriter outputFile;

        public OutputManager(string outputSource)
        {
            outputFile = new System.IO.StreamWriter(outputSource);
        }

        public void outputToFile(LinkedList<Transaction> transactions)
        {
            //currChange contains the change information for the current transaction
            SortedDictionary<string, int> currChange;

            foreach(Transaction t in transactions)
            {
                currChange = t.getChange();
                string result = "";
                foreach(string s in currChange.Keys)
                {
                    //modifies the string to to outputted so that the grammar makes sense
                    if (currChange[s] > 1)
                    {
                        if (s.EndsWith("y"))
                        {
                            string trimmed = s.Remove(s.Length - 1) + "ies";
                            result += currChange[s] + " " + trimmed + ",";
                        }
                        else
                            result += currChange[s] + " " + s + "s,";
                    } else
                    {
                        result += currChange[s] + " " + s + ",";
                    }
                }
                if (result.Length == 0)
                    result = "No change needed";
                else
                    //just to get rid of the last comma
                    result = result.Remove(result.Length - 1);
                outputFile.WriteLine(result);
            }
            outputFile.Close();
        }

        // Writes the exception message msg to the output location
        public void writeErrorMsg(string msg)
        {
            outputFile.WriteLine(msg);
            outputFile.Close();
        }
    }
}
