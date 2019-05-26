using System.Collections.Generic;
using System.IO;
using Changemaker;
using Common;
using System;

namespace ChangemakerFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            { Console.WriteLine("Input file name is required."); }
            var fileName = args[0];
            var outFileName = "output1.txt";
            if (args.Length > 1)
            {
                outFileName = args[1];
            }
            TextReader tr = new StreamReader(fileName);
            var outputLines = new List<string>();
            string line = tr.ReadLine();
            while (line != null && line.Length > 0)
            {
                var split = line.Split(','); // Split line into owed and paid
                Process.GetDenominations(split[0], split[1]).AddToList(ref outputLines);
                line = tr.ReadLine();
            }
            tr.Close();
            File.WriteAllLines(outFileName, outputLines);
        }
    }
}
