// This is the only class that needs to change to determine which currency is provided as an option 
using System.Collections.Generic;
using CCDS.res.currency.factories.USD;
namespace CCDS.res.currency.@base.derived
{
    public class InternationlCurrencyChooser : CurrencyChooser
    {
        protected override List<Currency> GetCurrencyList(string nationalCurrencyChoice)
        {
            List<Currency> nationalCurrency = new List<Currency>();
            switch (nationalCurrencyChoice.ToUpper())
            {
                case "USD":
                    nationalCurrency.Add(new USD().GetCurrency("DOLLARS"));
                    nationalCurrency.Add(new USD().GetCurrency("QUARTERS"));
                    nationalCurrency.Add(new USD().GetCurrency("DIMES"));
                    nationalCurrency.Add(new USD().GetCurrency("NICKLES"));
                    nationalCurrency.Add(new USD().GetCurrency("PENNIES"));
                    break;
            }   //<--  Additional factories added here (Euro, BTC, w/e)...
            return nationalCurrency;
        }
    }
}