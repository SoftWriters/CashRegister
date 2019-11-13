using System;
using System.IO;
using System.Linq;

namespace CashReg
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("Invalid number of arguments provided.  Please provide only the full path to the input file.");
            }
            var filename = args.First();
            if (!Path.IsPathFullyQualified(filename))
            {
                throw new Exception("Invalid file path provided.  Please provide the full path to the input file.");
            }
            
            var transactions = File.ReadLines(filename) // read the lines from the file specified by the argument
                .Select(l => l.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) // for each line, split on , and remove any empties
                .Select(x => new Transaction { Due = double.Parse(x.First()), Paid = double.Parse(x.Skip(1).First()) }) // for each resulting array of strings, construct a transaction object 
                .ToList();
            Console.WriteLine($"Found {transactions.Count} transactions to process.");
            var outputLines = transactions.Select(TransactionProcessor.ProcessTransaction).ToList();
            Console.WriteLine("Done processing transactions. Results:");
            outputLines.ForEach(s=>
            {
                Console.Write("  "); // indent a little
                Console.WriteLine(s);
                Console.WriteLine(); // for readability
            });
            Console.WriteLine("End of results.");
            var directory = Path.GetDirectoryName(filename);
            var outputFile = $@"{directory}\output.txt";
            Console.WriteLine($"Writing output to file: {outputFile}");
            File.WriteAllLines(outputFile, outputLines);
        }
    }
}
