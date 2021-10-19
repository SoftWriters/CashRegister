using System;

namespace CashRegister
{
    public class Coins
    {
        public const decimal HundredValue = 100;
        public const decimal FiftyValue = 50;
        public const decimal TwentyValue = 20;
        public const decimal TenValue = 10;
        public const decimal FiveValue = 5;
        public const decimal DollarValue = 1;
        public const decimal QuarterValue = 0.25m;
        public const decimal DimeValue = 0.10m;
        public const decimal NickelValue = 0.05m;
        public const decimal PennyValue = 0.01m;

        public int HundredBills { get; set; }
        public int FiftyBills { get; set; }
        public int TwentyBills { get; set; }
        public int TenBills { get; set; }
        public int FiveBills { get; set; }
        public int DollarBills { get; set; }
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }
        /// <summary>
        /// Checks the summation if any change is not necessary
        /// </summary>
        /// <param name="coins">Adds all the integers together</param>
        /// <returns>the total added</returns>
        public int SumofTotal
        {
            get {
                return HundredBills + FiftyBills + TwentyBills + TenBills + FiveBills + DollarBills
                + Quarters + Dimes + Nickels + Pennies;
                }
        }
        
        /// <summary>
        /// Writing out how many dollars and/or coins is needed
        /// </summary>
        /// <param name="coins">Coins object containing all the information</param>
        /// <returns>a string that has been concatenation</returns>
        public string ChangeGiven()
        {
            String changeGiven = string.Empty;

            if (HundredBills > 0)
            {
                changeGiven += HundredBills == 1 ? HundredBills + " hundred dollar," : DollarBills + " hundred dollars,";
            }
            if (FiftyBills > 0)
            {
                changeGiven += FiftyBills == 1 ? FiftyBills + " fifty dollar," : FiftyBills + " fifty dollars,";
            }
            if (TwentyBills > 0)
            {
                changeGiven += TwentyBills == 1 ? TwentyBills + " twent dollar," : TwentyBills + " twenty dollars,";
            }
            if (TenBills > 0)
            {
                changeGiven += TenBills == 1 ? TenBills + " ten dollar," : TenBills + " ten dollars,";
            }
            if (FiveBills > 0)
            {
                changeGiven += FiveBills == 1 ? FiveBills + " five dollar," : FiveBills + " five dollars,";
            }
            if (DollarBills > 0)
            {
                changeGiven += DollarBills == 1 ? DollarBills + " dollar," : DollarBills + " dollars,";
            }
            if (Quarters > 0)
            {
                changeGiven += Quarters == 1 ? Quarters + " quarter," : Quarters + " quarters,";
            }
            if (Dimes > 0)
            {
                changeGiven += Dimes == 1 ? Dimes + " dime," : Dimes + " dimes,";
            }
            if (Nickels > 0)
            {
                changeGiven += Nickels == 1 ? Nickels + " nickel," : Nickels + " nickles,";
            }
            if (Pennies > 0)
            {
                changeGiven += Pennies == 1 ? Pennies + " penny," : Pennies + " pennies,";
            }

            if (SumofTotal== 0)
            {
                changeGiven += "No change needed,";
            }
            changeGiven = changeGiven.Remove(changeGiven.Length - 1);
            changeGiven += "\n";
            return changeGiven;
        }
    }
}
