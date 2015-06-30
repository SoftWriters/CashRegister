
namespace CashRegisterProject.Business
{
    public class CashRegisterInputMgrFactory
    {

        public CashRegisterInputMgrFactory() { }
        public CashRegisterInputMgrFactory(string _type)
        {
            type = _type;

        }
        string type = "";
        public ICashRegisterInputMgr GetCashRegisterInputMgr()
        {
            ICashRegisterInputMgr inputMgr = null;
            switch (type)
            {
                case MoneyConstants.Infile:
                    inputMgr = new CashRegisterInputCSVMgr();
                    break;

            }
            return inputMgr;
        }
    }
}
