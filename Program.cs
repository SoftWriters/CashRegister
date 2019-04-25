using System;
using System.Collections.Generic;

namespace CashRegister
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            var denominationsInRegister = new List<ICurrencyDenomination>
            {
                new UsCurrencyDenomination(1, "Penny", "Pennies"),
                new UsCurrencyDenomination(5, "Nickel", "Nickels"),
                new UsCurrencyDenomination(10, "Dime", "Dimes"),
                new UsCurrencyDenomination(25, "Quarter", "Quarters"),
                new UsCurrencyDenomination(100, "Dollar Bill", "Dollar Bills"),
                new UsCurrencyDenomination(500, "Five Dollar Bill", "Five Dollar Bills"),
                new UsCurrencyDenomination(1000, "Ten Dollar Bill", "Ten Dollar Bills"),
                new UsCurrencyDenomination(2000, "Twenty Dollar Bill", "Twenty Dollar Bills"),
                new UsCurrencyDenomination(10000, "Hundred Dollar Bill", "Hundred Dollar Bills")
            };

            IChangeCalculationStrategy randomizedChangeStrategy = new RandomizedChangeCalculationStrategy();
            CashRegister randomCashRegister = new CashRegister(denominationsInRegister, randomizedChangeStrategy);

            string filePath = @"c:\CashRegisterTestInput.txt";
            IPurchaseTransactionImporter purchaseTransactionFileImporter = new PurchaseTransactionFileImporter(filePath);
            IEnumerable<PurchaseTransaction> purchaseTransactions = purchaseTransactionFileImporter.GetPurchaseTransactions();

            foreach (PurchaseTransaction transaction in purchaseTransactions)
            {
                OutputChange(randomCashRegister, transaction);
            }

            Console.ReadLine();
        }

        private static void OutputChange(CashRegister cashRegister, PurchaseTransaction transaction)
        {
            Console.WriteLine(cashRegister.CalculateChange(transaction));
        }
    }
}
