using System;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CashRegister cr = new CashRegister();
            Change change = cr.GetChange(1.27M);
        }
    }
}
