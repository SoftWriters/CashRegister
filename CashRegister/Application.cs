using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{

    //A simple class to act as the "larger system" that uses this project's functionality
    class Application
    {
        static void Main(string[] args)
        {
            CashRegisterApp cr = new CashRegisterApp(); 
            cr.calculateChange(@args[0]);
        }
    }
}
