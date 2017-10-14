using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using CashRegister.BL.Objects;
using System.IO;

namespace CashRegister.BL.Services
{
	public class InputFile : IInputSource
	{
        private string _file;
        public InputFile(string file) {
            if(string.IsNullOrEmpty(file))
                throw new ArgumentNullException("file");
            _file = file;
        }
        public IEnumerable<Transaction> LoadData() 
        {
            if (!File.Exists(_file))
                throw new FileNotFoundException("File not found");

            using (var reader = new StreamReader(_file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
                    var lineData = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!lineData.Any())
                        continue;
                    var owed = lineData.GetField<decimal>(0);
                    var paid =lineData.GetField<decimal>(1);
                    yield return new Transaction(owed, paid); 
                }
            }

        }
	}
}
