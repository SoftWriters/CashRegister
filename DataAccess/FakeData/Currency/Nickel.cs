namespace DataAccess.FakeData.Currency
{
    public class Nickel : CurrencyRow
    {
        public override decimal Value { get { return .05M; } }
        public override string SingularDescription { get { return "Nickel"; } }
        public override string PluralDescription { get { return "Nickels"; } }
    }
}