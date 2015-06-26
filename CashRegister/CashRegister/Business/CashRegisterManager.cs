using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegisterProject.Model;
using System.IO;

namespace CashRegisterProject.Business
{
    public class CashRegisterManager
    {
        private string input;
        private string output;

        List<TransactionAmounts> TransactionList
        {
            get;
            set;
        }
        public CashRegisterManager(string input, string output)
        {
            this.input = input;
            this.output = output;
        }
        public CashRegisterManager()
        {
            // TODO: Complete member initialization
        }
       

        public List<TransactionAmounts> GetTransationList()
        {
            return TransactionList;
        }
        /*
   * . Accept a flat file as input
      +	1. Each line will contain the amount owed and the amount paid separated by a comma (for example: 2.13,3.00)
      +	2. Expect that there will be multiple lines
   */
       
        public string ProcessAmounts(TransactionAmounts transactionAmounts)
        {
            string str;
            AbsTranslator translator;
                decimal d = new CashRegister().CalculateChange(transactionAmounts);
                if (d > 0)
                {
                    if ((d % 3) == 0)
                    {
                        translator = new TranslatorFactory().GetTranslator(MoneyConstants.RandomUSD);
                        str = translator.TranslateAmount(d);
                    }
                    else
                    {
                        translator = new TranslatorFactory().GetTranslator(MoneyConstants.USD);
                        str = translator.TranslateAmount(d);
                    }
                }
                else if (d == 0)
                {
                    str = "You have paid the exact amount";
                }
                else
                {
                    translator = new TranslatorFactory().GetTranslator(MoneyConstants.USD);
                    str = "You still owe "+translator.TranslateAmount(Math.Abs(d));
                }
               
            return str;
        }

        public List<string> ProcessAmountsFromList(List<TransactionAmounts> list)
        {
            return list.Select(ProcessAmounts).ToList();
        }

    }
}
