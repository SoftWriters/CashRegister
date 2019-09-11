using DataAccess.Entity;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICurrencyRepository
    {
        List<Currency> LoadAll_SortedByValueDescending();
    }
}
