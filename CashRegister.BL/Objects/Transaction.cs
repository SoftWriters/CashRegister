using System;
namespace CashRegister.BL.Objects
{
	public class Transaction
	{
		public decimal AmountOwed { get; set; }
		public decimal AmountPaid { get; set; }
		public decimal AmountChange {get {
				return AmountPaid - AmountOwed;
			}}
	}
}
