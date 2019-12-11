using CashRegister.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        public static void Main(string[] args)
        {
            CashRegisterApp();
        }

        


        public static void CashRegisterApp()
        {
            List<TranscationModel> trans = new List<TranscationModel>();
            string fileName = "transcations.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, @"TranscationFile\", fileName);

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int pur = Convert.ToInt32(values[0].Replace(".", ""));
                    int pay = Convert.ToInt32(values[1].Replace(".", ""));
                    trans.Add(new TranscationModel { Payment = pay, Purchase= pur });
                }
            }

            foreach (var tran in trans)
            {
                int payment = tran.Payment; //$5.00
                int purchase = tran.Purchase; //$2.68
                int change = payment - purchase;
                int changeincents = change * 100;
                bool israndom = (changeincents % 3) == 0;

                if (change == 0)
                {
                    Console.WriteLine("No Change to be dispensed");
                }

                if (change < 0)
                {
                    Console.WriteLine("Insufficient Funds");
                }

                else if (israndom == true && changeincents > 0)
                {

                    Random random = new Random();
                    decimal ranchange = change;

                    var denoms = new[] { // ordered
                    new { name = "dollar", nominal    =  100m },
                    new { name = "quarter", nominal   = 0.25m },
                    new { name = "dime", nominal      = 0.10m },
                    new { name = "nickel", nominal    = 0.05m },
                    new { name = "pennies", nominal   = 0.01m }
                    };

                    Console.WriteLine("Your random change is "  + random.Next(3) +  " dollar(s) " + random.Next(3) + " quarter(s) " + random.Next(3) + " dime(s) " + random.Next(3) + " nickle(s) " + random.Next(3) + "  and  " + random.Next(3) + " penn(ies)");

                    
                }
                else if (changeincents > 0)
                {
                    int dollars = change / 100;
                    change = change % 100;
                    int quarters = change / 25;
                    change = change % 25;
                    int dimes = change / 10;
                    change = change % 10;
                    int nickles = change / 5;
                    int pennies = change % 1;
                    Console.WriteLine("Your change is " + dollars + " dollar(s) " + quarters + " quarter(s) " + dimes + " dime(s) " + nickles + " nickle(s), and " + pennies + " pennie(s).");
                }
            }
            Console.ReadLine();
        }
    }
}
