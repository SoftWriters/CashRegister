using CashDrawer.Core.Readers;
using System;
using System.IO;

namespace CashDrawer.App.FileReaders
{
    public sealed class InputFileReader : IDisposable, IInputReader
    {
        private StreamReader _reader;
        private readonly ILineParser _lineParser;

        public InputFileReader(string filename, ILineParser lineParser)
        {
            _reader = new StreamReader(filename);
            _lineParser = lineParser;
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public bool HaveMore => !_reader.EndOfStream;

        public ReadResult Next()
        {
            var s = _reader.ReadLine();
            return _lineParser.Parse(s);
        }
    }
}
