using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Driver
    {
        static void Main(string[] args)
        {
            // Example of how to use the program. To use in this format,
            // enter valid file paths for the inputFilePath and outputFilePath
            // strings.
            string inputFilePath = "Input.txt";
            string ouputFilePath = "Output.txt";
            CashRegisterService cashRegisterService = new CashRegisterService();
            cashRegisterService.CalculateChangeFromFiles(inputFilePath, ouputFilePath);
            System.Console.ReadLine();
        }
    }
}
