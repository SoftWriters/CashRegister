//All of the specific functionality for the cash register program functionality.
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CCDS.res.ctrls.console.io.input;
using CCDS.res.ctrls.console.io.input.exceptions;
using CCDS.res.currency.@base;
using CCDS.res.currency.@base.derived;
using ZBobb;

namespace CCDS.res.calc
{
    class Transaction
    {
        private decimal _changeOwed = 0.00m;
        private List<Currency> money = new List<Currency>();
        private long _bills = 0;
        private decimal _coins = 0.00m;
        private Parser _parser = new Parser();
        public Transaction(AlphaBlendTextBox console, decimal amountPaid, decimal totalDue)
        {
            money = new InternationlCurrencyChooser().Choose(ConfigurationManager.AppSettings["CurrencyCode"]);
            _changeOwed = new SimpleArithmetic().GetDifference(amountPaid, totalDue);
            if (_changeOwed == 0)
                throw new OperandEquationException();
            var _parser = new Parser();
            string [] billsAndCoins = _parser.ParseDecimalIntoBillsAndCoins(_changeOwed);
            _bills = _parser.ParseLong(billsAndCoins[0]);
            _coins = _parser.ParseDecimal(billsAndCoins[1]);
            string[] totalDueInDollarsAndCents = _parser.ParseDecimalIntoBillsAndCoins(totalDue);
            var totalCentsDue = _parser.ParseDecimal(totalDueInDollarsAndCents[1]);
            if (IsTotalCentsDueDivisibleByThree(_parser.ParseLong(totalCentsDue))) TenderRandomPayment();
            else TenderMinimumPayment();
        }
        public List<Currency> GetMoney() => money;
        public bool IsTotalCentsDueDivisibleByThree(long totalDueInCents) => ((new SimpleArithmetic().GetModulus(totalDueInCents, 3) == 0));
        public void TenderMinimumPayment()
        {
            if (_bills > 0) //subtract # of dollars from change if due
            {
                money[0].SetQuantity(money[0].GetQuantity() + _bills);
                _changeOwed -= _bills;
            }
            else
            {
                money.RemoveAt(0);
            }
            if (_coins == 0)
                money = money.Where(monetaryUnit => monetaryUnit.GetQuantity() > 0).ToList();  //remove coins from money list if no cents due
            while (_changeOwed > 0)
            {
                foreach (var monetaryUnit in money.ToList())  //determine minimum change due
                {
                    if (_changeOwed >= monetaryUnit.GetValue())
                    {
                        _changeOwed -= monetaryUnit.GetValue();
                        monetaryUnit.SetQuantity(monetaryUnit.GetQuantity() + 1);
                        break;  //break out of loop
                    }
                    if (monetaryUnit.GetQuantity() < 1)
                        money.Remove(monetaryUnit);
                    else
                        ((Action)(() => { }))(); //noop
                }
            }
        }
        public void TenderRandomPayment()
        {            
            int i= unchecked((int)new SimpleArithmetic().GetRandomNumber(0, (money.Count - 1)));
            while (_bills > 0) 
            {
                long randoNumOfBills = new SimpleArithmetic().GetRandomNumber(0, _bills);  //Random amount of dollars due
                if (randoNumOfBills == 0) continue;
                money[i].SetQuantity((money[i].GetQuantity() + _parser.ParseLong(randoNumOfBills / money[i].GetValue())));  //Putting to rest any owed bills by adding quantities from the number of random bills processed into random denominations of currency
                _bills-= randoNumOfBills;  //Then subtract change owed from number of random bills processed
                i = unchecked((int)new SimpleArithmetic().GetRandomNumber(0, (money.Count - 1))); //grab another rando for next iteration...
            }
            List<Currency> tempCopyOfMoneyArray = new List<Currency>();
            money.ToList().ForEach(monetaryUnit => { tempCopyOfMoneyArray.Add(monetaryUnit);});  //copy array temporarily...
            if (money[0].GetQuantity() == 0)
            {
                tempCopyOfMoneyArray.RemoveAt(0);
                money.RemoveAt(0);  //no more bills left... And dollars wasn't used...
            }
            var cents = _parser.ParseLong((_changeOwed * 100));
            while (cents > 0) //subtract # of dollars from change if due
            {
                long randoNumOfCents = new SimpleArithmetic().GetRandomNumber(0, cents);
                if (randoNumOfCents == 0) continue;//random amount of cents due
                i = unchecked((int)new SimpleArithmetic().GetRandomNumber(0, (money.Count - 1)));
                FindTheRandoThatFits:  //todo refactor this goto away; rather, return from methods containing the loops
                Console.WriteLine("Random Denomination: " + money[i].GetPluralName());
                var monetaryUnitInCents = _parser.ParseLong((money[i].GetValue() * 100));
                if (randoNumOfCents >= monetaryUnitInCents)
                {
                    Console.WriteLine("Putting " + randoNumOfCents + " cents into " + money[i].GetPluralName() + " " + randoNumOfCents + "/" + monetaryUnitInCents + "==" + (randoNumOfCents / monetaryUnitInCents));
                    Console.WriteLine("Adding quantity from number of random coins processed to rando denom: " + money[i].GetQuantity() + " " + money[i].GetPluralName() + " => " + (money[0].GetQuantity() + _parser.ParseLong(randoNumOfCents)));
                    var howManyCoinsWeCanTake = (randoNumOfCents / monetaryUnitInCents);
                    var howMuchWeCanTakeInCents = (howManyCoinsWeCanTake * monetaryUnitInCents);
                    cents -= howMuchWeCanTakeInCents; //remove from the total how many we took
                    money[i].SetQuantity((money[i].GetQuantity() + howManyCoinsWeCanTake)); //Set quantity to how many we can take..
                    tempCopyOfMoneyArray[i].SetQuantity((money[i].GetQuantity())); //and make a backup
                }
                else if (cents >= monetaryUnitInCents) //should we remove it then?
                {
                    if (!((cents - randoNumOfCents) >= monetaryUnitInCents))
                    {
                        //well, we want to remove it after all...
                        if (money[i].GetQuantity() == 0)
                        {
                            money.RemoveAt(i);
                            var temp = tempCopyOfMoneyArray[i];  // swap it to the bottom to account for list variance; otherwise we cannot compare list lengths...
                            tempCopyOfMoneyArray.RemoveAt(i);
                            tempCopyOfMoneyArray.Add(temp);
                        }   
                    }  
                    i = unchecked((int)new SimpleArithmetic().GetRandomNumber(0, (money.Count - 1)));
                    goto FindTheRandoThatFits;
                }
                else
                {
                    if (money[i].GetQuantity() == 0)
                    {
                        money.RemoveAt(i);
                        var temp = tempCopyOfMoneyArray[i];  // swap it to the bottom to account for list variance.
                        tempCopyOfMoneyArray.RemoveAt(i);
                        tempCopyOfMoneyArray.Add(temp);
                    }
                    i = unchecked((int)new SimpleArithmetic().GetRandomNumber(0, (money.Count - 1)));
                    goto FindTheRandoThatFits;
                }
            }
            money = tempCopyOfMoneyArray.ToList().Where(monetaryUnit => (monetaryUnit.GetQuantity() > 0)).ToList();
        }    
    }
}