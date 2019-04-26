using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    public static class Utils
    {
        /// <summary>
        /// Generic function to generate a random number between two inputs (inclusive).
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int startRange, int endRange)
        {
            var randomGenerator = new Random();
            var randomInt = randomGenerator.Next(startRange, endRange);

            return randomInt;
        }
    }
}
