using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
    public static class Logic
    {
		public static void LoadData(string filename)
		{
			Data.purchases = DataAccess.LoadData(filename);
		}

		public static void ProcessData()
		{
			if (Data.purchases != null)
			{
				foreach (Purchase curPurchase in Data.purchases)
				{
					if ((int)(curPurchase.owedAmount * 100) % 3 == 0)
						GenerateRandomChange(curPurchase);
					else
						GenerateMinimalChange(curPurchase);
				}
			}
		}

		public static void GenerateMinimalChange(Purchase curPurchase)
		{
			DataAccess.DetermineMinimalChangeDenominations(curPurchase);
		}

		public static void GenerateRandomChange(Purchase curPurchase)
		{
			DataAccess.DetermineRandomChangeDenominations(curPurchase);
		}

		public static string SaveData(string filename)
		{
			return DataAccess.SaveData(filename, Data.purchases);
		}
	}
}
