namespace ChangeCalculator
{
    public class Change
    {
        public int Dollars { get; set; }
        public int Quarters { get; set; }
        public int Nickels { get; set; }
        public int Dimes { get; set; }
        public int Pennies { get; set; }

        public override string ToString()
        {
            string result = "";

            result = AppendAmount(result, Dollars, "dollar", "dollars");
            result = AppendAmount(result, Quarters, "quarter", "quarters");
            result = AppendAmount(result, Nickels, "nickle", "nickels");
            result = AppendAmount(result, Dimes, "dime", "dimes");
            result = AppendAmount(result, Pennies, "penny", "pennies");

            return result;
        }

        private string AppendAmount(string oldString, int value, string one, string many)
        {
            string result = oldString;
            
            if (value == 1)
            {
                result += (oldString == "" ? "" : ", ") + $"{value} {one}";
            }
            else if (value > 1)
            {
                result += (oldString == "" ? "" : ", ") + $"{value} {many}";
            }

            return result;
        }
    }
}
