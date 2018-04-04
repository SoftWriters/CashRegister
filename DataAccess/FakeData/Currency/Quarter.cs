namespace DataAccess.FakeData.Currency
{
    public class Quarter : CurrencyRow
    {
        public override decimal Value { get { return .25M; } }
        public override string SingularDescription { get { return "Quarter"; } }
        public override string PluralDescription { get { return "Quarters"; } }
    }
}