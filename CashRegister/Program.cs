using System;
using System.IO;

namespace CashRegisterConsumer
{
    internal class Program
    {
        private static readonly string prefacePath = @"C:\Users\plwes\source\repos\CashRegister\CashRegister\Preface.txt";
        private static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(prefacePath, System.Text.Encoding.UTF8))
            {
                Console.SetWindowSize(150, 20);
                Console.WriteLine(sr.ReadToEnd());
            }
            
            Console.ReadKey();

            try
            {
                CashRegister register = new POSCashRegister(new USD(), new Random3Strategy());
                var result = register.Tender(@"C:\Users\plwes\source\repos\CashRegister\CashRegister\CashRegisterInputFiles\USD Input File.txt");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
            }

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