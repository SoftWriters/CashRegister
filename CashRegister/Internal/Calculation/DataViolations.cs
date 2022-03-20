namespace CashRegister.Internal.Calculation
{
	/// <summary>
	/// Possible data violations
	/// used to manage error output
	/// Assumption that these transactions are all purchases
	/// no returns/credits are handled
	/// </summary>
	internal class DataViolations
	{
		public string Value { get; set; }

		private DataViolations(string value)
		{
			Value = value;
		}

		public static DataViolations TooFewInputs => new DataViolations("Input contains too few items.");
		public static DataViolations TooManyInputs => new DataViolations("Input contains too many items.");
		public static DataViolations EmptyInput => new DataViolations("Input cannot be null.");
		public static DataViolations NonNumeric => new DataViolations("Input cannot contain non numeric items.");
		public static DataViolations InsufficentTendered => new DataViolations("Amount tendered is less than cost.");
		public static DataViolations CostNegative => new DataViolations("Cost of transaction cannot be negative.");
		public static DataViolations TenderedNegative => new DataViolations("Amount tendered cannot be negative.");

		public static DataViolations ExeceededcalculableLimits => new DataViolations("The transaction exceeds the calculation limits of the system.");
	}
}