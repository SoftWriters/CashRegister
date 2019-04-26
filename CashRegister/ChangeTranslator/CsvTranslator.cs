using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChangeTranslator.Dtos;

namespace ChangeTranslator
{
    public class CsvTranslator
    {
        public void Translate(string filePath, string outputPath, ICurrency currency = null)
        {
            var transactions = CsvToDtos(filePath);
            var changeOutputer = new ChangeOutput(currency);
            var changes = transactions
                .Select(x => changeOutputer.MakeChange(x.Cost, x.Paid, x.RandomChange));
            StringsToCsv(outputPath, changes);
        }

        public IEnumerable<Transaction> CsvToDtos(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                var transactions = new List<Transaction>();
                while (!sr.EndOfStream)
                {
                    var readLine = sr.ReadLine();
                    if (readLine == null) continue;
                    var line = readLine.Split(',');
                    try
                    {
                        transactions.Add(new Transaction(line[0], line[1]));
                    }
                    catch(Exception ex)
                    {
                        throw new ArgumentException("Input file incorrectly formed", ex);
                    }
                }

                return transactions;
            }
        }

        public void StringsToCsv(string outputPath, IEnumerable<string> changes)
        {
            File.WriteAllLines(outputPath, changes.ToArray());
        }
    }
}
