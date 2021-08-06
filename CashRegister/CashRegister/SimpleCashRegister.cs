using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public interface ICashRegister
    {
        void CalculateChange(List<CashTransaction> cashTransactions);
    }

    // Simple cash register class that only operates with physical cash,
    // dealing with CashTransactions only. It calculates the number of
    // coins and bills needed for a list of cash transactions.
    public class SimpleCashRegister : ICashRegister
    {
        private Random Random = new Random();

        public void CalculateChange(List<CashTransaction> cashTransactions)
        {
            foreach (CashTransaction cashTransaction in cashTransactions)
            {
                int amountOwed = cashTransaction.AmountOwed;
                if (IsDivsibleByThree(amountOwed))
                {
                    cashTransaction.SetChangeDenominationCount(
                        CalculateRandomAmountsOfChange(cashTransaction)
                        );
                }
                else
                {
                    cashTransaction.SetChangeDenominationCount(
                           CalculateMinimumAmountsOfChange(cashTransaction)
                           );
                }
            }
        }

        // Minimum and random calculations are in separate functions for readability and
        // testing.
        public Dictionary<CashDenominations,int> CalculateMinimumAmountsOfChange(CashTransaction cashTransaction)
        {
            Dictionary<CashDenominations, int> result = new Dictionary<CashDenominations, int>();
            int remainderOfChange = cashTransaction.ChangeTotal;
            CashDenominations[] cashDenominationsSortedFromGreatestToLeast =
                Enum.GetValues(typeof(CashDenominations))
                .Cast<CashDenominations>()
                .Reverse<CashDenominations>()
                .ToArray<CashDenominations>();
            foreach (CashDenominations cashDenomination in cashDenominationsSortedFromGreatestToLeast)
            {
                int cashDenominationAsInt = (int)cashDenomination;
                int denominationCount = remainderOfChange / cashDenominationAsInt;
                result.Add(cashDenomination, denominationCount);
                if (remainderOfChange > cashDenominationAsInt)
                {
                    remainderOfChange %= cashDenominationAsInt;
                }
            }
            return result;
        }

        // NOTE: Trully random calculation would involve picking a random combination of change from every single
        // possible combination of denominations for the given change amount.
        // (https://andrew.neitsch.ca/publications/m496pres1.nb.pdf)
        // 
        // I would give my client this option in reality, but explain that this would require some extensive
        // research on my part. Rather than taking the time to implement that solution, I used the algorithm
        // of choosing a denomination at random and subracting a random amount of the denomination it from
        // the change, until I account for all the change.
        public Dictionary<CashDenominations,int> CalculateRandomAmountsOfChange(CashTransaction cashTransaction)
        {
            Dictionary<CashDenominations, int> result = new Dictionary<CashDenominations, int>();
            int remainderOfChange = cashTransaction.ChangeTotal;
            List<CashDenominations> cashDenominations =
                Enum.GetValues(typeof(CashDenominations))
                .Cast<CashDenominations>()
                .ToList();
            while (remainderOfChange > 0)
            {
                int randomDenominationIndex = Random.Next(cashDenominations.Count);

                CashDenominations randomDenomination = cashDenominations[randomDenominationIndex];
                int randomDenominationAsInt = (int) randomDenomination;
                if (randomDenominationAsInt <= remainderOfChange)
                {
                    int randomAmoutOfTheDenomination =
                        Random.Next(1, remainderOfChange / randomDenominationAsInt + 1);
                    remainderOfChange -= randomDenominationAsInt * randomAmoutOfTheDenomination;
                    // See if denom has entry, if not, add + make value 1
                    // If so, increment the value.
                    if (result.ContainsKey(randomDenomination))
                    {
                        result[randomDenomination] += randomAmoutOfTheDenomination;
                    }
                    else
                    {
                        result.Add(randomDenomination, randomAmoutOfTheDenomination);
                    }
                }
            }
            return result;
        }

        // Helper function for readability.
        public bool IsDivsibleByThree(int number)
        {
            return number % 3 == 0;
        }

    }

}
