namespace CashRegister.Models
{
    /// <summary>
    /// Data that was uploaded into and calculated by Cash Register
    /// </summary>
    public class CashRegisterRecord
    {
        public decimal Owed { get; set; }
        public decimal Paid { get; set; }
        public decimal Change { get; set; }
        public string ChangeText { get; set; } // Change written out in currency denominations and numbers of them
        public bool Error { get; set; }
    }
}