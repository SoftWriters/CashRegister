using System;
using System.Collections.Generic;
using System.Diagnostics;
using CashRegister.Exceptions;
using CashRegister.Processors;

namespace CashRegisterSabotta
{
    public static class CashRegisterManager
    {
        #region Private Members
        //Set up a friendly error message to ensure proper usage of exe
        //Warn user about passing input/output file paths, if not provided at command line.
        private const string UsageError = "{2}{0} must be specified.  Usage = {1} [input file path] [output file path] {2}";
        #endregion

        #region Private Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Gets the desired parameter value by index.
        /// </summary>
        /// <param name="args">The collection of arguments to choose from.</param>
        /// <param name="index">The index of the argument to get.</param>
        /// <param name="argName">The name of the argument for error message, if not provided.</param>
        /// <returns>Returns the value of the parameter at the index specified.</returns>
        private static string GetParameterByIndex(IReadOnlyList<string> args, int index, string argName)
        {
            string returnValue;
            if (args.Count > index)
            {
                returnValue = args[index];
            }
            else
            {
                //If we're running debugger, put text in the output window, otherwise write out to console.
                if (Debugger.IsAttached)
                {
                    Debug.Print(UsageError, argName, AppDomain.CurrentDomain.FriendlyName, Environment.NewLine);
                }
                else
                {
                    Console.Write(UsageError, argName, AppDomain.CurrentDomain.FriendlyName, Environment.NewLine);
                }

                returnValue = string.Empty;
            }
            return returnValue;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Author:     Brian Sabotta
        /// Created:    10/30/2019
        /// Notes:      Checks parameters and starts running the cash register process.
        /// </summary>
        /// <param name="args">Collection of args passed in from command line.</param>
        public static void RunCashRegisterProcessor(string[] args)
        {
            try
            {
                //arg[0] - inputFile
                var inputFile = GetParameterByIndex(args, 0, "Input file");

                //Exit out if not provided
                if (string.IsNullOrEmpty(inputFile))
                    return;

                //arg[1] - outputFile
                var outputFile = GetParameterByIndex(args, 1, "Output file");

                //Exit out if not provided
                if (string.IsNullOrEmpty(outputFile))
                    return;

                //Call the processing method
                CashRegisterProcessor.ProcessData(inputFile, outputFile);

            }
            catch (Exception ex)
            {
                CashRegisterExceptions.HandleException(ex);
            }
        }
        #endregion
    }
}
