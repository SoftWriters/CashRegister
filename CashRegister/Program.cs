using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Since no UI was given in the description of the task, I created a simple
//program.cs to autopilot through the code. 

//All key parts were broken out as classes to fulfil the request that I 
//pretend this is part of a bigger project. 

//This could have been hashed out with some hard coded currency, and a few 
//simple functions but I did not think that would fit the spirit of the 
//task. Instead I built it out with classes and a config file. The classes
//could be seperated from program.cs and built as a dll if need be.

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            //read input files
            InputReaderClass inputReader = new InputReaderClass();
            List<TransactionClass> transactions = inputReader.ReadTranastionFile("transactions.txt");
            CurrencyReaderClass currencyReader = new CurrencyReaderClass();
            List<CurrencyClass> currencyList = currencyReader.ReadCurrencyFile("currency.txt");

            List<ChangeClass> changeList;
            if (transactions == null)
            {
                Console.WriteLine("FATAL: Transaction file not found.");
                return;
            }
            if (currencyList == null)
            {
                Console.WriteLine("FATAL: Currency file not found.");
                return;
            }
            foreach (TransactionClass trans in transactions)
            {
                try
                {
                    changeList = trans.ProcessTransaction(currencyList);
                    if (changeList != null && changeList.Count > 0)
                    {
                        String changeStr = "Your change is: ";
                        foreach (ChangeClass change in changeList)
                        {
                            changeStr = changeStr + change.getName() + ", ";
                        }

                        Console.WriteLine(changeStr.Substring(0, changeStr.Length - 2));
                    }
                    else
                    {
                        Console.WriteLine("Thank you for paying with exact change!");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }            
        }
    }
}
