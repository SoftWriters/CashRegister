using System;
using System.IO;

namespace CashDrawer.App.Tests.Helpers
{
    public sealed class DummyConsole : IDisposable
    {
        private readonly TextWriter   _oldWriter;
        private readonly StringWriter _newWriter;

        public string Text => _newWriter.ToString();


        public DummyConsole()
        {
            _newWriter = new StringWriter();
            _oldWriter = Console.Out;
            Console.SetOut(_newWriter);
        }


        public void Dispose()
        {
            Console.SetOut(_oldWriter);
            _newWriter.Dispose();
        }
    }
}
