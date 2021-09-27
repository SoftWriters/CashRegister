using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using CashRegister.Models;
using CashRegister.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;

namespace CashRegister.Services
{
    public class CsvFileParser : ICsvFileParser
    {
        public List<CashRegisterTransaction> ParseCsvFile(Stream stream)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            List<CashRegisterTransaction> cashRegisterTransactions;

            using (var csvParser = new CsvReader(new StreamReader(stream), config))
            {
                cashRegisterTransactions = csvParser.GetRecords<CashRegisterTransaction>().ToList();
            }

            return cashRegisterTransactions;
        }
    }
}