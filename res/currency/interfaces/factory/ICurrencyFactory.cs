// Here is where you define the parts that are required if an object wants to be valid currency
using CCDS.res.currency.interfaces.factory.components;
namespace CCDS.res.currency.interfaces.factory
{
    public interface ICurrencyFactory
    {
        ICurrencyValue SetCurrencyFaceValue(); //at a minimum, all currencies are worth something in value.
    }
}