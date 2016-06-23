using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace CashRegister
{
    //Here we will generate the "Input" for the program. 
    //In the spirit of realistic testing we will generate a random amount of random values
    //with random, realistic payment amounts. (values accomplishable by bills) 
    class Input
    {
        public string GetValues()
        {
            //This really should be private but I wanted to expose the input file for easy verification.

            //output should be n.nn, n.00
            string output = string.Empty;

            Random random = new Random();
            int amountOfValues = random.Next(0, 25); //Capping at 25 for readability.

            string purchase = string.Empty;
            double price = 0;
            int minPurchase = 0;

            for (int ii = 0; ii < amountOfValues; ii++)
            {
                purchase = string.Empty; //not actually needed.

                //here we build a purchase. This could be another class but for this scope 
                //it feels unecisarily complex.
                price = random.Next(0, 25) + random.NextDouble();
                minPurchase = Convert.ToInt32(price) + 1;

                string.Format("{0:0.00}", price);
                string.Format("{0:0.00}", random.Next((int)price + 1, 30));
                
                purchase = string.Format("{0:0.00}", price) + "," + string.Format("{0:0.00}", random.Next(minPurchase, 30)) + Environment.NewLine;
                output += purchase;
                
            }

            return output;
        }


    }
    
}
