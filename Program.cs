using System;
using System.IO;
using System.Windows.Forms;
using CCDS.res.forms;

namespace CCDS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool ExceptionThrown, TextFilesChecked = true, CsvFilesChecked = true, IsFileData;
        public static readonly string CarriageReturnLineFeed = $"\r\n", StartScreenText = $@"PLEASE CHOOSE TO OPEN A FILE OR ENTER INTERACTIVE MODE...";
        public static string OpenFileDirectory = $"{Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString())}\\res\\files\\input", SaveFileDirectory = $"{Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString())}\\res\\files\\output";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CashRegisterForm());

            //Console mode
            //Console.WriteLine("C# is cool");
/*            Console.Write("Please enter the total due, and the amount paid seperated by a comma (e.g., \"2.13, 3.00\"):");
            var val = Console.ReadLine();
            Console.WriteLine("You entered '{0}'", val);*/
        }
    }
}
