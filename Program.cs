using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {

        //I"m pretty confident its bad form to put much of anything here. However it seems odd to make a class simply to avoid using one.
        //Best practices probally make more sense with a larger program.
        static void Main(string[] args)
        {
            CashRegister.Input inputClass = new CashRegister.Input();
            CashRegister.Process processClass = new CashRegister.Process();

            Console.Clear();

            string inputString;
            string outputString;

            inputString = inputClass.GetValues();

            outputString = processClass.Response(inputString);

            Console.WriteLine(inputString); //shows input for test / verification reasons.
            Console.WriteLine(outputString);            

            Console.ReadKey(); //so we dont close automaticly.
        }

    }

    

}
