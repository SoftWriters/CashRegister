using System.Collections.Generic;

namespace CashRegister.Internal.Financial
{
	/// <summary>Interface for Regional Currencies</summary>
	internal interface IRegionCurrency
	{
		List<Currency> Denominations { get; }

		/// <summary>
		/// Gets the descending ordered currencies.
		/// </summary>
		/// <returns></returns>
		List<Currency> GetDescendingOrderedCurrencies();
	}
}