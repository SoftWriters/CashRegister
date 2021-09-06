using CashDrawer.Core.Readers;

namespace CashDrawer.App.FileReaders
{
    public interface ILineParser
    {
        ReadResult Parse(string line);
    }
}