using System;
using System.Collections.Generic;
using CashRegister.Internal.Financial;

namespace CashRegister.Internal.Calculation
{
	/// <summary>
	/// Transaction Class
	/// </summary>
	public class Transaction
	{
		private decimal cost;
		private decimal tendered;
		private DataViolations violation;
		private string RawInput { get; }
		public List<string> Change { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Transaction"/> class.
		/// </summary>
		/// <param name="input">The input.</param>
		public Transaction(string input)
		{
			RawInput = input;
			Change = new List<string>();
			ValidateInput();
		}

		/// <summary>
		/// Validates the input.
		/// </summary>
		private void ValidateInput()
		{
			if (RawInput == null) //checking for null
			{
				violation = DataViolations.EmptyInput;
			}
			else
			{
				string[] split = RawInput.Split(',');

				if (split.Length != 2) //checking for input count violations
				{
					violation = split.Length < 2 ? DataViolations.TooFewInputs : DataViolations.TooManyInputs;
				}
				else if (!decimal.TryParse(split[0], out cost) || !decimal.TryParse(split[1], out tendered)) //checking for non numbers
				{
					violation = DataViolations.NonNumeric;
				}
				else if (cost < 0) //checking for negative cost input
				{
					violation = DataViolations.CostNegative;
				}
				else if (tendered < 0) //checking for negative tendered input
				{
					violation = DataViolations.TenderedNegative;
				}
				else if (cost > tendered) //checking for insufficient tendered funds
				{
					violation = DataViolations.InsufficentTendered;
				}
				else if(cost > (int.MaxValue) || tendered > (int.MaxValue))
				{
					violation = DataViolations.ExeceededcalculableLimits;
				}
				else
				{
					violation = null; //all clear
				}
			}
		}

		/// <summary>
		/// Generates the output of change due or various errors
		/// If no violations have been tripped - figure out currency denominations for return
		/// If change due is divisible by 3 Mod3ChangeGeneration will be called.
		/// Otherwise change is given as optimally as possible.
		/// </summary>
		/// <param name="regionCurrency">The region currency.</param>
		/// <param name="r">random seed</param>
		/// <param name="randomizeAllChange">if set to <c>true</c> [randomize all change]. otherwise randomizes decimal value only</param>
		internal void GenerateChange(IRegionCurrency regionCurrency, Random r, bool randomizeAllChange)
		{
			if (violation == null)
			{
				Change.Clear();
				decimal changeValue = Math.Round(tendered - cost, 2, MidpointRounding.AwayFromZero);
				string[] stringSplit = changeValue.ToString().Split('.');
				int x = stringSplit.Length > 1 ? int.Parse(stringSplit[1]) : 0;
				if (x % 3 == 0)
				{
					//wasn't sure if all money due back should be subject to random behavior 
					//or just the decimal value - I implemented both;
					if (randomizeAllChange)
					{
						Change = Mod3ChangeGeneration(changeValue, regionCurrency, r);
					}
					else//randomizes decimal value only.
					{
						Change = OptimizedChangeReturned(decimal.Parse(stringSplit[0]), regionCurrency);
						Change.AddRange(Mod3ChangeGeneration(decimal.Parse(string.Format("0.{0}", x)), regionCurrency, r));
					}
				}
				else
				{
					Change = OptimizedChangeReturned(changeValue, regionCurrency);
				}
			}
			else
			{
				Change.Add(string.Format("Error with input ({0}):", RawInput));
				Change.Add(violation.Value);
			}
		}

		/// <summary>
		/// Optimizes the change returned.
		/// Gives the most efficient change back possible.
		/// </summary>
		/// <param name="changeValue">The change value.</param>
		/// <param name="regionCurrency">The region currency.</param>
		/// <returns></returns>
		private List<string> OptimizedChangeReturned(decimal changeValue, IRegionCurrency regionCurrency)
		{
			List<string> toReturn = new List<string>();
			foreach (var c in regionCurrency.GetDescendingOrderedCurrencies())
			{
				if (c.Value <= changeValue)
				{
					int times = (int)(changeValue / c.Value);
					toReturn.Add(string.Format("{0} {1}", times, times > 1 ? c.PluralName : c.Name));
					changeValue -= (times * c.Value);
				}
			}
			return toReturn;
		}

		/// <summary>
		/// If the change due is divisible by 3, give random denominations
		/// these random denominations must equal the appropriate total amount
		/// of change due
		/// </summary>
		/// <param name="changeValue">The change value.</param>
		/// <param name="regionCurrency">The region currency.</param>
		/// <param name="r">The random seed</param>
		/// <returns></returns>
		private List<string> Mod3ChangeGeneration(decimal changeValue, IRegionCurrency regionCurrency, Random r)
		{
			Dictionary<Currency, int> changeDue = new Dictionary<Currency, int>();
			List<string> toReturn = new List<string>();
			foreach (Currency c in regionCurrency.Denominations)
			{
				changeDue.Add(c, 0);
			}
			while (changeValue > 0)
			{
				Currency tmp = regionCurrency.Denominations[r.Next(regionCurrency.Denominations.Count)];

				if (changeValue >= tmp.Value)
				{
					try
					{
						int maxNumberOfTimes = (int)(changeValue / tmp.Value) + 1; //adding 1 because random max is exclusive
						int actualTimes = r.Next(maxNumberOfTimes);
						changeDue[tmp] += actualTimes;
						changeValue -= (actualTimes * tmp.Value);
					}
					catch (OverflowException)
					{
						//eat the overflow exception and try again
						//this happens when the initial change amount due is at or near the limit for Int32
						//and we try to generate change using something less than 1 ex: a nickel.
						//allow the system to try larger denominations to reduce the total change due being tracked
					}
					
				}
			}
			//populate the change denominations to return
			foreach (Currency c in regionCurrency.GetDescendingOrderedCurrencies())
			{
				if (changeDue[c] > 0)
				{
					toReturn.Add(string.Format("{0} {1}", changeDue[c], changeDue[c] > 1 ? c.PluralName : c.Name));
				}
			}
			return toReturn;
		}

		/// <summary>
		/// Overrides ToString()
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Join(", ", Change);
		}
	}
}