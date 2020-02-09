namespace CashRegisterConsumer
{
    public interface ITenderStrategy
    {
        ICurrency Calculate(ICurrency currency, decimal price, decimal tender);

        string Display(ICurrency currency);
    }
}