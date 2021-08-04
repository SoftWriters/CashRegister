using System;
using System.Collections.Generic;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CashRegister cr = new CashRegister();
            ReadService reader = new ReadService();
            WriteService writer = new WriteService();

            List<decimal> ouput = reader.ReadFile();
            
            Change change = cr.GetChange(3.33M);
            writer.WriteFile(change);

        }
    }
}
