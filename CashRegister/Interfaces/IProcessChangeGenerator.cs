using System.Collections.Generic;

namespace CashRegister.Interfaces
{
    public interface IProcessChangeGenerator
    {
        string OutputChangeToCustomer(List<string[]> inputFileContents);

        string GetMonetaryDenominationsDue(Dictionary<string, decimal> denominationsDictionary, decimal changeDue, bool divisibleByThree);
    }
}