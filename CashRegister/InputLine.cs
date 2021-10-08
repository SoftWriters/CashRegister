namespace CashRegister
{
    public class InputLine
    {
        public decimal TotalDue;
        public decimal AmountPaid;

        public InputLine(decimal totalDue, decimal amountPaid)
        {
            TotalDue = totalDue;
            AmountPaid = amountPaid;
        }
    }
}
