using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CashRegister
{
    public class WriteService
    {
        private static string FileName { get; } = "output.txt";
        private static string Directory { get; } = Environment.CurrentDirectory;
        private readonly string FilePath = Path.Combine(Directory, FileName);

        public void WriteFile(Change change)
        {
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(FilePath, true))
                {
                    streamWriter.WriteLine($"{change.Dollar } dollar {change.Quarter} quarters {change.Dime} dimes ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
