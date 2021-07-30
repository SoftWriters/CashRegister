using System.Collections.Generic;

namespace ChangeTranslator.Dtos
{
    public interface ICurrency
    {
        IEnumerable<Denomination> Denominations { get; }
        string NoChangePhrase { get; }
    }
}
