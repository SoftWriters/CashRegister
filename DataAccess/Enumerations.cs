using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataLayer
{
	public enum Denominations : int
	{
		[Description("Twenty Dollar Bill")]
		TwentyDollars = 2000,
		[Description("Ten Dollar Bill")]
		TenDollars = 1000,
		[Description("Five Dollar Bill")]
		FiveDollars = 500,
		[Description("One Dollar Bill")]
		OneDollar = 100,
		[Description("Quarter")]
		Quarter = 25,
		[Description("Dime")]
		Dime = 10,
		[Description("Nickel")]
		Nickel = 5,
		[Description("Penny")]
		Penny = 1
	}
}
