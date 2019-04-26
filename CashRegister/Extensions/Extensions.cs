using System;
using System.Web;

namespace CashRegister.Extensions
{
    /// <summary>
    /// Various extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Read and convert a file into an ASCII string
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ToAsciiString(this HttpPostedFileBase file)
        {
            // Sanity check - this should already be handled by the front-end form
            if (!file.FileName.EndsWith(".txt"))
            {
                throw new Exception("Only *.txt files can be read as ASCII string");
            }

            // Just in case
            if (!file.InputStream.CanRead)
            {
                throw new Exception("Cannot read from file's InputStream");
            }

            string asciiString = "";

            int b = file.InputStream.ReadByte();

            while (b != -1) // -1 means it's the end of the stream
            {
                // Convert the byte to a corresponding character and add it to the string
                asciiString += Convert.ToChar(b);
                // Read the next byte
                b = file.InputStream.ReadByte();
            }

            return asciiString;
        }

        /// <summary>
        /// Pluralize a noun. Intended to be used for currency denominations.
        /// </summary>
        /// <param name="singular"></param>
        /// <returns></returns>
        public static string ToPlural(this string singular)
        {
            string plural = singular;

            if (singular.EndsWith("s")
                || singular.EndsWith("x")
                || singular.EndsWith("z")
                || singular.EndsWith("ch")
                || singular.EndsWith("sh"))
            {
                plural = singular + "es";
            }
            else if(singular.EndsWith("y"))
            {
                plural = singular.Substring(0, singular.Length - 1) + "ies";
            }
            else
            {
                plural = singular + "s";
            }

            // Special cases are ignored for now

            return plural;
        }
    }
}