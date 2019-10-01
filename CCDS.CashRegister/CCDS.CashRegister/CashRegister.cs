using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDS.CashRegister
{
    class CashRegister
    {
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();
        private Transaction _lastTransaction;
        private long overpay => _lastTransaction.Payment - _lastTransaction.Cost;
        private bool _isCostDivisibleByThree;
        private long[] _currency;

        public CashRegister(long[] currency)
        {
            _currency = currency;
        }

        //stores previous transactions
        public void AddTransaction(long cost, long payment)
        {
            Transaction exchange = new Transaction(cost, payment);
            _isCostDivisibleByThree = cost % 3 == 0;
            _lastTransaction = exchange;
            Transactions.Add(exchange);
        }

        //returns change (random if divisible by 3) given the overpay of the transaction
        public long[] GiveChange()
        {
            return (_isCostDivisibleByThree) ? ChangeDistributor.DistributeRandomDenominations(overpay, _currency) :
                ChangeDistributor.DistributeNormalDenominations(overpay, _currency);
        }

        //checks to see if values are valid
        public string TransactionErrorMessage(long cost, long payment)
        {
            if (cost < 0)
            {
                return "Error: invalid cost amount!";
            }

            else if (payment < 0)
            {
                return "Error: invalid payment amount!";
            }

            else if (cost > payment)
            {
                return "Error: payment must be greater than or equal to cost.";
            }

            return null;
        }
    }
}