using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public static class Program
    {
        public static string myConsoleText;
        public static string InputFile;
        public static StreamReader InputFileReader;
        public static List<InputLine> InputLines = new List<InputLine>();
        public static List<String> OutputLines = new List<string>();
        public static string OutputFile;
        private static Random _random = new Random();


        static void Main(string[] args)
        {
            try
            {
                if (HasValidArgs(args) && IsValidFile())
                {
                    OutputChange();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static bool HasValidArgs(string[] args)
        {
            if (args == null)
            {
                myConsoleText = "Please provide an input and output file. Ex: CashRegister input.txt output.txt";
                Console.WriteLine(myConsoleText);
                return false;
            }

            if ((args.Length == 1) && (args[0] == "TEST"))
            {
                CashRegisterLibrary.Tests.RunTests();
                return false;
            }

            if (args.Length != 2)
            {
                myConsoleText = "Please provide an input and output file. Ex: CashRegister input.txt output.txt";
                Console.WriteLine(myConsoleText);
                return false;
            }

            InputFile = args[0];
            if (!File.Exists(InputFile))
            {
                myConsoleText = "Input file doesn't exist.";
                Console.WriteLine(myConsoleText);
                return false;
            }

            OutputFile = args[1];
            File.Delete(OutputFile);

            return true;
        }

        public static bool IsValidFile()
        {
            InputFileReader = new StreamReader(InputFile);

            while (InputFileReader.Peek() >= 0)
            {
                if (!IsValidLine(InputFileReader.ReadLine())) return false;
            }

            return true;
        }
        public static bool IsValidLine(string line)
        {
            string[] subStrings = line.Split(",");

            if (subStrings.Length != 2)
            {
                myConsoleText = "Malformed line: Each line must contain the total due and the amount paid separated by a comma (for example: 2.13,3.00)";
                Console.WriteLine(myConsoleText);
                return false;
            }

            decimal totalDue;
            if (decimal.TryParse(subStrings[0], out totalDue) == false)
            {
                myConsoleText = "Malformed line: Total Due must be a decimal";
                Console.WriteLine(myConsoleText);
                return false;                
            }

            decimal amountPaid;
            if (decimal.TryParse(subStrings[1], out amountPaid) == false)
            {
                myConsoleText = "Malformed line: Amount Paid must be a decimal";
                Console.WriteLine(myConsoleText);
                return false;                
            }

            InputLines.Add(new InputLine(totalDue, amountPaid));

            return true;
        }
        public static void OutputChange()
        {            
            foreach (InputLine currentLine in InputLines)
            {
                OutputLines.Add(GenerateOutputLine(currentLine));
            }

            File.WriteAllLines(OutputFile, OutputLines);
        }

        public static string GenerateOutputLine(InputLine inputLine)
        {
            int remainingPennies = (int) (100 * (inputLine.AmountPaid - inputLine.TotalDue));

            bool isNormal = remainingPennies % 3 != 0;

            int hundreds = (isNormal ? remainingPennies/10000 : _random.Next(0, remainingPennies/10000));
            remainingPennies -= 10000*hundreds;

            int twenties = (isNormal ? remainingPennies/2000 : _random.Next(0, remainingPennies/2000));
            remainingPennies -= 2000*twenties;

            int fives = (isNormal ? remainingPennies/500 : _random.Next(0, remainingPennies/500));
            remainingPennies -= 500*fives;

            int dollars = (isNormal ? remainingPennies/100 : _random.Next(0, remainingPennies/100));
            remainingPennies -= 100*dollars;

            int quarters = (isNormal ? remainingPennies/25 : _random.Next(0, remainingPennies/25));
            remainingPennies -= 25*quarters;

            int dimes = (isNormal ? remainingPennies/10 : _random.Next(0, remainingPennies/10));
            remainingPennies -= 10*dimes;

            int nickles = (isNormal ? remainingPennies/5 : _random.Next(0, remainingPennies/5));
            remainingPennies -= 5*nickles;

            StringBuilder outputLine = new StringBuilder();
            if (hundreds > 0)
            {
                outputLine.Append(hundreds);
                outputLine.Append(hundreds > 1 ? " hundreds" : " hundred");
            }

            if (twenties > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(twenties);
                outputLine.Append(twenties > 1 ? " twenties" : " twenty");
            }

            if (fives > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(fives);
                outputLine.Append(fives > 1 ? " fives" : " five");
            }

            if (dollars > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(dollars);
                outputLine.Append(dollars > 1 ? " dollars" : " dollar");
            }

            if (quarters > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(quarters);
                outputLine.Append(quarters > 1 ? " quarters" : " quarter");
            }

            if (dimes > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(dimes);
                outputLine.Append(dimes > 1 ? " dimes" : " dime");
            }

            if (nickles > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(nickles);
                outputLine.Append(nickles > 1 ? " nickles" : " nickle");
            }

            if (remainingPennies > 0)
            {
                if (outputLine.Length > 0) outputLine.Append(",");
                outputLine.Append(remainingPennies);
                outputLine.Append(remainingPennies > 1 ? " pennies" : " penny");
            }

            return outputLine.ToString();
        }
        
        
    }
}
