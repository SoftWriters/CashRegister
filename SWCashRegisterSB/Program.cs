using SWCashRegisterSB.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCashRegisterSB
{
    /// <summary>
    /// Softwriters Cash Register by Stephen Bierly
    /// Input file location is: "{RepoPath}\\SWCashRegisterSB\\input.txt"
    /// Output file location is: "{RepoPath}\\SWCashRegisterSB\\output.txt"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = Path.GetFullPath(@"..\..\");
            var inputPath = basePath + "input.txt";
            var outputPath = basePath + "output.txt";


            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Could not find input file. Expected to be '{inputPath}'");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            try
            {            
                using (StreamWriter outWriter = new StreamWriter(outputPath, false))
                {
                    var currentLineNum = 1;
                    foreach (var line in File.ReadLines(inputPath))
                    {
                        var parts = line.Split(',');
                        decimal amountDue;
                        decimal amountPaid;
                        if(parts.Length != 2 || !decimal.TryParse(parts[0], out amountDue) || !decimal.TryParse(parts[1], out amountPaid))
                        {
                            Console.WriteLine($"Improperly formated line '{line}' on line '{currentLineNum}");
                            currentLineNum++;
                            continue;
                        }

                        //Excluding the possibility of refunds currently
                        if(amountDue < 0 || amountPaid < 0)
                        {
                            Console.WriteLine($"Amount Paid ('{amountPaid}') and Amount Due ('{amountDue}') must be positive.");
                            continue;
                        }

                        var changeDue = amountPaid - amountDue;

                        if(changeDue < 0)
                        {
                            Console.WriteLine($"Insufficient payment on line '{currentLineNum}', payment is '{Math.Abs(changeDue)}' less than required.");
                            currentLineNum++;
                            continue;
                        }

                        if (changeDue == 0)
                        {
                            Console.WriteLine($"No change due on line {currentLineNum}");
                            currentLineNum++;
                            continue;
                        }

                        var calculator = DenominationUtils.GetChangeCalculator(amountDue);

                        var change = calculator.CalculateChange(changeDue);

                        var changeOutputLine = DenominationUtils.GetChangeOutput(change);

                        outWriter.WriteLine(changeOutputLine);
                        currentLineNum++;
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Unexpected Error : '{e.Message}'");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
