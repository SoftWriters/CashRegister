using System.Collections.Generic;

namespace CashRegister
{
    public interface IPurchaseTransactionImporter
    {
        IEnumerable<PurchaseTransaction> GetPurchaseTransactions();
    }
}
