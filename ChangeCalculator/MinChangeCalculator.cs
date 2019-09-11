namespace ChangeCalculator
{
    public class MinChangeCalculator : ICalculateChange
    {
        public Change CalculateChange(Amount input)
        {
            Change result = new Change();
            int currentAmountInPennies = input.OwedAmountInPennies;

            result.Dollars = (input.PaidAmountInPennies - currentAmountInPennies) / Constants.PenniesInDollar;
            currentAmountInPennies += result.Dollars * Constants.PenniesInDollar;
            result.Quarters = (input.PaidAmountInPennies - currentAmountInPennies) / Constants.PenniesInQuarter;
            currentAmountInPennies += result.Quarters * Constants.PenniesInQuarter;
            result.Nickels = (input.PaidAmountInPennies - currentAmountInPennies) / Constants.PenniesInNickle;
            currentAmountInPennies += result.Nickels * Constants.PenniesInNickle;
            result.Dimes = (input.PaidAmountInPennies - currentAmountInPennies) / Constants.PenniesInDime;
            currentAmountInPennies += result.Dimes * Constants.PenniesInDime;
            result.Pennies = input.PaidAmountInPennies - currentAmountInPennies;

            return result;
        }
    }
}
