using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace CashRegister.TransactionReaders
{
    public class SimpleFileTransactionReader : ITransactionReader
    {
        private TextReader InputStream { get; }

        public SimpleFileTransactionReader(TextReader inputStream)
        {
            InputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream));
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            using (var csv = new CsvReader(InputStream))
            {
                csv.Configuration.RegisterClassMap<TransactionCsvMap>();
                return csv.GetRecords<Transaction>();
            }
        }

        private class TransactionCsvMap : CsvHelper.Configuration.ClassMap<Transaction>
        {
            public TransactionCsvMap()
            {
                Map(m => m.MoneyOwed);
                Map(m => m.MoneyPaid);
            }
        }
    }
}
