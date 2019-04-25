using System.Collections.Generic;

namespace CashRegister.TransactionReaders
{
    public interface ITransactionReader
    {
        IEnumerable<Transaction> GetTransactions();
    }
}
