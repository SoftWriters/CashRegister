using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
	public class Purchase
	{
		// Variables
		public int owedAmount;
		public int paidAmount;
		public Dictionary<Denominations, int> changeDenominations;

		// Properties
		public int Change
		{
			get
			{
				return paidAmount - owedAmount;
			}
		}

		// Methods
		public int CalculateChangeValue()
		{
			int value = 0;
			if (changeDenominations != null)
			{
				foreach (KeyValuePair<Denominations, int> kvp in changeDenominations)
				{
					value += (kvp.Value * (int)kvp.Key);
				}
			}

			return value;
		}

		public void AddToChangeDenominations(Denominations curDenomination)
		{
			if (!changeDenominations.ContainsKey(curDenomination))
				changeDenominations.Add(curDenomination, 1);
			else
				++changeDenominations[curDenomination];
		}

		internal void ResetChangeDenominations()
		{
			changeDenominations = new Dictionary<Denominations, int>();
		}

		public string changeDenominationsString
		{
			get
			{
				StringBuilder sb = null;

				foreach (KeyValuePair<Denominations, int> kvp in changeDenominations.OrderByDescending(x => (int)x.Key))
				{
					if (sb == null)
						sb = new StringBuilder();
					else
						sb.Append(", ");

					sb.Append(kvp.Value);
					sb.Append(" ");
					StringBuilder coin = new StringBuilder(kvp.Key.Description());
					if (kvp.Value > 1)
					{
						if (coin[coin.Length-1].Equals('y'))
						{
							coin.Remove(coin.Length - 1, 1).Append("ies");
						}
						else
						{
							coin.Append("s");
						}
					}
					sb.Append(coin.ToString());
				}

				return sb.ToString();
			}
		}
	}
}
