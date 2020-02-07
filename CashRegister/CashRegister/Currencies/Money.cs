namespace CashRegisterConsumer
{
    public abstract class Money
    {
        private int _value;
        private string _name;

        public Money(int value, string name)
        {
            this._value = value;
            this._name = name;
        }
    }
}