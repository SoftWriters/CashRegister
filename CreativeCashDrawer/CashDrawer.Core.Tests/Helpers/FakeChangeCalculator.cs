using CashDrawer.Core.ChangeCalculators;

namespace CashDrawer.Core.Tests.Helpers
{
    public class FakeChangeCalculator : IChangeCalculator
    {
        public Change ReturnedChange;


        public Change GetChange(decimal due, decimal paid)
        {
            return ReturnedChange;
        }
    }
}
