using System.Collections.Generic;
using CashRegister.BL.Objects;

namespace CashRegister.BL.Reducers
{
    public interface IReducer
    {
         Denomination Reduce(IList<Denomination> resultList);
    }
}