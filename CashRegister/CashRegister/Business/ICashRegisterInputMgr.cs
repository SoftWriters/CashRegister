using System.Collections.Generic;
using CashRegisterProject.Model;

namespace CashRegisterProject.Business
{
    public interface ICashRegisterInputMgr
    {
         List<TransactionAmounts> HandleInput(string infile);
    }
    
}
