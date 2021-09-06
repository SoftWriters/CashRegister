namespace CashDrawer.Core.Writers
{
    public interface IOutputWriter
    {
        void Write(Change change);

        void WriteError(string error);
    }
}