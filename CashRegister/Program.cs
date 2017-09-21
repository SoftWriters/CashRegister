using System;
using System.Diagnostics;
using ChangeCalculator;
using System.IO;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                FileOperation(args[0], args[1]);
            }
            else
            {
                Console.WriteLine($"Give input and output filenames as arguments, example \"{System.IO.Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName)} c:/temp/in.txt c:/temp/out.txt\"");
            }
        }

        static void FileOperation(string inputFile, string outputFile)
        {
            FileHandler handler = new FileHandler(inputFile, outputFile);
            MinChangeCalculator minCalculator = new MinChangeCalculator();
            RandomChangeCalculator randomCalculator = new RandomChangeCalculator();

            ChangeCalculator.ChangeCalculator calculator = new ChangeCalculator.ChangeCalculator(handler, minCalculator, randomCalculator);

            try
            {
                calculator.CalculateChange();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Failed to find file {inputFile}");
            }
            catch (IOException)
            {
                Console.WriteLine($"Failed to save file {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }
        }
    }
}
