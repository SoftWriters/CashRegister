using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Basic class that will hold a transaction.
//It is over kill for this example problem, 
//but will allow transactions to grow more
//complex if the future needs change

namespace CashRegister
{
    class TransactionClass
    {        
        public Decimal Charges
        {
            get { return _charges; }
        }

        public Decimal Payment
        {
            get { return _payment; }            
        }

        public TransactionClass(Decimal charges, Decimal payment)
        {
            this._charges = charges;
            this._payment = payment;
        }

        public List<ChangeClass> ProcessTransaction(List<CurrencyClass> currencyList)
        {
            //I am assuming no factional money 
            //for this odd requirement of random change
            Decimal change = this._payment - this._charges;

            //first check for the invalid cases
            if (change == 0)
            {
                return null;
            }
            if (this._payment < 0 || this._charges < 0) throw new Exception("Bad transaction data!"); 
            if (change < 0) throw new Exception("Charges exceed payment!");            

            //Split change routines pending if divisible by 3.
            //NOTE: 0 % 3 = 0, but I am assuming that is NOT a case where we want random change
            if (_charges > 0 && (_charges*100) % 3 == 0)
            {
                return makeRandomChange(change,currencyList);
            }
            else
            {
                return makeChange(change,currencyList);
            }
        }

        private List<ChangeClass> makeRandomChange(decimal change, List<CurrencyClass> currencyList)
        {

            //Deciding what "random change" meant was a bit of a challenge. I decided to go with
            //take a random amount of money from the change and turn that in to coins. Then take
            //a random bit more and do it again. I continue this process until all the money
            //is accounted for. 


            Random random = new Random();
            List<ChangeClass> results = new List<ChangeClass>();
            List<ChangeClass> stepResults = new List<ChangeClass>();

            decimal partChange = random.Next(1, Convert.ToInt32(Decimal.Round(change*100)));

            while (change > 0)
            {
                stepResults = makeChange(partChange / 100, currencyList);
                change = change - (partChange/100);                
                results = ChangeClass.Combine(results, stepResults, currencyList);
                if (change > 0) partChange = random.Next(1, Convert.ToInt32(Decimal.Round(change * 100)));
            }
            return results;
        }

        private List<ChangeClass> makeChange(Decimal change,List<CurrencyClass> currencyList)
        {
            List<ChangeClass> results = new List<ChangeClass>();
           
            foreach (CurrencyClass currency in currencyList)
            {
                //since the list is sorted, we can just start at the top and work down
                
                int units = 0;
                if (currency.Value > change)
                {
                    continue; //nothing to do for this amount
                }
                else
                {
                    //do the math as integers to capture the whole numbers
                    int changeInt = Convert.ToInt32(Decimal.Round(change*100));
                    int valueInt = Convert.ToInt32(Decimal.Round(currency.Value*100));
                    units = changeInt / valueInt;
                    results.Add(new ChangeClass(units,currency));
                    change = change - units * currency.Value;
                }
            }

            return results;
        }




        private Decimal _charges = 0.00m;
        private Decimal _payment = 0.00m;
    }


}
