using System.Collections.Generic;
using CashRegister.BL.Objects;

namespace CashRegister.BL.Services
{
    public interface IReducer
    {
         Denomination Reduce(IList<Denomination> resultList);
    }
}