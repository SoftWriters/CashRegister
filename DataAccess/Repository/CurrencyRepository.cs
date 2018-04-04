using DataAccess.Entity;
using DataAccess.FakeData.Currency;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public List<Currency> LoadAll_SortedByValueDescending()
        {
            List<Currency> lst = new List<Currency>();

            CurrencyRow f = null;
            
            f = new Penny();
            lst.Add(new Entity.Currency() { Value = f.Value, SingularDescription = f.SingularDescription, PluralDescription = f.PluralDescription });       

            f = new Nickel();
            lst.Add(new Entity.Currency() { Value = f.Value, SingularDescription = f.SingularDescription, PluralDescription = f.PluralDescription });

            f = new Dime();
            lst.Add(new Entity.Currency() { Value = f.Value, SingularDescription = f.SingularDescription, PluralDescription = f.PluralDescription });

            f = new Quarter();
            lst.Add(new Entity.Currency() { Value = f.Value, SingularDescription = f.SingularDescription, PluralDescription = f.PluralDescription });

            f = new Dollar();
            lst.Add(new Entity.Currency() { Value = f.Value, SingularDescription = f.SingularDescription, PluralDescription = f.PluralDescription });

            return lst.OrderByDescending(x => x.Value).ToList();
        }
    }
}