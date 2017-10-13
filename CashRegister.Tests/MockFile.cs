using System.Collections.Generic;
using System.Linq;
using CashRegister.BL.Objects;
using CashRegister.BL.Services;

namespace CashRegister.Tests
{
    public class MockFile : IInputSource, IOutputSource
    {
        IEnumerable<Transaction> IInputSource.LoadData()
        {
            return Enumerable.Empty<Transaction>();
        }

        bool IOutputSource.SaveData(IList<Denomination> dataList)
        {
            return true;
        }
    }
}