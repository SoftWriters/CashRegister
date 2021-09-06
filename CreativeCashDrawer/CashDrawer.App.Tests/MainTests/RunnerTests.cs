using CashDrawer.App.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CashDrawer.App.Tests.MainTests
{
    [TestClass]
    public class RunnerTests
    {

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(3)]
        public void runner_writes_error_to_console_if_arg_count_incorrect(int argCount)
        {
            using var console = new DummyConsole();

            var args = new string[argCount];
            var runner = new Runner();
            runner.Run(args);

            Assert.IsTrue(console.Text.StartsWith("Invalid command."), console.Text);
        }



        [TestMethod]
        public void runner_writes_error_to_console_if_input_file_not_found()
        {
            using var console = new DummyConsole();

            var args = new [] { "missing-file.txt", @"MainTests\out.txt" };
            var runner = new Runner();
            runner.Run(args);

            Assert.AreEqual("Input file not found." + Environment.NewLine, console.Text);
        }



        [TestMethod]
        public void runner_writes_error_to_console_if_input_file_is_empty()
        {
            using var console = new DummyConsole();

            var args = new [] { @"MainTests\InputFile-Empty.txt", @"MainTests\out.txt" };
            var runner = new Runner();
            runner.Run(args);

            Assert.AreEqual("Input file is empty. Nothing to process." + Environment.NewLine, console.Text);
        }



        [TestMethod]
        public void runner_writes_results_to_output_file()
        {
            var outputFileName = @"MainTests\out.txt";
            var args = new[] { @"MainTests\InputFile-Good.txt", outputFileName };
            var runner = new Runner();
            runner.Run(args);

            var output = File.ReadAllLines(outputFileName);

            Assert.AreEqual(2, output.Length);
            Assert.AreEqual("3 quarters, 1 dime, 3 pennies", output[0]);
            Assert.AreEqual("3 pennies", output[1]);
        }
    }
}
