using System;
using System.IO;

namespace CashRegisterConsumer
{
    public abstract class CashRegister
    {
        private ICurrency _price, _tender;
        private IChangeCalculator _changeCalculator;

        public CashRegister(){}
        public CashRegister(ICurrency priceCurrency, ICurrency tenderCurrency, IChangeCalculator changeCalculator) 
        {
            RegisterPriceCurrency(priceCurrency);
            RegisterTenderCurrency(tenderCurrency);
            RegisterChangeCalculator(changeCalculator);
        }
        public void RegisterPriceCurrency(ICurrency priceCurrency)
        {
            this._price = priceCurrency;
        }
        public void RegisterTenderCurrency(ICurrency tenderCurrency)
        {
            this._tender = tenderCurrency;
        }
        public void RegisterChangeCalculator(IChangeCalculator changeCalculator)
        {
            this._changeCalculator = changeCalculator;
        }

        public virtual string Tender(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                return Tender(sr);
            }
        }
        public virtual string Tender(StreamReader sr)
        { 
            InputTransaction(sr);
            return _changeCalculator.Calculate(_price, _tender);
        }

        private void InputTransaction(StreamReader sr)
        {
            //todo Using the file stream, load the price and tender
            //todo  into the _price and _tender fields
            do
            {


            } while (!sr.EndOfStream);
            throw new NotImplementedException();
        }

    }
}