using System;

namespace ChangeCalculator
{
    public class RandomChangeCalculator : ICalculateChange
    {
        private enum Denomination { Penny = 1, Dime, Nickle, Quarter, Dollar };

        public Change CalculateChange(Amount input)
        {
            Change result = new Change();
            int currentAmountInPennies = input.OwedAmountInPennies;

            while (currentAmountInPennies < input.PaidAmountInPennies)
            {
                Denomination nextCoin = GetOneCoin(currentAmountInPennies, input.PaidAmountInPennies);
                if (nextCoin == Denomination.Dollar)
                {
                    result.Dollars++;
                    currentAmountInPennies += Constants.PenniesInDollar;
                }
                else if (nextCoin == Denomination.Quarter)
                {
                    result.Quarters++;
                    currentAmountInPennies += Constants.PenniesInQuarter;
                }
                else if (nextCoin == Denomination.Nickle)
                {
                    result.Nickels++;
                    currentAmountInPennies += Constants.PenniesInNickle;
                }
                else if (nextCoin == Denomination.Dime)
                {
                    result.Dimes++;
                    currentAmountInPennies += Constants.PenniesInDime;
                }
                else if (nextCoin == Denomination.Penny)
                {
                    result.Pennies++;
                    currentAmountInPennies += 1;
                }
            }

            return result;
        }

        private Denomination GetOneCoin(int currentAmountInPennies, int paidAmountInPennies)
        {
            Denomination denomination = Denomination.Penny;
            Random r = new Random(Guid.NewGuid().GetHashCode());

            if (paidAmountInPennies - currentAmountInPennies >= Constants.PenniesInDollar)
            {
                denomination = (Denomination)r.Next(1, (int)Denomination.Dollar + 1);
            }
            else if (paidAmountInPennies - currentAmountInPennies >= Constants.PenniesInQuarter)
            {
                denomination = (Denomination)r.Next(1, (int)Denomination.Quarter + 1);
            }
            else if (paidAmountInPennies - currentAmountInPennies >= Constants.PenniesInNickle)
            {
                denomination = (Denomination)r.Next(1, (int)Denomination.Nickle + 1);
            }
            else if (paidAmountInPennies - currentAmountInPennies >= Constants.PenniesInDime)
            {
                denomination = (Denomination)r.Next(1, (int)Denomination.Dime + 1);
            }

            return denomination;
        }
    }
}
