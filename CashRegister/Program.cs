using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.BL;
using CashRegister.BL.Services;

namespace CashRegister
{
	class Program
	{
		static void Main(string[] args)
		{
            if (args.Length == 0)
            {
				Console.WriteLine("Provide input and output file");
                Usage();
                return;
            }
			string input = null, output = null;
			IInputSource fileInput = null;
			IOutputSource fileOut = null;
			foreach (string arg in args)
			{
				switch (arg.Substring(0, 2).ToUpper())
				{
					case "-I":
						// process argument...
						input = arg.Substring(3);
						fileInput = new InputFile(input);
						break;
					case "-O":
						// process arg...
						output =arg.Substring(3);
						fileOut = new OutputFile(output);
						break;
				}
			}
			if (fileInput == null)
			{
				Console.WriteLine("No input file provided");
                Usage();
                return;
			}
			if (fileOut == null)
			{
				Console.WriteLine("No output file provided");
                Usage();
                return;
			}


			try {
				var register = new Register(fileInput, fileOut);
				Console.WriteLine("Processing... {0}", input);
				var totalProcess =register.Process();
				Console.WriteLine("Total Transactions: {0}", totalProcess);
				Console.WriteLine("Saved to...{0}", output);
			}
			catch (Exception ex) {
				Console.WriteLine(ex);
			}
		}

        private static void Usage()
        {
            Console.WriteLine("CashRegister ");
            Console.WriteLine("-i:file - Absolute Filename to import");
            Console.WriteLine("-o:file - Absolute Filename for output");
        }
	}
}
