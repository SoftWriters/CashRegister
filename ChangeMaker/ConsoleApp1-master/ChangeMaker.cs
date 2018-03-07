using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeMaker
{
    public class ChangeMaker
    {
        static void Main(string[] args)
        {
            string inputFilename;
            string outputFilename = "";

            Log.Initialize();

            //Try to get the filename from args, otherwise prompt for input
            if (args.Length > 0)
            {
                inputFilename = args[0];
                if(args.Length > 1)
                {
                    outputFilename = args[1];
                }
            }
            else
            {
                Console.WriteLine("Enter input filename");
                inputFilename = Console.ReadLine();
                Console.WriteLine();
            }

            if(string.IsNullOrEmpty(outputFilename))
            {
                Console.WriteLine("Enter output filename");
                outputFilename = Console.ReadLine();
                Console.WriteLine();
            }

            //If the user did not specify an absolute path / folder structure, assume the file is at the current directory
            if (!inputFilename.Contains(@"\"))
            {
                inputFilename = @".\" + inputFilename;
            }

            if(!outputFilename.Contains(@"\"))
            {
                outputFilename = @".\" + outputFilename;
            }

            var transactionList = new List<ISellTransaction>();

            //Read the file, line by line
            try
            {
                var inputLines = File.ReadLines(inputFilename).ToList();
                if(inputLines.Count == 0)
                {
                    Log.WriteLine("No input found in input file");
                    return;
                }

                Log.WriteLine("\r\nProcessing Input\r\n");

                //Try to convert each line into a Transaction to be processed
                for(var i = 0; i < inputLines.Count; i++)
                {
                    var inputTokens = inputLines[i].Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    
                    //Must have exactly 2 tokens in each line
                    if(inputTokens.Length < 2)
                    {
                        Log.WriteLine($"Error in line {i + 1} of input file - both a cost and amount tendered must be provided. Line contents: {inputLines[i]}");
                        continue;
                    }

                    if(inputTokens.Length > 2)
                    {
                        Log.WriteLine($"Warning - line {i + 1} contained more than two items of input. Expecting two (cost and amount tendered). Utilizing the first two values as the cost and amount.");
                        continue;
                    }

                    //Convert the strings to decimals and create a Transaction record
                    decimal cost, amountTendered;
                    try
                    {
                        cost = Convert.ToDecimal(inputTokens[0].Trim());

                        try
                        {
                            amountTendered = Convert.ToDecimal(inputTokens[1].Trim());
                            transactionList.Add(new SellTransaction(cost, amountTendered));
                        }
                        catch (FormatException)
                        {
                            Log.WriteLine($"Error - Amount Tendered in line {i + 1} was in an invalid format. Input provided: {inputTokens[1]}");
                            continue;
                        }
                        catch(InvalidOperationException e)
                        {
                            Log.WriteLine(e.Message);
                            continue;
                        }
                    }
                    catch(FormatException)
                    {
                        Log.WriteLine($"Error - Cost in line {i + 1} was in an invalid format. Input provided: {inputTokens[0]}");
                        continue;
                    }
                    catch(InvalidOperationException e)
                    {
                        Log.WriteLine(e.Message);
                        continue;
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Log.WriteLine($"File not found: {inputFilename}");
                return;
            }
            catch (IOException)
            {
                Log.WriteLine($"File IO error when attempting to open input file: {inputFilename}");
                return;
            }

            Log.WriteLine("\r\nInput processing complete. Calculating Change.\r\n");
            
            //Process the transactions and output the change
            foreach (var tran in transactionList)
            {
                tran.CalculateChange();
                tran.DisplayChange();
            }

            Log.OutputToFile(outputFilename);
        }
    }
}
