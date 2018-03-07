using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace ChangeMaker
{
    /// <summary>
    /// ValidCurrencies object, which provides information about what types of currencies exist in the system. Currencies are initialized via Currencies.xml.
    /// </summary>
    public static class ValidCurrencies
    {
        public static List<Currency> CurrencyList;

        /// <summary>
        /// Initialize the list of currencies from Currencies.xml
        /// </summary>
        public static void Initialize()
        {
            try
            {   
                var currencyFile = XDocument.Load(@".\Config\Currencies.xml");

                CurrencyList = (from currency in currencyFile.Descendants("Currencies").Elements("Currency")
                                select new Currency
                                {
                                    Denomination = currency.Element("Denomination")?.Value,
                                    ValueString = currency.Element("Value")?.Value,
                                    DenominationPlural = currency.Element("DenominationPlural")?.Value
                                }).ToList();

                //Check to see if all necessary items were populated in each currency
                foreach (var c in CurrencyList)
                {
                    if (string.IsNullOrEmpty(c.Denomination)
                        || string.IsNullOrEmpty(c.ValueString)
                        || string.IsNullOrEmpty(c.DenominationPlural))
                    {
                        var error = "Currency configuration file was malformed - Check Currencies.xml. Each Currency entry should have Denomination, Value and DenominationPlural nodes.";
                        Log.WriteLine(error);
                        throw new InvalidDataException(error);
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Log.WriteLine("Could not find Currencies.xml configuration file");
                throw;
            }
        }
    }
}
