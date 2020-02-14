using System.Linq;

namespace CashRegisterConsumer
{
    public class StandardTenderStrategy : TenderStrategy
    {
        public override ICurrency Calculate(ICurrency currency, decimal price, decimal tender)
        {
            return base.Calculate(currency, price, tender);
        }
    }
}