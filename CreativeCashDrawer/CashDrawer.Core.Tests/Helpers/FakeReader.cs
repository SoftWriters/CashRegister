using CashDrawer.Core.Readers;
using System.Collections.Generic;

namespace CashDrawer.Core.Tests.Helpers
{
    public class FakeReader : IInputReader
    {
        private List<ReadResult> _results = new();
        private int _position = 0;


        public void Add(ReadResult result)
        {
            _results.Add(result);
        }


        public bool HaveMore => _position < _results.Count;


        public ReadResult Next()
        {
            return _results[_position++];
        }
    }
}
