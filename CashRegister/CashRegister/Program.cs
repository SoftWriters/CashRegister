using System;
using System.Collections.Generic;
namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> costValue = new List<string>();
            List<string> paidValue = new List<string>();
            List<string> change = new List<string>();
            //Accepting flat file as input
            ChangeCalculations utilities = new ChangeCalculations();
            utilities.Splittingvalues(args[0], costValue, paidValue);

            //Output the change the cashier should return
            utilities.ChangeofCost(costValue, paidValue,change);

            foreach (string changeNeeded in change)
            {
                Console.WriteLine(changeNeeded);
            }


            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }

    }
} 
