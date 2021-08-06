using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public interface IWriteService
    {
        public void WriteFile(List<Change> changeList);
    }
}
