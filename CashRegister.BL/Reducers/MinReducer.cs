using System.Collections.Generic;
using CashRegister.BL.Objects;

namespace CashRegister.BL.Reducers
{
    public class MinReducer : IReducer
    {
        public MinReducer()
        {
        }

        public Denomination Reduce(IList<Denomination> resultList)
        {
            return resultList.MinBy(x => x.TotalCoins);
        }
    }
}