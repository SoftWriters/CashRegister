namespace CCDS.CashRegister
{
    public readonly struct Transaction
    {
        public readonly long Cost;
        public readonly long Payment;

        public Transaction(long cost, long payment)
        {
            this.Cost = cost;
            this.Payment = payment;
        }
    }
}
