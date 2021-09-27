using System.Collections.Generic;
using System.IO;
using CashRegister.Models;

namespace CashRegister.Services.Interfaces
{
    public interface ICsvFileParser
    {
        List<CashRegisterTransaction> ParseCsvFile(Stream stream);
    }
}