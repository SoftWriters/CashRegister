using System.Collections.Generic;
using CashRegister.BL.Objects;

namespace CashRegister.BL.Services
{
    public class RandomReducer : IReducer
    {
        public RandomReducer()
        {
        }

        public Denomination Reduce(IList<Denomination> resultList)
        {
            return resultList.Random();
        }
    }
}