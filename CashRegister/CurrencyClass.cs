using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//Basic class that will hold a unit of money.
//It is over kill for this example problem, 
//but will allow money types to grow more
//complex if the future needs change

namespace CashRegister
{
    class CurrencyClass
    {

        public String Name
        {
            get { return _name; }  
        }
        public String PluralName
        {
            get { return _pluralName; }          
        }
        public Decimal Value
        {
            get { return this._value; }
        }


        public CurrencyClass(String name, String pluralName, Decimal value)
        {
            this._name = name;
            this._pluralName = pluralName;
            this._value = value;
        }

        protected String _name;
        protected String _pluralName;
        protected Decimal _value;
    }
    class ChangeClass : CurrencyClass
    {
        
        public int Amount
        {
            get { return _amount; }           
        }

        public ChangeClass(int amount, CurrencyClass currency) : base(currency.Name, currency.PluralName,currency.Value)
        {
            this._amount = amount;
        }


        int _amount;



        public string getName()
        {
            if (this._amount > 1)
            {
                return this._amount + " " + this._pluralName;
            }
            else
            {
                return this._amount + " " + this._name;
            }
        }


        //Simple utility funciton to add to piles of change together
        internal static List<ChangeClass> Combine(List<ChangeClass> changeList1, List<ChangeClass> changeList2, List<CurrencyClass> currencyList)
        {
            //if either list is empty, exit early
            if (changeList1.Count == 0) return changeList2;
            if (changeList2.Count == 0) return changeList1;

            List<ChangeClass> results = new List<ChangeClass>();
            ChangeClass change1,change2;
            int totalAmount;

            //walk through the possible entries and add them up if they exist. 
            for (int index = 0; index < currencyList.Count; index++)
            {
               change1 = changeList1.Find(coin => coin._value == currencyList[index].Value);
               change2 = changeList2.Find(coin => coin._value == currencyList[index].Value);
               if (change1 != null && change2 != null)
               {
                   totalAmount = change2.Amount + change1.Amount;
               } else if (change1 != null) {
                   totalAmount = change1.Amount;
               } else if (change2 != null) {
                   totalAmount = change2.Amount;
               } else {
                   totalAmount = 0;
               }
               if (totalAmount > 0)
               {
                   ChangeClass change = new ChangeClass(totalAmount, currencyList[index]);
                   results.Add(change);
               }
            }


          
            return results.OrderByDescending(currency => currency.Value).ToList();
        }
    }
}
