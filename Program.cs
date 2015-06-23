using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        /*
         * Creative Cash Draw Solutions is a client who wants to provide something different for the cashiers who use their system. 
         * The function of the application is to tell the cashier how much change is owed, and what denominations should be used.
         * In most cases the app should return the minimum amount of physical change, but the client would like to add a twist. 
         * If the "owed" amount is divisible by 3, the app should randomly generate the change denominations (but the math still needs to be right :))
         * Input and output files will be located in located in /bin/debug
        */
        static void Main(string[] args)
        {
            // Create The Output File
            StreamWriter asdf = new StreamWriter(@"results.txt");

            try
            {
                // Load the input file
                var reader = new StreamReader(File.OpenRead(@"input.csv"));

                // Process the input file into two string arrays
                List<string> listAmtOwed = new List<string>();
                List<string> listAmtPaid = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listAmtOwed.Add(values[0]);
                    listAmtPaid.Add(values[1]);
                }
                reader.Close(); // Close Input file
                ProcessLines(asdf, listAmtOwed, listAmtPaid); // Process the two string arrays
            }
            catch(Exception ex)
            {
                asdf.WriteLine(ex.Message);
            }
            asdf.Close(); // Close the output file
        }

    static private void ProcessLines(StreamWriter sw, List<string> AmtOwed, List<string> AmtPaid)
    {
        StringBuilder sb = new StringBuilder();
        // Open The Output File
         for(int i = 0; i < AmtOwed.Count; i++)
        {
            // Validate the amount owed and paid
            decimal amountowed = 0;
            decimal amountpaid = 0;
            decimal amountchange = 0;

            decimal.TryParse(AmtOwed[i], out amountowed);
            decimal.TryParse(AmtPaid[i], out amountpaid);

            // Validate Transaction
            // If this were an interactive system error conditions fail and return

            if (amountowed <= 0)
            {
                sw.WriteLine("The amount owed must be greater than 0");
                continue;
            }
            if (amountowed > amountpaid)
            {
                sw.WriteLine("The amount paid cannot be less than the amount owed. Sorry No credit.");
                continue;
            }

            if (amountowed == amountpaid)
            {
                sw.WriteLine("Thank you for paying with exact change.");
                continue;
            }

            amountchange = amountpaid - amountowed;
            int dollars = (int)(amountchange);
            amountchange = amountchange - (decimal)dollars;
            int cents = (int)(amountchange * (decimal)100);
            sb = new StringBuilder();
            Helper.CalculateChange(sw, dollars, cents); // Calculate and output the formatted change
            sw.WriteLine();
        }
    }
     
    }
}
