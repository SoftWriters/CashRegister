using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CashRegister.Internal.Financial;

namespace CashRegister.Internal.Calculation
{
	/// <summary>
	/// Houses the main function for reading, processing and writing output
	/// </summary>
	internal static class TransactionProcessor
	{
		/// <summary>
		/// Processes the transactions.
		/// </summary>
		/// <param name="inputFile">The input file.</param>
		/// <param name="outputFile">The output file.</param>
		/// <param name="dataDumpThreshold">The data dump threshold.</param>
		/// <param name="randomizeAllChange">if set to <c>true</c> [randomize all change].</param>
		/// <param name="regionCurrency">The region currency.</param>
		/// <returns></returns>
		public static bool ProcessTransactions(string inputFile, string outputFile, int dataDumpThreshold, bool randomizeAllChange, IRegionCurrency regionCurrency)
		{
			if (regionCurrency == null)
			{
				return false;
			}
			//book-keeping
			int start = 0;
			int dataDumpOffset = 0;
			//number of lines to read at once
			int take = 50000; 
			Mutex _m = new Mutex();
			Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
			while (true)
			{
				string[] v = null;
				try
				{
					v = File.ReadLines(inputFile).Skip(start).Take(take).ToArray();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
				//using Parallel.ForEach for increased performance when calculating change
				Parallel.ForEach(v, (s, x, i) =>
				{
					Transaction tmp = new Transaction(s);
					tmp.GenerateChange(regionCurrency, new Random(Guid.NewGuid().GetHashCode()), randomizeAllChange);
					int index = (int)i + start;
					_m.WaitOne();
					transactions.Add(index, tmp);
					_m.ReleaseMutex();
				});
				//section to write transaction data to disk - preventing out of memory issues
				if (transactions.Count % dataDumpThreshold == 0)
				{
					try
					{
						using (StreamWriter writer = new StreamWriter(outputFile, append: true))
						{
							int offset = dataDumpThreshold * dataDumpOffset;
							for (int i = 0; i < transactions.Count; i++)
							{
								writer.WriteLine(transactions[i + offset].ToString());
							}
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						return false;
					}
					transactions.Clear();
					dataDumpOffset++;
				}
				start += take;
				if (v.Length < take)
				{
					break;
				}
			}
			if (transactions.Count > 0)//write the remaining transactions
			{
				try
				{
					using (StreamWriter writer = new StreamWriter(outputFile, append: true))
					{
						int offset = dataDumpThreshold * dataDumpOffset;
						for (int i = 0; i < transactions.Count; i++)
						{
							writer.WriteLine(transactions[i + offset].ToString());
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
			return true;
		}
			
	}
}
