using System;
using System.Collections.Generic;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICashRegister cr = new CashRegister();
            IReadService reader = new ReadService();
            IWriteService writer = new WriteService();

            List<decimal> output = new List<decimal>();
            
            try
            {
                output = reader.ReadFile();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

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
