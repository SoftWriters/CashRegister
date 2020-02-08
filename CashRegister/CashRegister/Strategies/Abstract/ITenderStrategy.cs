namespace CashRegisterConsumer
{
    public interface ITenderStrategy
    {
        string Calculate(ICurrency currency, decimal price, decimal tender);
    }
}