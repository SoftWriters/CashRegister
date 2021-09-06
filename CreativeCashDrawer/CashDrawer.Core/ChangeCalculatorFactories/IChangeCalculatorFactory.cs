using CashDrawer.Core.ChangeCalculators;

namespace CashDrawer.Core.ChangeCalculatorFactories
{
    public interface IChangeCalculatorFactory
    {
        IChangeCalculator GetChangeCalculator(decimal due);
    }
}