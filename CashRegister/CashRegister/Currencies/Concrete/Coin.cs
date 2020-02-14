namespace CashRegisterConsumer
{
    public class Coin : Money
    {
        public Coin(decimal denomination, string singleName, string pluralName) : base(denomination, singleName, pluralName) { }
        public Coin(decimal denomination, string singleName, string pluralName, int count) : base(denomination, singleName, pluralName, count) { }

    }
}