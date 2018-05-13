using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base(message) { }

        public InvalidTransactionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
