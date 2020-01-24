using System;
using System.IO;
using System.Resources;

namespace CashRegister
{
    public static class Props
    {
        public static ResourceManager ResourceManager => Properties.Resources.ResourceManager;

        /// <summary>
        /// Exception messages are written to this file
        /// </summary>
        public static string MessagesFile
        {
            get
            {
                var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;
                if (directoryInfo != null)
                    return directoryInfo.FullName + "\\Messages.txt";

                // If directory above doesn't exist, place Messages file in current directory
                return "\\Messages.txt";
            }
        }

        /// <summary>
        /// Output file containing results of processed data
        /// </summary>
        public static string OutputFile
        {
            get
            {
                var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;
                if (directoryInfo != null)
                    return directoryInfo.FullName + "\\OutputFile.txt";

                // If directory above doesn't exist, place Messages file in current directory
                return "\\OutputFile.txt";
            }
        }
    }
}