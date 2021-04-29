using System;
using System.Collections.Generic;
using System.Text;
using CashRegister.Core;

namespace CashRegister.Processors
{
    public static class InputDataProcessor
    {
        #region Private Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Gets a descriptor string for CoinPurses which contain change details for each line in the source file.
        /// </summary>
        /// <param name="sourceData">A collection of lines of text, representing source data to be processed.</param>
        /// <returns>Returns a descriptor string of all CoinPurses generated for every line in the source file.</returns>
        private static string GetAllCoinPurseDescriptors(IEnumerable<string> sourceData)
        {
            var returnValue = new StringBuilder();

            foreach (var currentLine in sourceData)
            {
                //Break up each line by splitting on the comma delimiter                
                var dataRow = currentLine.Split(',');
                if (dataRow.Length > 1)
                {
                    var currentPurse = CoinPurse.GetChangePurse(dataRow[0], dataRow[1]);
                    //Example output has double-spacing, so we'll do the same for ease of reading.
                    returnValue.AppendLine($"{currentPurse.GetCollectionVerboseString()}{Environment.NewLine}");
                }
            }
            return returnValue.ToString();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Processes contents of source file to generate final descriptive output.
        /// </summary>
        /// <param name="sourceDataLines">A collection of strings containing all source data from file.</param>
        /// <returns>Returns a string representing all contents of all change for all transactions.</returns>
        public static string ProcessData(IEnumerable<string> sourceDataLines)
        {
            return GetAllCoinPurseDescriptors(sourceDataLines);
        }
        #endregion
    }
}
