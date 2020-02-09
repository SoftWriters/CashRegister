using System;

namespace CashRegisterConsumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Consumer Console... This is for the benefit of the code submission
            // to help the evaluators of my code to see the CashRegister Module
            // as it would be used by a consuming class in real world development
            // Consider the console the POS where the "CashRegister" just tenders transactions.
            Console.WriteLine(@"The Console is the ""CONSUMER"" of the CashRegister Module.");
            Console.WriteLine();
            Console.WriteLine(@"Press any button to continue with using the CashRegister Module. (Simulates POS ""Tender"" actions)");
            Console.WriteLine();
            Console.ReadKey();

            CashRegister register = new POSCashRegister(new USD(), new Random3Strategy());
            var result = register.Tender(@"C:\Users\plwes\source\repos\CashRegister\CashRegister\CashRegisterInputFiles\USD Input File.txt");
            Console.WriteLine(result);

            // for example (change the register to use YEN with a Standard Tender Strategy note that the demoniations are different so
            // the same files that use "USD" decimals will be off. There are no decimals in YEN
            //register.RegisterCurrency(new YEN());
            //register.RegisterTenderStrategy(new StandardTenderStrategy());
            //result = register.Tender(@"C:\Users\plwes\source\repos\CashRegister\CashRegister\Input\YEN Input File.txt");
            //Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}