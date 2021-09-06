namespace CashDrawer.Core.ChangeCalculators
{
    public class StandardChangeCalculator : IChangeCalculator
    {
        public Change GetChange(decimal due, decimal paid)
        {
            var duePennies = (int) ((paid - due) * 100);

            var dollars = duePennies / 100;
            duePennies -= dollars * 100;

            var quarters = duePennies / 25;
            duePennies -= quarters * 25;

            var dimes = duePennies / 10;
            duePennies -= dimes * 10;

            var nickles = duePennies / 5;
            duePennies -= nickles * 5;

            var pennies = duePennies;

            return new Change(dollars, quarters, dimes, nickles, pennies);
        }
    }
}
