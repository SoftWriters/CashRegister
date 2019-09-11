namespace DataAccess.FakeData.Currency
{
    public class Penny : CurrencyRow
    {
        public override decimal Value { get { return .01M; } }
        public override string SingularDescription { get { return "Penny"; } }
        public override string PluralDescription { get { return "Pennies"; } }
    }
}