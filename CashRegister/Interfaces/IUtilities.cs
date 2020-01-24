using System.Collections.Generic;

namespace CashRegister.Interfaces
{
    public interface IUtilities
    {
        string ReplaceWithPlurals(string p);

        Dictionary<string, decimal> GenerateDenominationsDictionary();

        Dictionary<string, decimal> RandomizeDenominationsDictionary(Dictionary<string, decimal> denominationsDictionary);
    }
}