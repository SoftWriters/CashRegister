using System;

namespace BusinessLogic.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsDivisibleByNum(this decimal testNumber, int divisibleBy)
        {
            int total = 0;

            string num = testNumber.ToString();
            foreach(char c in num)
            {
                if (c != '.')
                {
                    total += Convert.ToInt32(c);
                }
            }

            return ((total % divisibleBy) == 0);
        }
    }
}