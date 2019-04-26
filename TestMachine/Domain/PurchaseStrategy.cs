using CashMachine.ChangeStrategies;

namespace CashMachine.Domain
{
    public interface IPurchaseStrategy
    {
        Change MakePurchase(Purchase purchase);
    }

    public class PurchaseStrategy : IPurchaseStrategy
    {
        public PurchaseStrategy(IMinimalChangeStrategy minChangeStrategy,
                                IRandomChangeStrategy randomChangeStrategy)
        {
            _minChangeStrategy = minChangeStrategy;
            _randomChangeStrategy = randomChangeStrategy;
        }

        public Change MakePurchase(Purchase purchase)
        {
            // Randomize the change if divisible by 3. Yeah, it's weird, but I like it!
            // Note: % doesn't work on fractions, so shift the money to an integer for the test.
            if (purchase.ItemCost*100 % 3 == 0)
            {
                return _randomChangeStrategy.MakeChange(purchase.Payment - purchase.ItemCost);
            }

            return _minChangeStrategy.MakeChange(purchase.Payment - purchase.ItemCost);
        }

        private readonly IMinimalChangeStrategy _minChangeStrategy;
        private readonly IRandomChangeStrategy _randomChangeStrategy;
    }
}
