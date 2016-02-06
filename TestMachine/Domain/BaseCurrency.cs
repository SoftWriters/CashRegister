namespace CashMachine.Domain
{
    public interface ICurrency
    {
        decimal Value { get; }
        string Name { get; }

        string ToString(int count);
    }

    public abstract class BaseCurrency : ICurrency
    {
        protected BaseCurrency(string name, string puralName, decimal value)
        {
            Name = name;
            Value = value;
            PuralName = puralName;
        }

        public string Name { get; }

        public string PuralName { get; }

        public decimal Value { get; }

        public virtual string ToString(int count)
        {
            if (count == 0) return string.Empty;
            return count.ToString() + " " + (count == 1 ? Name : PuralName);
        }
    }
}
