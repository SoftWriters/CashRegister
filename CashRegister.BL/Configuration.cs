using System;
using System.Collections.Generic;
namespace CashRegister.BL
{
	public static class Configuration
	{

		public static Dictionary<int, string> CoinTypes = new Dictionary<int, string>{
			{1, "penny:pennies"},
			{5, "nickel:nickels"},
			{10, "dime:dimes"},
			{25, "quarter:quarters"},
			{100, "dollar:dollars"}
		};
	}
}
