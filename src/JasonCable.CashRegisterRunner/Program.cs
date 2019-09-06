using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JasonCable.CashRegister;
using System.Reflection;
using System.Text;

namespace JasonCable.CashRegisterRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string thisDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string defaultInFile = Path.Combine(thisDir, "input.csv");
            string defaultOutFile = Path.Combine(thisDir, "output.txt");

            Console.Write("Input File (input.csv): ");
            string inFile = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inFile) || !File.Exists(inFile))
            {
                Console.WriteLine("Input file does not exist.  Using default location.");
                inFile = defaultInFile;

                if (!Directory.Exists(Path.GetDirectoryName(inFile)))
                    throw new Exception("Input file directory does not exist!");
            }

            Console.Write("Output File (output.txt): ");
            string outFile = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(outFile))
            {
                outFile = defaultOutFile;
            }
            else if (!Directory.Exists(Path.GetDirectoryName(outFile)))
            {
                Console.WriteLine("Output file directory does not exist!  Using default.");
                outFile = defaultOutFile;
            }

            try
            {
                using (StreamReader sr = new StreamReader(inFile))
                using (StreamWriter sw = new StreamWriter(outFile, false, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (String.IsNullOrWhiteSpace(line))
                        {
                            sw.WriteLine("EMPTY LINE");
                            continue;
                        }

                        string[] sa = line.Split(',');

                        if(sa.Length != 2)
                        {
                            WriteStringLine(sw, "LINE DOES NOT HAVE TWO VALUES");
                            continue;
                        }

                        if(String.IsNullOrWhiteSpace(sa[0]) || String.IsNullOrWhiteSpace(sa[1]))
                        {
                            WriteStringLine(sw, "BAD DATA FORMAT");
                            continue;
                        }

                        if(!Decimal.TryParse(sa[0], out decimal col0Value))
                        {
                            WriteStringLine(sw, "BAD DATA FORMAT");
                            continue;
                        }

                        if (!Decimal.TryParse(sa[1], out decimal col1Value))
                        {
                            WriteStringLine(sw, "BAD DATA FORMAT");
                            continue;
                        }

                        CurrencyAmount ca0 = col0Value;
                        CurrencyAmount ca1 = col1Value;
                        var result = ca0 - ca1;

                        sw.WriteLine(result.MixUpDenominationsIfModThreePennies());
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static void WriteStringLine(StreamWriter sw, string message)
        {
            sw.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
