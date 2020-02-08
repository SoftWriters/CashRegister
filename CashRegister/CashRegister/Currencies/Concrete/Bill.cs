namespace CashRegisterConsumer
{
    public class Bill : Money
    {
        public Bill(decimal denomination, string singleName, string pluralName) : base(denomination, singleName, pluralName) { }
        public Bill(decimal denomination, string singleName, string pluralName, int count) : base(denomination, singleName, pluralName, count) { }
    }
}