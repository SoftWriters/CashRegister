using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Internal.Financial;
using CashRegister.Internal.Financial.RegionCurrency;

namespace CashRegister.Internal.Helpers
{
	/// <summary>
	/// Simple helper for setting the currency that will be used
	/// moves it out of Program
	/// </summary>
	internal static class CurrencySelector
	{
		public static IRegionCurrency GetCurrency()
		{
			return GetCurrency(new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID).ISOCurrencySymbol);
		}

		public static IRegionCurrency GetCurrency(string toUse)
		{
			if (string.IsNullOrEmpty(toUse))
			{
				toUse = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID).ISOCurrencySymbol;
			}
			switch (toUse)
			{
				case "USD":
					return new USDCurrency();
				case "CAD":
					return new CADCurrency();
				case "EUR":
					return new EURCurrency();

				default:
					break;
			}
			Console.WriteLine(string.Format("{0}: is unsupported currency ISOCode", toUse));
			return null;
		}
	}
}
