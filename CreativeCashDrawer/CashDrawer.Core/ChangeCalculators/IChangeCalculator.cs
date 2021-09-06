namespace CashDrawer.Core.ChangeCalculators
{
    public interface IChangeCalculator
    {
        Change GetChange(decimal due, decimal paid);
    }
}
