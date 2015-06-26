using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegisterProject.Business
{
    public class TranslatorFactory
    {
        AbsTranslator translator = null;
         public AbsTranslator GetTranslator(string currency)
        {
            switch (currency)
            {
                case MoneyConstants.USD: 
                    translator = new TranslatorUSD();
                    break;
                case MoneyConstants.RandomUSD:
                    translator = new TranslatorUSDRandom();
                    break;
            }
            return translator;
        }

       
      
    }
}
