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
            string filename;

            //Try to get the filename from args, otherwise prompt for input
            if (args.Length > 0)
            {
                filename = args[0];
            }
            else
            {
                Console.WriteLine("Enter filename");
                filename = Console.ReadLine();
                Console.WriteLine();
            }

            //If the user did not specify an absolute path / folder structure, assume the file is at the current directory
            if (!filename.Contains(@"\"))
            {
                filename = @".\" + filename;
            }

            var transactionList = new List<Transaction>();

            //Read the file, line by line
            try
            {
                var inputLines = File.ReadLines(filename).ToList();
                if(inputLines.Count == 0)
                {
                    Console.WriteLine("No input found in input file");
                    return;
                }

                //Try to convert each line into a Transaction to be processed
                for(var i = 0; i < inputLines.Count; i++)
                {
                    var inputTokens = inputLines[i].Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    
                    //Must have exactly 2 tokens in each line
                    if(inputTokens.Length < 2)
                    {
                        Console.WriteLine($"Error in line {i + 1} of input file - both a cost and amount tendered must be provided. Line contents: {inputLines[i]}");
                    }

                    if(inputTokens.Length > 2)
                    {
                        Console.WriteLine($"Warning - line {i + 1} contained more than two items of input. Expecting two (cost and amount tendered). Utilizing the first two values as the cost and amount.");
                    }

                    //Convert the strings to decimals and create a Transaction record
                    decimal cost, amountTendered;
                    try
                    {
                        cost = Convert.ToDecimal(inputTokens[0].Trim());

                        try
                        {
                            amountTendered = Convert.ToDecimal(inputTokens[1].Trim());
                            transactionList.Add(new Transaction(cost, amountTendered));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Error - Amount Tendered in line {i + 1} was in an invalid format. Input provided: {inputTokens[1]}");
                            return;
                        }
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine($"Error - Cost in line {i + 1} was in an invalid format. Input provided: {inputTokens[0]}");
                        return;
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }
            catch (IOException)
            {
                Console.WriteLine($"File IO error when attempting to open input file: {filename}");
                return;
            }
            
            //Process the transactions and output the change
            foreach (var tran in transactionList)
            {
                tran.CalculateChange();
                tran.DisplayChange();
            }
        }
    }
}
