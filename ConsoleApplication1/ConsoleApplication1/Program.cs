using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(String.Compare(args[0], "-help", ignoreCase: true)==0)
            {
                Console.WriteLine("The input format is <input file> <output file>\r\nInput file should contain one transaction per line\r\nand be in the format <bill>,<payment>");
            }
            else
            {
                Currency     currency  = new USD(USD.MORE_BILLS|USD.HIGH_VALUES);
                CashRegister register  = new CashRegister(@args[0],currency);
                register.change_to_file(@args[1]);
            }
        }
    }
}
