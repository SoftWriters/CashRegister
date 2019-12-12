using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; //so useful
using System.Text;




namespace CashRegister
{
    class Program
    {  
        //private static StreamWriter writeToTextFile = new StreamWriter("output.txt");  
        [STAThread]
         public static void Main(string[] args) 
         {
            
            // read in file (all lines)
            // store first line into an array
            // create two arrays of decimals: one for rows, one for cols
            // iterate through each line: store [0] into rows, [1] into cols
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");  

            /* THIS IS THE KEY!!! store the entire array as the actual input of the file... duh */
            string[] lines = File.ReadAllLines("input.txt");

            int i = 0;

            // iterate through "lines" - make sure it works by storing lines[0] as var and printing it
            // split the first line into its own array. 
            // store 0,1 indexes of split array into vars (these are the vars we will use in calculations)
            for(i=0; i<lines.Length; i++)
            { 
                    
                    string firstline = lines[i];
                
                    string[] splitLine = firstline.Split(',');
                    string payment = splitLine[0];
                    string price = splitLine[1];

                    decimal paymentVal = decimal.Parse(payment);
                    decimal priceVal = decimal.Parse(price);

                    //Console.WriteLine(paymentVal);
                    //Console.WriteLine(priceVal);
                    
                    decimal change = priceVal - paymentVal;
                
                    //Console.WriteLine(total);

                    // lets create a cash register "drawer"
                    //int numDollars =0, numQuarters = 0, numDimes = 0, numNickels = 0, numPennies = 0;
                    Random rnd = new Random();
                    int numDollars = rnd.Next(0, 2); 
                    int numQuarters = rnd.Next(0,41);
                    int numDimes = rnd.Next(0, 11);
                    int numNickels = rnd.Next(0,21);
                    int numPennies = rnd.Next(0,101); 


                    decimal dollars = 0, quarters = 0, dimes = 0, nickels = 0, pennies = 0;

                        while(change >= 1m)
                        {
                            dollars = Math.Truncate((change / 1m));
                            change = change % 1m;
                        }

                        while(change >= 0.25m)
                        {
                            quarters = Math.Truncate((change / 0.25m));
                            change = change % 0.25m;
                        }

                        while(change >= 0.10m)
                        {
                            dimes = Math.Truncate((change / 0.10m));
                            change = change % 0.10m;
                        }

                        while (change >= 0.05m)
                        {
                            nickels = Math.Truncate((change / 0.05m));
                            change = change % 0.05m;
                        }

                        while (change >= 0.01m)
                        {
                            pennies = Math.Truncate((change / 0.01m));
                            change = change % 0.01m;
                        }

                        

                        string output = String.Format("{0} dollars, {1} quarters, {2} dimes, {3} nickels, {4} pennies", dollars, quarters,
                        dimes, nickels, pennies);

                        Console.WriteLine(output);
                        
                        /* using (System.IO.StreamWriter fileout = new System.IO.StreamWriter(@"output.txt"))
                        {
                            System.IO.File.WriteAllText("output.txt", output);
                        }*/
                    

                    
                    
                    /* var coins = new [] { // ordered
                    new { name = "quarter", nominal   = 0.25m }, 
                    new { name = "dime", nominal      = 0.10m },
                    new { name = "nickel", nominal    = 0.05m },
                    new { name = "pennies", nominal   = 0.01m }
                    };

                    foreach (var coin in coins)
                    {
                        Random rnd = new Random();
                        int randNum  = rnd.Next(1, 50); 
                        //Console.WriteLine(randNum);

                        int count = (int) (change / coin.nominal);       
                        change -= count * coin.nominal;

                        //Console.WriteLine("{0} {1},", count, coin.name);

                        if(count == 0) {
                        // dont print the coin at all  
                        }
                        else {  
                            Console.WriteLine("{0} {1},", count, coin.name);
                            
                        }
 
                    }

                    Console.WriteLine(); // format properly*/                      
            }

        }

    }

}


    
