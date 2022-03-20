using System.Collections.Generic;
using System.Linq;

namespace CashRegister.Internal.Financial.RegionCurrency
{
	/// <summary>
	/// Euro implementation of currency
	/// </summary>
	/// <seealso cref="CashRegister.Internal.Financial.IRegionCurrency" />
	internal class EURCurrency : IRegionCurrency
	{
		public List<Currency> Denominations { get; }

		public EURCurrency()
		{
			Denominations = new List<Currency>
			{
				new Currency("1c", "1c", .01m),
				new Currency("2c", "2c", .02m),
				new Currency("5c", "5c", .05m),
				new Currency("10c", "10c", .10m),
				new Currency("20c", "20c", .20m),
				new Currency("50c", "50c", .50m),
				new Currency("one", "ones", 1),
				new Currency("two", "twos", 2),
				new Currency("five", "fives", 5),
				new Currency("ten", "tens", 10),
				new Currency("twenty", "twenties", 20),
				new Currency("hundred", "hundreds", 100),
				new Currency("two hundred", "two hundreds", 200),
				new Currency("five hundred", "five hundreds", 500)
			};
		}

		public List<Currency> GetDescendingOrderedCurrencies()
		{
			return Denominations.OrderByDescending(x => x.Value).ToList();
		}
	}
}