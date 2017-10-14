using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using CashRegister.BL.Objects;
using System.IO;

namespace CashRegister.BL.Services
{
	public class OutputFile : IOutputSource
	{
        private string _file;
        public OutputFile(string file) {
            if(string.IsNullOrEmpty(file))
                throw new ArgumentNullException("file");
            _file = file;
        }

        public bool SaveData(IList<Denomination> dataList) 
        {

            var builder = new StringBuilder();
            foreach(var data in dataList)
            {
                builder.AppendLine(data.ToString());
            }
            File.WriteAllText(_file, builder.ToString());
            return true;
        }
        /**
3 quarters,1 dime,3 pennies

3 pennies

1 dollar,1 quarter,6 nickels,12 pennies
        
         */
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
