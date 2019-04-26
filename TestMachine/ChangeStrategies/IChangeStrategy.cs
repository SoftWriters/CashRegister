using CashMachine.Domain;

namespace CashMachine.ChangeStrategies
{
    public interface IChangeStrategy
    {
        Change MakeChange(decimal value);
    }
}
