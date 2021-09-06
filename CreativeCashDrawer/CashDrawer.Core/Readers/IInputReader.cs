namespace CashDrawer.Core.Readers
{
    public interface IInputReader
    {
        bool HaveMore { get; }

        ReadResult Next();
    }
}