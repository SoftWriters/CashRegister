using CCDS.res.currency.interfaces.factory;
namespace CCDS.res.currency.@base.derived
{
    public class InternationalCurrency : Currency
    {
        private ICurrencyFactory _currencyFactory;  // We want to use the factory that makes currencies
        public InternationalCurrency(ICurrencyFactory currencyFactory) => _currencyFactory = currencyFactory;  // Value is sent to this method. therefore, Currency must have a value assigned. 
        protected internal override void ChooseCurrency()  // This method is invoked to assign specific value objects here; to build a specific currency
        {
            //Value = _currencyFactory.SetCurrencyFaceValue();  //currently not used.  todo - I could build specific classes for another layer of abstraction
        }
    }
}