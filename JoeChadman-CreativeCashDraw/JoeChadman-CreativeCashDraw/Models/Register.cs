using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper;

namespace JoeChadman_CreativeCashDraw.Models
{
    public class Register
    {
        public decimal AmtOwed { get; set; }
        public decimal AmtPaid { get; set; }

        public bool RandomChange {
            get { return (this.AmtOwed * 100 % 3 == 0) ? true : false; }
        }

        public decimal AmtChange
        {
            get { return this.AmtPaid - this.AmtOwed; }
        }

        public string Change { 
            get {
                return getChange();
            }
        }


        private string getChange()
        {
            string returnChange = null;
            int cents = (int)(Math.Round(this.AmtChange, 2) * 100);

            var currency = new[] { 
                new { NameSingle = "Twenty Dollar Bill", NamePlural = "Twenty Dollar Bills", Value = 2000 }, new { NameSingle = "Ten Dollar Bill", NamePlural = "Ten Dollar Bills", Value = 1000 }, 
                new { NameSingle = "Five Dollar Bill", NamePlural = "Five Dollar Bills", Value = 500 }, new { NameSingle = "One Dollar Bill", NamePlural = "One Dollar Bills", Value = 100 }, 
                new { NameSingle = "Quarter", NamePlural = "Quarters", Value = 25 }, new { NameSingle = "Dime", NamePlural = "Dimes", Value = 10 }, 
                new { NameSingle = "Nickel", NamePlural = "Nickels", Value = 5 }, new { NameSingle = "Penny", NamePlural = "Pennies", Value = 1 } };


            //calculate change needed
            if(cents < 0)
            {
                //Not enough money tendered
                returnChange = "$" + this.AmtChange * -1 + " still needed to pay off amount owed";
            }
            else if (cents == 0)
            {
                //No change needed
                returnChange =  "No changed";
            }
            else if (cents > 0)
            {
                if (!this.RandomChange)
                {
                    var change = currency.Select(coin => new { Amt = Math.DivRem(cents, coin.Value, out cents), Coin = coin })
                                .Where(x => x.Amt != 0).ToList();

                    change.ForEach(x =>
                            returnChange += x.Amt > 1 ? x.Amt + " " + x.Coin.NamePlural + ", " : x.Amt + " " + x.Coin.NameSingle + ", "
                        );
                }
                else
                {
                    //returnChange = "TO DO: Calcualte Random Change";
                    while (cents > 0)
                    {
                        //pick a random currency
                        var wipCurrency = currency[new Random().Next(currency.Length)];

                        //make sure randum currency is not larger than change needed
                        if (wipCurrency.Value < cents)
                        {
                            //how much of selected currency to use
                            double wipNumCurrency = cents / wipCurrency.Value;
                            wipNumCurrency = Math.Floor(wipNumCurrency);


                            returnChange += wipNumCurrency > 1 ? wipNumCurrency + " " + wipCurrency.NamePlural + ", " : wipNumCurrency + " " + wipCurrency.NameSingle + ", ";

                            cents -= (int)wipNumCurrency * wipCurrency.Value;
                        }
                    }
                }

                //format return change string
                returnChange = returnChange.Substring(0, returnChange.Length - 2);
            }
           
            
            return returnChange;
        }

    }
}