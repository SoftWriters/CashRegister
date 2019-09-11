namespace DataAccess.FakeData.Currency
{
    public class Dollar : CurrencyRow
    {
        public override decimal Value { get { return 1M; } }
        public override string SingularDescription { get { return "Dollar"; } }
        public override string PluralDescription { get { return "Dollars"; } }
    }
}