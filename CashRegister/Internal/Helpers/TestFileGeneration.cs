using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Internal.Helpers
{
	/// <summary>
	/// Helper I used to generate 
	/// </summary>
	static class TestFileGeneration
	{
		public static bool GenerateTestFile(string fileName, int lines)
		{
			string[] badValues = { "", "x,y", "null", "1.23 4.56", "7.89", "NaN,NaN", "null", null, string.Format("5.11, {0}", double.MaxValue)};
			Random r = new Random();
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				for (int i = 0; i < lines; i++)
				{
					if (r.Next(0, 100) % 5 == 0)
					{
						writer.WriteLine(badValues[r.Next(0, badValues.Length - 1)]);
					}
					else
					{
						writer.WriteLine(string.Format("{0:0.00},{1:0.00}", Math.Round(r.Next(0, 10) + r.NextDouble(), 2, MidpointRounding.AwayFromZero), Math.Round(r.Next(10, 20) + r.NextDouble(), 2, MidpointRounding.AwayFromZero)));
					}
				}
			}
			return File.Exists(fileName);
		}
	}
}
