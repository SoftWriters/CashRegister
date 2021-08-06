using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace CashRegister
{
    public class ReadService
    {
        private static string FileName { get; } = "input.txt";
        //private static string Dir { get; } = Environment.CurrentDirectory;
        //private static string outputDir { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

        private static readonly string WorkingDirectory = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName;

        private readonly string FilePath = Path.Combine(WorkingDirectory, FileName);
        
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
