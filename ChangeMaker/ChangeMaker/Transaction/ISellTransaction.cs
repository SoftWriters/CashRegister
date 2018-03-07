using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    public interface ISellTransaction : ITransaction
    {
        void CalculateChange();
        void DisplayChange();
    }
}
