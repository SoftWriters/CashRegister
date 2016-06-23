using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Transaction
    {
        decimal price = 0;
        decimal payment = 0;

        public Transaction(decimal price, decimal payment)
        {
            this.price = price;
            this.payment = payment;          
        }

        public decimal getDiffrence()
        {
            return payment - price;
        }

    }
}
