using System;
using System.Collections.Generic;
using System.IO;

namespace CashRegister
{
    public enum AbovePrice
    {
        Hundred = 1,
        Fifty,
        Twenty,
        Ten,
        Five,
        Dollar,
        Quarter,
        Dime,
        Nickel,
        Penny
    }
    public class ChangeCalculations
    {
        /// <summary>
        /// Reads a flat file and separate each entry with a comma and stores each value in its own list
        /// </summary>
        /// <param name="textFile">flat file</param>
        /// <param name="costValue">1st input in the line</param>
        /// <param name="paidValue">2nd input in the line</param>
        public void Splittingvalues(string textFile, List<string> costValue, List<string> paidValue)
        {
            try
            {
                string line;
                string[] splitLine;

                StreamReader inputFile = new StreamReader(textFile);
                line = inputFile.ReadLine();
                while (line != null)
                {
                    if (line != "")
                    {
                        splitLine = line.Split(",");
                        costValue.Add(splitLine[0]);
                        paidValue.Add(splitLine[1]);

                    }
                    line = inputFile.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// Checks whether or not if the costvalue is divisible by 3 else do normal calculations
        /// </summary>
        /// <param name="costValue"></param>
        /// <param name="paidValue"></param>
        public void ChangeofCost(List<string> costValue, List<string> paidValue, List<string> change)
        {
            for (int i = 0; i < paidValue.Count; i++)
            {
                if (double.Parse(costValue[i]) * 100 % 3 == 0)
                {
                    change.Add(RandomizeNumberofCoins(paidValue[i], costValue[i]));
                }
                else
                {
                    change.Add(CalculatingNumberofCoins(paidValue[i], costValue[i]));
                }

            }

        }
        /// <summary>
        /// Randomize the amount of coins received
        /// </summary>
        /// <param name="paid">the 2nd input of the line</param>
        /// <param name="cost">the 1st input of the line</param>
        /// <returns>the concatenate string of change given</returns>
        public string RandomizeNumberofCoins(string paid, string cost)
        {
            decimal difference = Math.Round(decimal.Parse(paid) - decimal.Parse(cost), 2);
            if (difference < 0)
            {
                return "Not enough funds to give change\n";
            }
            Coins coins = new Coins();

            while (difference != 0)
            {
                difference = SubtractionofRandomization(RandomizationCalculation(difference), coins, difference);

            }
            return coins.ChangeGiven();
        }
        /// <summary>
        /// Randomly subtract the change from dollar or coin value
        /// </summary>
        /// <param name="randomNumber">random number that was generated between 1-10</param>
        /// <param name="coins">object containing the amount of coins</param>
        /// <param name="change">the amount of change</param>
        /// <returns>the leftover amount of change</returns>
        public decimal SubtractionofRandomization(int randomNumber, Coins coins, decimal change)
        {
            switch (randomNumber)
            {
                case (int)AbovePrice.Hundred:
                    {
                        coins.HundredBills++;
                        return change -= Coins.HundredValue;
                    }
                case (int)AbovePrice.Fifty:
                    {
                        coins.FiftyBills++;
                        return change -= Coins.FiftyValue;
                    }
                case (int)AbovePrice.Twenty:
                    {
                        coins.TwentyBills++;
                        return change -= Coins.TwentyValue;
                    }
                case (int)AbovePrice.Ten:
                    {
                        coins.TenBills++;
                        return change -= Coins.TenValue;
                    }
                 case (int)AbovePrice.Five:
                    {
                        coins.FiveBills++;
                        return change -= Coins.FiveValue;
                    }
                 case (int)AbovePrice.Dollar:
                    {
                        coins.DollarBills++;
                        return change -= Coins.DollarValue;
                    }
                 case (int)AbovePrice.Quarter:
                    {
                        coins.Quarters++;
                        return change -= Coins.QuarterValue;
                    }
                 case (int)AbovePrice.Dime:
                    {
                        coins.Dimes++;
                        return change -= Coins.DimeValue;
                    }
                 case (int)AbovePrice.Nickel:
                    {
                        coins.Nickels++;
                        return change -= Coins.NickelValue;
                    }
                 case (int)AbovePrice.Penny:
                    {
                        coins.Pennies++;
                        return change -= Coins.PennyValue;
                    }
            }
            return 0;
        }

        /// <summary>
        /// The minimum amount of change owed
        /// </summary>
        /// <param name="paid">2nd input of the flat file line</param>
        /// <param name="cost">1st input of the flat file line</param>
        /// <returns>the concatenate string of change given</returns>
        public string CalculatingNumberofCoins(string paid, string cost)
        {
            Coins coins = new Coins();

            decimal difference = Math.Round(decimal.Parse(paid) - decimal.Parse(cost), 2);

            if (difference < 0)
            {
                return "Not enough funds to give change\n";
            }
            coins.HundredBills = (int)(difference / Coins.HundredValue);
            difference %= Coins.HundredValue;

            coins.FiftyBills = (int)(difference / Coins.FiftyValue);
            difference %= Coins.FiftyValue;

            coins.TwentyBills = (int)(difference / Coins.TwentyValue);
            difference %= Coins.TwentyValue;

            coins.TenBills = (int)(difference / Coins.TenValue);
            difference %= Coins.TenValue;

            coins.FiveBills = (int)(difference / Coins.FiveValue);
            difference %= Coins.FiveValue;

            coins.DollarBills = (int)(difference / Coins.DollarValue);
            difference %= Coins.DollarValue;

            coins.Quarters = (int)(difference / Coins.QuarterValue);
            difference %= Coins.QuarterValue;

            coins.Dimes = (int)(difference / Coins.DimeValue);
            difference %= Coins.DimeValue;

            coins.Nickels = (int)(difference / Coins.NickelValue);
            difference %= Coins.NickelValue;

            coins.Pennies = (int)(difference / Coins.PennyValue);

            return coins.ChangeGiven();
        }
        /// <summary>
        /// Randomly grabs a number from 1-10 depending if the change is greater than the value
        /// </summary>
        /// <param name="change">total amount of change</param>
        /// <returns>a random number from 1-10</returns>
        public int RandomizationCalculation(decimal change)
        {
            Random rnd = new Random();

            switch (change)
            {
                case decimal n when (n >= Coins.HundredValue):
                    {
                        return rnd.Next(1, 11);
                    }
                case decimal n when (n >= Coins.FiftyValue):
                    {
                        return rnd.Next(2, 11);
                    }
                case decimal n when (n >= Coins.TwentyValue):
                    {
                        return rnd.Next(3, 11);
                    }
                case decimal n when (n >= Coins.TenValue):
                    {
                        return rnd.Next(4, 11);
                    }
                case decimal n when (n >= Coins.FiveValue):
                    {
                        return rnd.Next(5, 11);
                    }
                case decimal n when (n >= Coins.DollarValue):
                    {
                        return rnd.Next(6, 11);
                    }
                case decimal n when (n >= Coins.QuarterValue):
                    {
                        return rnd.Next(7, 11);
                    }
                case decimal n when (n >= Coins.DimeValue):
                    {
                        return rnd.Next(8, 11);
                    }
                case decimal n when (n >= Coins.NickelValue):
                    {
                        return rnd.Next(9, 11);
                    }
                case decimal n when (n >= Coins.PennyValue):
                    {
                        return rnd.Next(10, 11);
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
