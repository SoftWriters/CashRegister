using System;
using System.IO;

namespace CashMachine.Infrastructure
{
    public interface IFileProcessor
    {
        void ProcessFile(string purchaseFilename, string outputFilename, Func<string,string> process);
    }

    public class FileProcessor : IFileProcessor
    {
        public void ProcessFile(string purchaseFilename, string outputFilename, Func<string, string> process)
        {
            if (!File.Exists(purchaseFilename))
            {
                Console.Out.WriteLine("Error: Could not open file: " + purchaseFilename);
                return;
            }

            using (var outputFile = new StreamWriter(outputFilename))
            {
                using (var inputFile = File.OpenText(purchaseFilename))
                {
                    string inputLine;

                    // Used for debugging the input file. Trust me, it helps.
                    int lineNumber = 0;

                    while ((inputLine = inputFile.ReadLine()) != null)
                    {
                        try
                        {
                            // # is a comment for our purchases files
                            if (!inputLine.Contains("#"))
                            {
                                lineNumber++;
                                var outputLine = process(inputLine);
                                outputFile.WriteLine(outputLine);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Out.WriteLine("ChangeMaking failure on line " + lineNumber + " :" + inputLine);
                            Console.Out.WriteLine("Error: " + ex);
                        }
                    }
                }
            }
        }
    }
}