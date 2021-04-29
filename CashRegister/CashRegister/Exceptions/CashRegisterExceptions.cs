using System;
using System.Diagnostics;

namespace CashRegister.Exceptions
{
    public static class CashRegisterExceptions
    {
        /// <summary>
        /// Author:  Brian Sabotta
        /// Date:    10/31/2019
        /// Notes:   Since this is a small scale console app for now,
        ///          we will just write out errors to the console.
        ///          Log files could be swapped in for a bigger UI-based app.
        /// </summary>
        /// <param name="ex">The thrown exception we are writing to the console.</param>
        public static void HandleException(Exception ex)
        {
            //If running in debugger, write out to output window, since we don't see console.
            if (Debugger.IsAttached)
            {
                Debug.Print(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            else
            {
                Console.WriteLine(ex);
            }
        }
    }
}
