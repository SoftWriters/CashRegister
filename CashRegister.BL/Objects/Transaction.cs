using System;
namespace CashRegister.BL.Objects
{
	public class Transaction
	{
		public Transaction(decimal amountOwed, decimal amountPaid) 
		{
			AmountOwed = amountOwed;
			AmountPaid = amountPaid;
		}
		public decimal AmountOwed { get; set; }
		public decimal AmountPaid { get; set; }
		public int AmountChangeCents {
			get 
			{
				return Convert.ToInt32((AmountPaid - AmountOwed) * 100);
			}
		}
	}
}
