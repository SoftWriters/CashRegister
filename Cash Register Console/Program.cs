using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;

namespace Cash_Register_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please specifiy the input file");
				return;
			}

			string inputFile = args[0];
			string outputFile = String.Concat(inputFile, ".output");
			Logic.LoadData(inputFile);
			Logic.ProcessData();
			string result = Logic.SaveData(outputFile);
			Console.WriteLine(result);
		}
	}
}
