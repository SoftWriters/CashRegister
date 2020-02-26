using System.Collections.Generic;
using System.Linq;

namespace CashRegister.Internal.Financial.RegionCurrency
{
	/// <summary>
	/// Canadian Dollar implementation of currency
	/// </summary>
	/// <seealso cref="CashRegister.Internal.Financial.IRegionCurrency" />
	internal class CADCurrency : IRegionCurrency
	{
		public List<Currency> Denominations { get; }

		public CADCurrency()
		{
			Denominations = new List<Currency>
			{
				new Currency("penny", "pennies", .01m),
				new Currency("nickel", "nickels", .05m),
				new Currency("dime", "dimes", .10m),
				new Currency("quarter", "quarters", .25m),
				new Currency("half dollar", "half dollars", .50m),
				new Currency("loonie", "loonies", 1),
				new Currency("toonie", "toonies", 2),
				new Currency("five", "fives", 5),
				new Currency("ten", "tens", 10),
				new Currency("twenty", "twenties", 20),
				new Currency("fifty", "fifties", 50),
				new Currency("hundred", "hundreds", 100)
			};
		}

		public List<Currency> GetDescendingOrderedCurrencies()
		{
			return Denominations.OrderByDescending(x => x.Value).ToList();
		}
	}
}