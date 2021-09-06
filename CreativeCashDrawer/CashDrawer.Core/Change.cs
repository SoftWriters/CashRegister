namespace CashDrawer.Core
{
    public class Change
    {
        public readonly int Dollars;
        public readonly int Quarters;
        public readonly int Dimes;
        public readonly int Nickles;
        public readonly int Pennies;

        public Change(int dollars, int quarters, int dimes, int nickles, int pennies)
        {
            Dollars = dollars;
            Quarters = quarters;
            Dimes = dimes;
            Nickles = nickles;
            Pennies = pennies;
        }
    }
}
