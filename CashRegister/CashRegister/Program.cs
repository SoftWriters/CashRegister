using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeTranslator;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new CsvTranslator().CsvToDtos(@"C:\Users\lgettel\Source\Repos\CashRegister\temp.csv");
            var output = x.Select(y => new ChangeOutput().MakeChange(y.Cost, y.Paid, y.RandomChange));
            new CsvTranslator().StringsToCsv(@"C:\Users\lgettel\Source\Repos\CashRegister\temp1.csv", output);
            Console.ReadLine();
        }
    }
}
