using System;

namespace DataAccess.FakeData.Currency
{
    public class Dime : CurrencyRow
    {
        public override decimal Value { get { return .1M; } }
        public override string SingularDescription { get { return "Dime"; } }
        public override string PluralDescription { get { return "Dimes"; } }
    }
}