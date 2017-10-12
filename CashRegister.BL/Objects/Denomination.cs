using System;
using System.Collections.Generic;
namespace CashRegister.BL.Objects
{
	public class Denomination
	{
		public int TotalCoins { get; set; }
		public List<int> Coins { get; set; }
	}
}
