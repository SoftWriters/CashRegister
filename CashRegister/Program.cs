using System;

namespace CashRegisterConsumer
{
    class Program
    {
        static void Main(string[] args)
        {

            // Consumer Console... This is for the benefit of the code submission
            // to help the evaluators of my code to see the CashRegister Module
            // as it would be used by a consuming class in real world development
            // Consider the console the POS where the "CashRegister" just tenders transactions.
            Console.WriteLine(@"The Console is the ""CONSUMER"" of the CashRegister Module.");
            Console.WriteLine();
            Console.WriteLine(@"Press any button to continue with using the CashRegister Module. (Simulates POS ""Tender"" actions)");
            Console.ReadKey();


            CashRegister register = new POSCashRegister(new USD(), new USD(), new Random3ChangeCalculator());
            //register.RegisterPriceCurrency(new USD());
            //register.RegisterTenderCurrency(new USD());
            //register.RegisterChangeCalculator(new Random3ChangeCalculator());

            var result = register.Tender(@"C:\Users\plwes\source\repos\CashRegister\CashRegister\InputText.txt");
            

            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
