using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.BL.Objects;
namespace CashRegister.BL.Services
{
	public class ChangeGenerator : IChangeGenerator
	{
		Dictionary<int, Denomination> _dict = new Dictionary<int, Denomination>();
        public ChangeGenerator() {}
		public Denomination ComputeChange(int totalCents, Func<IList<Denomination>, Denomination> reducer) 
		{
			if(totalCents < 0)
				throw new ArgumentOutOfRangeException("totalCents");
			if (_dict.ContainsKey(totalCents))
				return _dict[totalCents];
			else if (totalCents > 0)
			{
				var temp = new List<Denomination>();
				foreach (var c in Configuration.CoinTypes.Keys)
				{
					if (totalCents >= c)
					{
						var results = ComputeChange(totalCents - c, reducer);
						var coinKey = results.TotalCoins + 1;
						var coinList = new List<int>(results.Coins) { c };

						var r = new Denomination(coinKey, coinList.ToArray());
						temp.Add(r);
					}

				}
				//_dict.Add(totalCents, temp.MinBy(x => x.TotalCoins));
				_dict.Add(totalCents, reducer(temp));
				return _dict[totalCents];
			}
			else
			{
				return new Denomination(0, new int[] { });
			}
        }
	}
}
