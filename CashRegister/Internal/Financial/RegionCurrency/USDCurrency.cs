using System.Collections.Generic;
using System.Linq;

namespace CashRegister.Internal.Financial.RegionCurrency
{
	/// <summary>
	/// US Dollar implementation
	/// </summary>
	/// <seealso cref="CashRegister.Internal.Financial.IRegionCurrency" />
	internal class USDCurrency : IRegionCurrency
	{
		public List<Currency> Denominations { get; }

		public USDCurrency()
		{
			Denominations = new List<Currency>
			{
				new Currency("penny", "pennies", .01m),
				new Currency("nickel", "nickels", .05m),
				new Currency("dime", "dimes", .10m),
				new Currency("quarter", "quarters", .25m),
				new Currency("one", "ones", 1),
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