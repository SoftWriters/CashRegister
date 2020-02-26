using System;
using System.Collections.Generic;
using System.IO;
using CashRegister.Internal.Calculation;
using CashRegister.Internal.Helpers;
using CommandLine;

namespace CashRegister
{
	internal class Program
	{
		/// <summary>
		/// Command line parser options;
		/// </summary>
		public class Options
		{
			[Option('i', "inputFile", Required = true, HelpText = "File to be processed.")]
			public string InputFile { get; set; }

			[Option('o', "outputFile", Required = false, HelpText = "File to write to.")]
			public string OutputFile { get; set; }

			[Option('r', "randomizeAllChange", Required = false, HelpText = "True: Randomize all change due.  False(default): randomize only decimal amount.")]
			public bool RandomizeAllChange { get; set; }

			[Option('g', "generateInputFile", Required = false, HelpText = "Will generate an input file using inputFile name provided and populate with test data. Default number of rows is 500, set different value with n switch")]
			public bool GenerateInputFile { get; set; }
			[Option('n', "numberOfRowsToGenerate", Required = false, HelpText = "Overrides the number of rows created when generating test file")]
			public int RowsToGenerate { get; set; }

			[Option('c', "currencyISOCode", Required = false, HelpText = "Used to override local currency value for processing.")]
			public string CurrencyCode { get; set; }
		}
		private static void Main(string[] args)
		{
			Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions).WithNotParsed(ParseError);
			
		}

		private static void ParseError(IEnumerable<Error> obj)
		{
			Console.WriteLine("Invalid command line options given");
		}

		private static void RunOptions(Options obj)
		{
			string inputFile = obj.InputFile;
			string outputFile = obj.OutputFile;
			if (outputFile == null)
			{
				outputFile = Path.GetDirectoryName(inputFile) + @"\" + Path.GetFileNameWithoutExtension(inputFile) + "_processed.txt";
			}

			if (obj.GenerateInputFile)
			{
				int rowsToGenerate = obj.RowsToGenerate == 0 ? 500 : obj.RowsToGenerate;
				TestFileGeneration.GenerateTestFile(inputFile, rowsToGenerate);
			}
			

			//threshold for storing transactions in memory
			//can be much higher but 100k seemed reasonable 
			//for this exercise.
			int dataDumpThreshold = 100000;


			if (TransactionProcessor.ProcessTransactions(inputFile, outputFile, dataDumpThreshold, obj.RandomizeAllChange, CurrencySelector.GetCurrency(obj.CurrencyCode)))
			{
				Console.WriteLine("Finished processing without error");
			}
			else
			{
				Console.WriteLine("Finished processing with error(s)");
			}
			Console.WriteLine("Press any key to end...");
			Console.ReadKey();
		}
	}
}