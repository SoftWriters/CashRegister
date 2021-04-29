using System.IO;
using System.Collections.Generic;

namespace CashRegister.IO
{
    public static class FileOperations
    {
        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Gets all lines from a text file and returns them in a collection.
        /// </summary>
        /// <param name="inputFilePath">String specifying full path to source file.</param>
        /// <returns>Returns a collection of strings for data in source file.</returns>
        public static IEnumerable<string> GetTextLinesFromFile(string inputFilePath)
        {
            var allLines = File.ReadAllLines(inputFilePath);
            return new List<string>(allLines);
        }

        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Write all text to the specified file.  Overwrites any pre-existing file.
        /// </summary>
        /// <param name="filePath">String for full file path to write to.</param>
        /// <param name="data">String data to write to file.</param>
        /// <returns>Returns a boolean indicating success or failure of the write attempt.</returns>
        public static void WriteTextToFile(string filePath, string data)
        {
            //Create the directory if it doesn't exist.
            var directoryToMake = Path.GetDirectoryName(filePath);

            if (directoryToMake != null && !Directory.Exists(directoryToMake))
            {
                Directory.CreateDirectory(directoryToMake);
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, data);
        }
        #endregion
    }
}
