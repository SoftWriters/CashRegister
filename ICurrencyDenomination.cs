namespace CashRegister
{
    public interface ICurrencyDenomination
    {
        int ValueInLowestDenomination { get; set; }
        string Name { get; set; }
    }
}
