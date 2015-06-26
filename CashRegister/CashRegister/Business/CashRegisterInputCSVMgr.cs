using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegisterProject.Model;
using System.IO;

namespace CashRegisterProject.Business
{
    public class CashRegisterInputCSVMgr : ICashRegisterInputMgr
    {

        public CashRegisterInputCSVMgr()
        {
           
        }
        public List<TransactionAmounts> HandleInput(string infile)
        {
            var list = new List<TransactionAmounts>();
            using (var rd = new StreamReader(infile))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    var ta = new TransactionAmounts
                    {
                        AmountOwed = decimal.Parse(splits[0]),
                        AmountPaid = decimal.Parse(splits[1])
                    };
                    list.Add(ta);
                }
            }
            return list;
        }
    }
}
