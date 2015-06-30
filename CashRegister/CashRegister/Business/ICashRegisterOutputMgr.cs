using System.Collections.Generic;

namespace CashRegisterProject.Business
{
    public interface ICashRegisterOutputMgr
    {
        bool HandleOutput(string filename, List<string> strList);

    }
    
}
