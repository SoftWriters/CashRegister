using System;
using System.Collections.Generic;
using System.Linq;
namespace CashRegister
{
	class Program
	{
		static int[] coins = new[] { 1, 5, 10, 25, 50, 100 };
		static Dictionary<int, KeyValuePair<int, int[]>> d = new Dictionary<int, KeyValuePair<int, int[]>>();

		static void Main(string[] args)
		{

			var val = MakeChange(103);
			Console.WriteLine("requires {0} coins: {1}", val.Key, string.Join(",", val.Value.OrderBy(x => x).ToArray()));
			Console.ReadLine();
		}

		static KeyValuePair<int, int[]> MakeChange(int cents)
		{

			if (d.ContainsKey(cents))
				return d[cents];
			else if (cents > 0)
			{
				var temp = new List<KeyValuePair<int, int[]>>();// new Dictionary<int, KeyValuePair<int, List<int>>>();
				foreach (var c in coins)
				{
					if (cents >= c)
					{
						var results = MakeChange(cents - c);
						var coinKey = results.Key + 1;
						var coinList = new List<int>(results.Value) { c };

						var r = new KeyValuePair<int, int[]>(coinKey, coinList.ToArray());
						temp.Add(r);
						//if (!temp.ContainsKey(coinKey))
						//    temp.Add(coinKey, r);
					}

				}
				d.Add(cents, temp.OrderBy(x => x.Key).FirstOrDefault());
				return d[cents];
			}
			else
			{
				return new KeyValuePair<int, int[]>(0, new int[] { });
			}
		}
	}
}
