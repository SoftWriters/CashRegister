namespace CashRegister
{
    public class ChangeAmount
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Amount, Description);
        }
    }
}
