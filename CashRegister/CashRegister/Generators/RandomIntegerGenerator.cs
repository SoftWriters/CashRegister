namespace CashRegister.Generators
{
    public static class RandomIntegerGenerator
    {
        #region Private Members
        private static System.Random _randomNumbers;
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Uses a System.Random object to generate random numbers.
        /// </summary>
        /// <param name="lowerBound">Int for lower bound of random range.</param>
        /// <param name="upperBound">Int for upper bound of random range.
        ///                          Must be 1 higher than desired highest possible value.</param>
        /// <returns>Returns a random int in the specified range.</returns>
        public static int GetRandomNumber(int lowerBound, int upperBound)
        {
            if (_randomNumbers == null)
            {
                _randomNumbers = new System.Random();
            }
            var returnValue = _randomNumbers.Next(lowerBound, upperBound);
            return returnValue;
        }
        #endregion
    }
}
