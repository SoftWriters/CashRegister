using System;
using System.Text.RegularExpressions;
using CashRegister.Internal.Financial;
using CashRegister.Internal.Financial.RegionCurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CashRegister.Internal.Calculation.Tests
{
	[TestClass()]
	public class TransactionTests
	{
		[TestMethod()]
		public void Test_Input_Line_Contains_Too_Many_Items()
		{
			Transaction t = new Transaction("1.23,4.56,7.89");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.TooManyInputs.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Contains_Too_Few_Items()
		{
			Transaction t = new Transaction("1.23");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.TooFewInputs.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Is_Empty()
		{
			Transaction t = new Transaction("");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.TooFewInputs.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Is_Null()
		{
			Transaction t = new Transaction(null);
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.EmptyInput.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Is_NaN()
		{
			Transaction t = new Transaction("NaN,NaN");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.NonNumeric.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Is_NonNumeric()
		{
			Transaction t = new Transaction("a,b");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.NonNumeric.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Contains_Negative_Cost()
		{
			Transaction t = new Transaction("-1.0,1");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.CostNegative.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Contains_Negative_Tendered()
		{
			Transaction t = new Transaction("1.11,-1.11");
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.TenderedNegative.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Tendered_Value_Is_Lower_Than_Cost()
		{
			Transaction t = new Transaction("5,2");
			t.GenerateChange(null, null, true);
			Assert.AreEqual(true, t.Change.Contains(DataViolations.InsufficentTendered.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Upper_Bounds()
		{
			decimal d = decimal.MaxValue;
			Transaction t = new Transaction(string.Format("100,{0}", d));
			Random r = new Random(1);
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.ExeceededcalculableLimits.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Upper_Bound_Less_One()
		{
			int i = (int.MaxValue) - 1;
			Transaction t = new Transaction(string.Format("100,{0}", i));
			Random r = new Random(1);
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, true);
			decimal calculatedChange = 0m;
			foreach (string s in t.Change)
			{
				foreach (Currency c in test.Denominations)
				{
					if (s.Contains(c.Name) || s.Contains(c.PluralName))
					{
						string[] numbers = Regex.Split(s, @"\D+");
						if (!string.IsNullOrEmpty(numbers[0]))
						{
							calculatedChange += (decimal)(c.Value * int.Parse(numbers[0]));
						}
					}
				}
			}
			Assert.AreEqual(2147483546m, calculatedChange);
		}

		[TestMethod()]
		public void Test_Input_Line_Beyond_Upper_Bounds()
		{
			double d = double.MaxValue;
			Transaction t = new Transaction(string.Format("10,{0}", d));
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.NonNumeric.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Lower_Bounds()
		{
			decimal d = decimal.MinValue;
			Transaction t = new Transaction(string.Format("{0},10", d));
			t.GenerateChange(null, null, true);
			Assert.IsTrue(t.Change.Contains(DataViolations.CostNegative.Value));
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input()
		{
			Transaction t = new Transaction("3,5");
			Assert.AreEqual(0, t.Change.Count);
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Result_USD()
		{
			Transaction t = new Transaction("13.59,200");
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, null, true);
			string expected = "1 hundred, 1 fifty, 1 twenty, 1 ten, 1 five, 1 one, 1 quarter, 1 dime, 1 nickel, 1 penny";
			Assert.AreEqual(expected, t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Result_EUR()
		{
			Transaction t = new Transaction("61.12,900");
			IRegionCurrency test = new EURCurrency();
			t.GenerateChange(test, null, true);
			string expected = "1 five hundred, 1 two hundred, 1 hundred, 1 twenty, 1 ten, 1 five, 1 two, 1 one, 1 50c, 1 20c, 1 10c, 1 5c, 1 2c, 1 1c";
			Assert.AreEqual(expected, t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Result_CAD()
		{
			Transaction t = new Transaction("11.09,200");
			IRegionCurrency test = new CADCurrency();
			t.GenerateChange(test, null, true);
			string expected = "1 hundred, 1 fifty, 1 twenty, 1 ten, 1 five, 1 toonie, 1 loonie, 1 half dollar, 1 quarter, 1 dime, 1 nickel, 1 penny";
			Assert.AreEqual(expected, t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Random_Change_Result()
		{
			Random r = new Random(99);
			Transaction t = new Transaction("5.01, 20");
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, false);
			string seed99 = t.ToString();
			r = new Random(1);//reset random seed
			t.GenerateChange(test, r, false);
			Assert.AreNotEqual(seed99, t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Random_Full_Result()
		{
			Random r = new Random(99);
			Transaction t = new Transaction("5.01, 20");
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, true);
			string seed99 = t.ToString();
			r = new Random(1);//reset random seed
			t.GenerateChange(test, r, false);
			Assert.AreNotEqual(seed99, t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Random_Comparisons()
		{
			Random r = new Random(1);
			Random r2 = new Random(2000);
			Transaction t = new Transaction("5.97, 100");
			Transaction t2 = new Transaction("5.97, 100");
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, true);
			t2.GenerateChange(test, r2, true);
			Assert.AreNotEqual(t2.ToString(), t.ToString());
		}

		[TestMethod()]
		public void Test_Input_Line_Valid_Input_Random_Change_Correctness()
		{
			Random r = new Random();
			Transaction t = new Transaction("5.97, 10");
			IRegionCurrency test = new USDCurrency();
			t.GenerateChange(test, r, true);
			decimal calculatedChange = 0m;
			foreach (string s in t.Change)
			{
				foreach (Currency c in test.Denominations)
				{
					if (s.Contains(c.Name) || s.Contains(c.PluralName))
					{
						string[] numbers = Regex.Split(s, @"\D+");
						if (!string.IsNullOrEmpty(numbers[0]))
						{
							calculatedChange += (decimal)(c.Value * int.Parse(numbers[0]));
						}
					}
				}
			}
			Assert.AreEqual(4.03m, calculatedChange);
		}
	}
}