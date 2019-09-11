using DataAccess.Entity;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IDelimitedFileBasicValidationRepository
    {
        List<DelimitedFileValidationRule> LoadAll_ByInputFileType(string inputFileType);
    }
}
