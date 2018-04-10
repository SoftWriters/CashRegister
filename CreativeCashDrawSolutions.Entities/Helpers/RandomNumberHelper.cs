using System;

namespace CreativeCashDrawSolutions.Entities.Helpers
{
    public class RandomNumberHelper
    {

        private static readonly Random RandomGenerator = new Random();
        private static readonly object SyncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            // Our random number was not being so random in larger tests
            lock (SyncLock)
            {
                return RandomGenerator.Next(min, max);
            }
        }
    }
}
