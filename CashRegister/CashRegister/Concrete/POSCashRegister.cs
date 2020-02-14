namespace CashRegisterConsumer
{
    public class POSCashRegister : CashRegister
    {
        public POSCashRegister(ICurrency currency, ITenderStrategy tenderStrategy) : base(currency, tenderStrategy)
        {
        }
    }
}