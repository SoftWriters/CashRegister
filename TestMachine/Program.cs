using System;
using CashMachine.Domain;
using CashMachine.Infrastructure;
using StructureMap;

namespace CashMachine
{
    class Program
    {
        private static void Main(string[] args)
        {
            var container = new Container(c => c.AddRegistry<AppScanRegistry>());
            var changeMaker = container.GetInstance<IPurchaseStrategy>();
            var fileProcessor = container.GetInstance<IFileProcessor>();

            string inputFilename = args.Length > 0 ? args[0] : "InputSample.csv";
            var dts = inputFilename + ".out" + DateTime.Now.ToString("yyyyMMddHHMMSS");
            string outputFilename = args.Length > 1 ? args[1] : dts;

            fileProcessor.ProcessFile(inputFilename, outputFilename, purchaseText =>
            {
                var purchase = new Purchase(purchaseText);
                var change = changeMaker.MakePurchase(purchase);
                Console.Out.Write(purchase + " => " + change + "\n");
                return change.ToString();
            });

            // SO that I can read it when I execute in the VS....
            Console.In.ReadLine();
        }
    }

}
