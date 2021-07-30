using System.Collections.Generic;
using ChangeTranslator.Dtos;

namespace ChangeTranslator.Tests.TestObjects
{
    public class TestCurrency : ICurrency
    {
        public IEnumerable<Denomination> Denominations { get; set; }
        public string NoChangePhrase { get; set; }
    }
}
