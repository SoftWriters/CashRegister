using System.IO;
using ChangeCalculator;

namespace CashRegister
{
    public class FileHandler : IIOHandler
    {
        private string _inputFile;
        private string _outputFile;

        public FileHandler(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
        }

        public string Load() => File.ReadAllText(_inputFile);

        public void Save(string data) => File.WriteAllText(_outputFile, data);
    }
}
