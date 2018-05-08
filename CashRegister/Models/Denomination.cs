namespace CashRegister.Models
{
    /// <summary>
    /// Currency denomination. USD is presumed, but can be anything.
    /// </summary>
    public class Denomination
    {
        public decimal Value { get; set; }
        public string Name { get; set; }

        public Denomination(decimal value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}