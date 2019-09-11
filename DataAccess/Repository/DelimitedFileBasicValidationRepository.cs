using DataAccess.Entity;
using DataAccess.FakeData.DelimitedFileBasicValidationRule;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DelimitedFileBasicValidationRepository : IDelimitedFileBasicValidationRepository
    {
        public List<DelimitedFileValidationRule> LoadAll_ByInputFileType(string inputFileType)
        {
            List<DelimitedFileValidationRule> lst = new List<DelimitedFileValidationRule>();

            DelimitedFileBasicValidationRuleRow f = null;

            f = new CashTransactionInputFileColumn1();
            lst.Add(new Entity.DelimitedFileValidationRule() { InputFileType = f.InputFileType, ColIndex = f.ColIndex, ExpectedDataType = f.ExpectedDataType, Required = f.Required, MinValue = f.MinValue, MaxValue = f.MaxValue });

            f = new CashTransactionInputFileColumn2();
            lst.Add(new Entity.DelimitedFileValidationRule() { InputFileType = f.InputFileType, ColIndex = f.ColIndex, ExpectedDataType = f.ExpectedDataType, Required = f.Required, MinValue = f.MinValue, MaxValue = f.MaxValue });

            //Mimic a db call.
            return lst.Where(x => x.InputFileType == inputFileType).OrderBy(x => x.ColIndex).ToList();
        }
    }
}