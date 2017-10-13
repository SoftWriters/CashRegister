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
                    //FXG_ID,JOB_TITLE,STATE,COUNTRY,COMPANY,AREA,LOCATION_NAME,LOCATION,REGION,REGION_DESC,DISTRICT,DISTRICT_DESC,CO
                    var lineData = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!lineData.Any())
                        continue;

                    yield return new Transaction(lineData.GetField<decimal>(0), lineData.GetField<decimal>(1)); 
                }
            }

        }
	}
}
