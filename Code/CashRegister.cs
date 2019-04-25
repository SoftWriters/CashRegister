using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Cash;

namespace Cash
{
    public class CashRegister
    {
        private List<Transaction> transactions;
        private Currency currency;
        public CashRegister(string file, Currency c) //TODO: overload the constructor to parse from string arrays and strings
        {
            StreamReader filestream = new StreamReader(file);
            string line;

            transactions = new List<Transaction>();
            currency = c;
            while((line = filestream.ReadLine()) != null)
            {
                try
                {
                    transactions.Add(parse_transaction(line));
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Transaction Format");
                }
            }
            filestream.Close();
        }
        private Transaction parse_transaction(string input) //TODO: Move this into the transaction class; add delimiter selection
        {
            Transaction temp = null;
            string[] values = input.Split(',');
            try
            {
                temp = new Transaction(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), currency);
            }
            catch (Exception)
            {
                throw;
            }

            return temp;
        }
        public string change_to_text() //TODO: indicate invalid format inputs in output
        {
            string output = "";
            foreach (Transaction t in transactions)
            {
                output += t.change_to_text();
                output += "\r\n";
            }
            return output;
        }
        public void change_to_file(string file) //outputs the formatted string to the specified file
        {
            StreamWriter filestream = new StreamWriter(file);
            filestream.Write(change_to_text());
            filestream.Close();
        }
    }
}
