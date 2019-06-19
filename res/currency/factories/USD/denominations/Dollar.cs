//This file is deprecated.  todo - I can add all the denominations to a respective class for more customization and abstraction
using CCDS.res.currency.interfaces.factory.components;
namespace CCDS.res.currency.factories.USD.denominations
{
    public class Dollar : ICurrencyValue
    {
        public decimal ToDecimal() => 0.00m;
    }
}