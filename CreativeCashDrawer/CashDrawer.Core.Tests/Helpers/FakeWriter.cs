using CashDrawer.Core.Writers;
using System.Collections.Generic;

namespace CashDrawer.Core.Tests.Helpers
{
    public class FakeWriter : IOutputWriter
    {
        public List<Change> WrittenChange = new();
        public List<string> WrittenErrors = new();


        public void Write(Change change)
        {
            WrittenChange.Add(change);
        }

        public void WriteError(string error)
        {
            WrittenErrors.Add(error);
        }
    }
}
