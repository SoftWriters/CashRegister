using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class DataAccess
    {
		public static List<Purchase> LoadData(string filename)
		{
			List<Purchase> retValue = null;

			using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					Purchase curPurchase = new Purchase();
					string[] data = line.Split(',');
					curPurchase.owedAmount = Convert.ToInt32(100 * float.Parse(data[0]));
					curPurchase.paidAmount = Convert.ToInt32(100 * float.Parse(data[1]));

					if (retValue == null)
						retValue = new List<Purchase>();
					retValue.Add(curPurchase);
				}
			}

			return retValue;
		}

		public static void DetermineMinimalChangeDenominations(Purchase curPurchase)
		{
			curPurchase.ResetChangeDenominations();

			List<Denominations> validDenominations = Enum.GetValues(typeof(Denominations)).Cast<Denominations>().OrderByDescending(x => (int)x).ToList();

			while (curPurchase.Change != curPurchase.CalculateChangeValue())
			{
				while ((int)validDenominations.First() > (curPurchase.Change - curPurchase.CalculateChangeValue()))
				{
					validDenominations.Remove(validDenominations.First());
				}

				curPurchase.AddToChangeDenominations(validDenominations.First());
			}
		}

		public static void DetermineRandomChangeDenominations(Purchase curPurchase)
		{
			curPurchase.ResetChangeDenominations();

			List<Denominations> validDenominations = Enum.GetValues(typeof(Denominations)).Cast<Denominations>().OrderByDescending(x => (int)x).ToList();

			while (curPurchase.Change != curPurchase.CalculateChangeValue())
			{
				while ((int)validDenominations.First() > (curPurchase.Change - curPurchase.CalculateChangeValue()))
				{
					validDenominations.Remove(validDenominations.First());
				}

				Random r = new Random();
				curPurchase.AddToChangeDenominations(validDenominations[r.Next(0, validDenominations.Count)]);
			}
		}

		public static string SaveData(string filename, List<Purchase> purchases)
		{
			StringBuilder sb = new StringBuilder();

			if (purchases != null)
			{
				using (StreamWriter sw = new StreamWriter(File.Create(filename)))
				{
					foreach (Purchase curPurchase in purchases)
					{
						string changeString = curPurchase.changeDenominationsString;
						sw.WriteLine(changeString);
						sb.AppendLine(changeString);
					}
				}
			}

			return sb.ToString();
		}
	}
}
