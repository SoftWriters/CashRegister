namespace CashRegisterConsumer
{
    public interface IChangeCalculator
    {
        string Calculate(ICurrency _price, ICurrency _tender);
    }
}