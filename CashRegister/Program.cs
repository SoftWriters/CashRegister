using System;
using System.IO;

namespace CashRegisterConsumer
{
    internal class Program
    {
        private static readonly string prefaceFilePath = @"C:\Users\plwes\source\repos\CashRegister\CashRegister\Preface.txt";
        private static readonly string usdInputFilePath = @"C:\Users\plwes\source\repos\CashRegister\CashRegister\CashRegisterInputFiles\USD Input File.txt";
        private static readonly string yenInputFilePath = @"C:\Users\plwes\source\repos\CashRegister\CashRegister\CashRegisterInputFiles\YEN Input File.txt";
        private static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(prefaceFilePath, System.Text.Encoding.UTF8))
            {
                Console.SetWindowSize(150, 25);
                Console.WriteLine(sr.ReadToEnd());
            }
            
            Console.ReadKey();

            try
            {
                CashRegister register = new POSCashRegister(new USD(), new Random3Strategy());
                var result = register.Tender(usdInputFilePath);
                Console.WriteLine(result);


                // for example (change the register to use YEN with a Standard Tender Strategy note that the demoniations are different so
                // the same files that use "USD" decimals will be off. There are no decimals in YEN
                register.RegisterCurrency(new YEN());
                register.RegisterTenderStrategy(new StandardTenderStrategy());
                result = register.Tender(yenInputFilePath);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
            }


            Console.ReadKey();
        }
    }
}