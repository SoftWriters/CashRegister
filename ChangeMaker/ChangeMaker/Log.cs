using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    public static class Log
    {
        public static List<string> LogEntries;

        public static void Initialize()
        {
            LogEntries = new List<string>();
        }

        public static void WriteLine(string msg)
        {
            Console.WriteLine(msg);
            LogEntries.Add(msg);
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void OutputToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(var entry in LogEntries)
                {
                    writer.WriteLine(entry);
                }
            }
        }
    }
}
