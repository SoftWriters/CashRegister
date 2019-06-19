//This is a file to keep abstracted currency information for the corresponding currency factory (i.e., USD).
using CCDS.res.currency.@base.derived;
namespace CCDS.res.currency.factories.USD
{
    public class USD
    {
        public InternationalCurrency GetCurrency(string chosenCurrency)
        {
            InternationalCurrency currency = null;
            switch (chosenCurrency.ToUpper())
            {
                case "DOLLARS":
                    currency = new InternationalCurrency(new USDCurrencyFactory());
                    currency.SetPluralName(chosenCurrency.ToLower());
                    currency.SetSingularName(chosenCurrency.ToLower().Remove(chosenCurrency.Length - 1));
                    currency.SetValue(1.00m);
                    currency.SetQuantity(0);
                    break;
                case "QUARTERS":
                    currency = new InternationalCurrency(new USDCurrencyFactory());
                    currency.SetPluralName(chosenCurrency.ToLower());
                    currency.SetSingularName(chosenCurrency.ToLower().Remove(chosenCurrency.Length - 1));
                    currency.SetValue(0.25m);
                    currency.SetQuantity(0);
                    break;
                case "DIMES":
                    currency = new InternationalCurrency(new USDCurrencyFactory());
                    currency.SetPluralName(chosenCurrency.ToLower());
                    currency.SetSingularName(chosenCurrency.ToLower().Remove(chosenCurrency.Length - 1));
                    currency.SetValue(0.10m);
                    currency.SetQuantity(0);
                    break;
                case "NICKLES":
                    currency = new InternationalCurrency(new USDCurrencyFactory());
                    currency.SetPluralName(chosenCurrency.ToLower());
                    currency.SetSingularName(chosenCurrency.ToLower().Remove(chosenCurrency.Length - 1));
                    currency.SetValue(0.05m);
                    currency.SetQuantity(0);
                    break;
                case "PENNIES":
                    currency = new InternationalCurrency(new USDCurrencyFactory());
                    currency.SetPluralName(chosenCurrency.ToLower());
                    currency.SetSingularName(chosenCurrency.ToLower().Remove(chosenCurrency.Length - 3) + "y");
                    currency.SetValue(0.01m);
                    currency.SetQuantity(0);
                    break;
            }
            return currency;
        }
    }
}