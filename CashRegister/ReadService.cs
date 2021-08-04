using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CashRegister
{
    public class ReadService
    {
        private static string FileName { get; } = "input.txt";
        private static string Directory { get; } = Environment.CurrentDirectory;
        private readonly string FilePath = Path.Combine(Directory, FileName);

        public List<decimal> ReadFile()
        {
            List<decimal> output = new List<decimal>();

            try
            {
                using(StreamReader streamReader = new StreamReader(FilePath))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        string[] temp = new string[2];
                        temp = line.Split(',');

                        output.Add(decimal.Parse(temp[0]));
                        output.Add(decimal.Parse(temp[1]));
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return output;
        }
    }
}
