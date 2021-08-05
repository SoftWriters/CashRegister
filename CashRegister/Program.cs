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

            List<decimal> output = reader.ReadFile();

            List<Change> changeList = new List<Change>();

            for (int i = 0; i < output.Count - 1; i += 2)
            {
                Change change = new Change();
                change = cr.GetChange(output[i], output[i + 1]);
                changeList.Add(change);
            }
            
            writer.WriteFile(changeList);

        }
    }
}
