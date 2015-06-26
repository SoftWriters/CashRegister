
namespace CashRegisterProject.Business
{
    public class CashRegisterOutputMgrFactory
    {
        public CashRegisterOutputMgrFactory() { }
        public CashRegisterOutputMgrFactory(string _type) {
            type = _type;
        }

        readonly string type = "";


        public ICashRegisterOutputMgr GetCashRegisterOutputMgr()
        {
            ICashRegisterOutputMgr outputMgr = null ;
            switch (type)
            {
                case MoneyConstants.Outfile :
                    outputMgr = new CashRegisterOutputCSVMgr();
                    break;
            }
            return outputMgr;
        }
    }
}
