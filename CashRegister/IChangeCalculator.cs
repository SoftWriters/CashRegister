namespace CashRegister
{
    public interface IChangeCalculator
    {
        bool ProcessBatchFile(string inputFilePath, string outputFilePath);
    }
}
