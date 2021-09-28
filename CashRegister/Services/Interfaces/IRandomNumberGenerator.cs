namespace CashRegister.Services.Interfaces
{
    public interface IRandomNumberGenerator
    {
         int GenerateRandomInt(int minValue, int maxValue);
    }
}