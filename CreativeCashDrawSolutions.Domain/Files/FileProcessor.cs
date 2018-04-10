using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace CreativeCashDrawSolutions.Domain.Files
{
    public class FileProcessor
    {
        private readonly IFileSystem _fileSystem;

        public FileProcessor() : this(new FileSystem())
        {
        }

        public FileProcessor(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public List<string> ImportTransactions(string filePath)
        {
            var transactions = new List<string>();
            using (var fileStreamReader = _fileSystem.File.OpenText(filePath))
            {
                string line;
                while ((line = fileStreamReader.ReadLine()) != null)
                {
                    transactions.Add(line);
                }
            }

            return transactions;
        }

        public void WriteTransactions(string filePath, IEnumerable<string> transactions)
        {
            using (TextWriter fileStreamWriter = _fileSystem.File.CreateText(filePath))
            {
                foreach (var transaction in transactions)
                {
                    fileStreamWriter.WriteLine(transaction);
                }
            }
        }
    }
}
