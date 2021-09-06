using CashDrawer.App.FileReaders;
using CashDrawer.App.FileWriters;
using CashDrawer.Core;
using CashDrawer.Core.ChangeCalculatorFactories;
using System;
using System.IO;

namespace CashDrawer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Run(args);
        }
    }


    public class Runner
    {
        public void Run(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid command.");
                Console.WriteLine("Usage.........: CashDrawer <input file> <output file>");
                Console.WriteLine("For example...: CashDrawer input.txt output.txt");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                File.Delete(args[1]);

                var inputFileReader = new InputFileReader(args[0], new LineParser());
                var outputFileWriter = new OutputFileWriter(args[1], new Humanizer());
                var changeCalculatorFactory = new ChangeCalculatorFactory();

                if (inputFileReader.HaveMore == false)
                {
                    Console.WriteLine("Input file is empty. Nothing to process.");
                    return;
                }

                var processor = new ChangeProcessor(changeCalculatorFactory);
                processor.Process(inputFileReader, outputFileWriter);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error processing file. " + e.Message);
            }
        }
    }
}
