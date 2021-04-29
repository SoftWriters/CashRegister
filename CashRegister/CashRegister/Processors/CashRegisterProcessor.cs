using CashRegister.IO;
using CashRegister.Validators;

namespace CashRegister.Processors
{
    public static class CashRegisterProcessor
    {
        #region Public Methods

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Validates existence of input files,
        ///             and processes all data passed to it,
        ///             writing output data to specified file.
        /// </summary>
        public static void ProcessData(string inputFilePath, string outputFilePath)
        {
            //Check validity of inputs.
            //If invalid, throw exceptions to be caught for display in console
            InputValidator.ValidateInputs(inputFilePath, outputFilePath);

            //Get data from file
            var inputData = FileOperations.GetTextLinesFromFile(inputFilePath);

            //Process the data
            var output = InputDataProcessor.ProcessData(inputData);

            //Write output to file
            FileOperations.WriteTextToFile(outputFilePath, output);
        }
        #endregion
    }
}
