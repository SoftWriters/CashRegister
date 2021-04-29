using System.IO;

namespace CashRegister.Validators
{
    public static class InputValidator
    {
        #region Private Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Validates that provided paths are not empty.
        /// </summary>
        /// <param name="inputFilePath">String for input file path.</param>
        /// <param name="outputFilePath">String for output file path.</param>
        private static void CheckFilePaths(string inputFilePath, string outputFilePath)
        {
            //Validate inputs - make sure they are not empty or null
            //Throw exceptions so that log file gets updated.
            if (string.IsNullOrEmpty(inputFilePath))
                throw new System.ArgumentNullException(nameof(inputFilePath));

            if (string.IsNullOrEmpty(outputFilePath))
                throw new System.ArgumentNullException(nameof(outputFilePath));
        }

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Validates that provided file paths actually exist.
        /// </summary>
        /// <param name="inputFilePath">String for full path to input file.</param>
        private static void DoesFileExist(string inputFilePath)
        {
            //Path to source text file
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException($"Specified file does not exist: {inputFilePath}", inputFilePath);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Validates that all inputs are valid.
        /// </summary>
        /// <param name="inputFilePath">String for input file path.</param>
        /// <param name="outputFilePath">String for output file path.</param>
        public static void ValidateInputs(string inputFilePath, string outputFilePath)
        {
            //Make sure inputs are not blank
            CheckFilePaths(inputFilePath, outputFilePath);

            //Make sure inputs exist
            DoesFileExist(inputFilePath);
        }
        #endregion
    }
}
