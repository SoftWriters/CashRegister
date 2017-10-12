using System;
using System.Collections.Generic;
namespace CashRegister.BL
{
	public static class Configuration
	{

		public static Dictionary<int, string> CoinTypes = new Dictionary<int, string>{
			{1, "Penny"},
			{5, "Nickel"},
			{10, "Dime"},
			{25, "Quarter"},
			{100, "Dollar"}
		};
	}
}
