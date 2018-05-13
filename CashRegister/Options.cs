using CommandLine;

namespace CashRegister
{
    internal class Options
    {
        [Option('i', Default = "-", Required = false, HelpText = "Name of the input file.  Use '-' for stdin.")]
        public string InFile { get; set; }

        [Option('o', Default = "-", Required = false, HelpText = "Name of the output file.  Use '-' for stdout.")]
        public string OutFile { get; set; }
    }
}
