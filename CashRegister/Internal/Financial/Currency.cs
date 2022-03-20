namespace CashRegister.Internal.Financial
{
	internal class Currency
	{
		public string Name { get; }
		public string PluralName { get; }
		public decimal Value { get; }

		public Currency(string name, string plural, decimal value)
		{
			Name = name;
			PluralName = plural;
			Value = value;
		}
	}
}