// This factory uses ICurrencyFactory interface to create very specific dollars //todo implement specific classes for each denom - Value is defined in the interface, and can return an object specifying specific values for each denom
using CCDS.res.currency.factories.USD.denominations;
using CCDS.res.currency.interfaces.factory;
using CCDS.res.currency.interfaces.factory.components;
namespace CCDS.res.currency.factories
{
    public class USDCurrencyFactory : ICurrencyFactory
    {
        public ICurrencyValue SetCurrencyFaceValue() => new Dollar(); // Defines denom object to associate with USD
    }
}