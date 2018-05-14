using System;
using System.IO;
using CommandLine;
using CashRegister.ChangeFormatters;
using CashRegister.TransactionReaders;

namespace CashRegister
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunProgram)
                .WithNotParsed(errors => Environment.ExitCode = 1);

            return Environment.ExitCode;
        }

        private static void RunProgram(Options options)
        {
            try
            {
                var useStdIn = options.InFile == "-";
                var useStdOut = options.OutFile == "-";
                TextReader inStream = null;
                TextWriter outStream = null;
                try
                {
                    inStream = useStdIn ? Console.In : new StreamReader(options.InFile);
                    outStream = useStdOut ? Console.Out : new StreamWriter(options.OutFile);

                    ITransactionReader transactionReader = new SimpleFileTransactionReader(inStream);

                    foreach (Transaction transaction in transactionReader.GetTransactions())
                    {
                        IChangeFormatter changeFormatter = ChangeFormatterProvider.GetChangeFormatter(transaction);
                        outStream.WriteLine(changeFormatter.FormatChangeResult(transaction));
                    }
                }
                finally
                {
                    if (!useStdIn)
                        inStream?.Dispose();
                    if (!useStdOut)
                        outStream?.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.ExitCode = 2;
            }
        }
    }
}
