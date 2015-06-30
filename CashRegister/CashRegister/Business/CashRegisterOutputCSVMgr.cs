using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegisterProject.Business
{
    public class CashRegisterOutputCSVMgr : ICashRegisterOutputMgr
    {
        public bool HandleOutput(string filename, List<string> strList)
        {
            try
            {
                using (var file = new System.IO.StreamWriter(filename))
                {
                    foreach (var line in strList)
                    {
                        file.WriteLine(line);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
