using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace CashRegister.BL.Objects
{
	public class Denomination
	{
		public Denomination(int totalCoints, int[] coinList) 
		{
			TotalCoins = totalCoints;
			Coins = coinList;
		}
		public int TotalCoins { get; private set; }
		public int[] Coins { get; private set; }


		public override string ToString() 
		{
			var coinTypes = Configuration.CoinTypes;

			var coinGroups = Coins.GroupBy(x => x).Select(x => new {Coin = x.Key, Total = x.Count()})
				.OrderByDescending(x => x.Coin);
			var builder = new List<string>();	
			foreach(var coin in coinGroups) {
				builder.Add(string.Concat(coin.Total, " ",  coin.Total.CardinalityLabel(coinTypes[coin.Coin])));		
			}
			//3 quarters,1 dime,3 pennies
			return string.Join(", ", builder.ToArray());
		}

	}
}
