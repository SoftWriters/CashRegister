using System;

namespace CashMachine.Infrastructure
{
    public interface IArgBuilder
    {
        void ValidateArgs(string[] args);
    }

    public class ArgBuilder : IArgBuilder
    {
        public void ValidateArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Out.Write("valid number of arguments: " + args);
                throw new ArgumentException();
            }
        }
    }
}
