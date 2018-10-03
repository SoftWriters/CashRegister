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
            Currency currency         = new USD(USD.NO_FLAGS);
            CashRegister register = new CashRegister(@"..\..\input.txt",currency);
            register.change_to_file(@"..\..\output.txt");
        }
    }
}
