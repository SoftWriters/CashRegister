using System;
using System.IO;
using CashRegister;

namespace CashRegisterLibrary
{
    public class Tests
    {
        static TextWriter ConsoleOut_Initial; 
        static TextWriter ConsoleOut_Hide;
        static int TestNameLength = 35;

        static public void RunTests()
        {
            ConsoleOut_Initial = Console.Out;
            ConsoleOut_Hide = new StringWriter();

            Console.WriteLine("TEST SUITE START");

            HasValidArgs(
                null, 
                "HasValidArgs:NoArgs",
                "Please provide an input and output file. Ex: CashRegister input.txt output.txt");
            
            HasValidArgs(
                new string[] {"1BadArg"}, 
                "HasValidArgs:1Arg",
                "Please provide an input and output file. Ex: CashRegister input.txt output.txt");

            HasValidArgs(
                new string[] {"1BadArg", "Another Bad Arg", "3rd Bad Arg"}, 
                "HasValidArgs:3Args",
                "Please provide an input and output file. Ex: CashRegister input.txt output.txt");

            HasValidArgs(
                new string[] {"1st Arg", "2nd Arg"}, 
                "HasValidArgs:File Doesn't Exist",
                "Input file doesn't exist.");

            IsValidFile(
                new string[] {"GoodInputFile", "Output File"}, 
                "IsValidFile:GoodInputFile");

            IsValidInputLine(
                "IsValidLine:ExtraData",
                "Malformed line: Each line must contain the total due and the amount paid separated by a comma (for example: 2.13,3.00)",
                "1.97,2.00,extra stuff");

            IsValidInputLine(
                "IsValidLine:NotEnoughData",
                "Malformed line: Each line must contain the total due and the amount paid separated by a comma (for example: 2.13,3.00)",
                "1.97");

            IsValidInputLine(
                "IsValidLine:BadTotalDue",
                "Malformed line: Total Due must be a decimal",
                "Nope,2.00");

            IsValidInputLine(
                "IsValidLine:BadAmountPaid",
                "Malformed line: Amount Paid must be a decimal",
                "2.00,Nope");

            IsExpectedOutputLine(
                "IsExpectedOutput:OnlyDollar",
                (decimal)1.00, (decimal)5.00,
                "4 dollars"
            );

            IsExpectedOutputLine(
                "IsExpectedOutput:ManyDollars",
                (decimal)1.00, (decimal)494.00,
                "4 hundreds,4 twenties,2 fives,3 dollars"
            );

            IsExpectedOutputLine(
                "IsExpectedOutput:SampleOutput1",
                (decimal)2.12, (decimal)3.00,
                "3 quarters,1 dime,3 pennies"
            );

            IsExpectedOutputLine(
                "IsExpectedOutput:SampleOutput2",
                (decimal)1.97, (decimal)2.00,
                "3 pennies"
            );

            IsExpectedOutputLine(
                "IsExpectedOutput:SampleOutput3",
                (decimal)3.33, (decimal)5.00,
                "1 dollar,2 quarters,1 dime,1 nickle,2 pennies"
            );


            Console.WriteLine("TEST SUITE END");
        }
        static void HasValidArgs(string[] args, string testName, string expectedText)
        {
            Console.SetOut(ConsoleOut_Hide);
            CashRegister.Program.HasValidArgs(args);
            string testResult = (CashRegister.Program.myConsoleText == expectedText ? "pass" : "fail");
            string str = String.Format("{0, -"+TestNameLength+"}", testName) + " " + testResult;
            Console.SetOut(ConsoleOut_Initial);
            Console.WriteLine(str);
        }
        static void IsValidFile(string[] args, string testName)
        {
            Console.SetOut(ConsoleOut_Hide);
            bool condition = 
                CashRegister.Program.HasValidArgs(args) && 
                CashRegister.Program.IsValidFile();
            string testResult = ( condition ? "pass" : "fail");
            string str = String.Format("{0, -"+TestNameLength+"}", testName) + " " + testResult;
            Console.SetOut(ConsoleOut_Initial);
            Console.WriteLine(str);
        }
        static void IsValidInputLine(string testName, string expectedText, string testLine)
        {
            Console.SetOut(ConsoleOut_Hide);
            bool condition = CashRegister.Program.IsValidLine(testLine);
            string testResult = (CashRegister.Program.myConsoleText == expectedText ? "pass" : "fail");
            string str = String.Format("{0, -"+TestNameLength+"}", testName) + " " + testResult;
            Console.SetOut(ConsoleOut_Initial);
            Console.WriteLine(str);
        }
        static void IsExpectedOutputLine(string testName, decimal totalDue, decimal amountPaid, string expectedLine)
        {
            string programLine = CashRegister.Program.GenerateOutputLine(new InputLine(totalDue, amountPaid));
            string testResult = (programLine == expectedLine ? "pass" : "fail");
            string str = String.Format("{0, -"+TestNameLength+"}", testName) + " " + testResult;
            Console.WriteLine(str);
        }
    }
}
