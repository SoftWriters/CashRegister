using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CashRegister
{
    class Process
    {

        int twentyDollarBills = 0;
        int tenDollarBills = 0;
        int fiveDollarBills = 0;
        int oneDollarBills = 0;
        int quarters = 0;
        int dimes = 0;
        int nickels = 0;
        int pennies = 0;

        public string Response(string input)
        {
            string response = FormReplies(
                WhatIsOwed(
                    FormatValues(input)));
            //Honestly this might be best as 3 calls w/ 3 varibles. I've heard endless arugments for both sides.
            //I'm of no oppinion at this time.

            return response;
        }

        public List<Transaction> FormatValues(string inputString)
        {
            List<Transaction> transactions = new List<Transaction>();

            string[] lines = Regex.Split(inputString, "\r\n");

            foreach (string line in lines)
            {
                string[] values = Regex.Split(line, ",");

                if (line.Length > 0) //I'm sure there is a more elegant way to error trap, but this works.
                {
                    transactions.Add(new Transaction(Convert.ToDecimal(values[0]), Convert.ToDecimal(values[1])));
                }
            }

            return transactions;
        }

        List<decimal> WhatIsOwed(List<Transaction> transactions)
        {
            List<decimal> answer = new List<decimal>();

            foreach (Transaction transaction in transactions)
            {
                answer.Add(transaction.getDiffrence());               
            }

            return answer;
        }

        string FormReplies(List<Decimal> amountOwed)
        {
            //so here we are going to output the change using the largest currency possible first, unless its divisible by 3.
            //the output format will be in the sense of 2 dollars, 4 dimes, 2 pennies. 
            //Personally I would like a sentence along the lines of for your N$ purchase you gave me X$ and your change is [output]
            //I may just make that as well.             
            string reply = string.Empty;

            foreach (decimal amount in amountOwed)
            {
                selectCurrency(amount);
                reply += (Reply());
                
            }

            return reply;
        }

        string Reply()
        {
            string reply = string.Empty;


            if (twentyDollarBills > 0)
            {
                reply += ", " + twentyDollarBills + " twenties";
            }
            if (tenDollarBills > 0)
            {
                reply += ", " +  tenDollarBills + " tens";
            }
            if (fiveDollarBills > 0)
            {
                reply += ", " +  fiveDollarBills + " fives";
            }
            if (oneDollarBills > 0)
            {
                reply += ", " + oneDollarBills + " ones ";
            }
            if (quarters > 0)
            {
                reply += ", " + quarters + " quarters";
            }
            if (dimes > 0)
            {
                reply += ", " +  dimes + " dimes";
            }
            if (nickels > 0)
            {
                reply += ", " +  nickels + " nickels";
            }
            if (pennies > 0)
            {
                reply += ", " + pennies + " pennies";
            }

            reply = reply.TrimStart(',');
            reply += Environment.NewLine;
            reply += Environment.NewLine;
            //I"m going off spec here just b/c its a nightmare to read otherwise. Sorry.   

            ClearValues();

            return reply;
        }

        void ClearValues()
        {
            //should of probally made an object of these.
            twentyDollarBills = 0;
            tenDollarBills = 0;
            fiveDollarBills = 0;
            oneDollarBills = 0;
            quarters = 0;
            dimes = 0;
            nickels = 0;
            pennies = 0;

        }  
         
        void selectCurrency(decimal amount)
        {
            //I hate having an always pass bool. 90% of the cases a () makes more sense.
            //Isuppose it could be considered bad to hide the randomness function...
            bool random = ((amount % 3) == 0);

            selectCurrency(amount, random);
        }

        void selectCurrency(decimal amount, bool randomly)
        {
            //SO honestly I'm not proud of this function.. at all. 
            //but I've thought for far to long on how to do this better :/ 
            //So now I'm going to just make it work.

            if (!randomly) //this large block is the part that really needs the refactor.
            {
                if (amount >= 20)
                {
                    amount =  RemoveTwenty(amount);
                }
                else if (amount >= 10)
                {
                    amount =  RemoveTen(amount);
                }
                else if (amount >= 5)
                {
                    amount =  RemoveFive(amount);
                }
                else if (amount >= 1)
                {
                    amount =  RemoveOne(amount);
                }
                else if (amount >= 0.25m)
                {
                    amount =  RemoveQuarter(amount);
                }
                else if (amount >= 0.1m)
                {
                    amount =  RemoveDime(amount);
                }
                else if (amount >= .05m)
                {
                    amount = RemoveNickel(amount);
                }
                else if (amount >= .01m)
                {
                   amount = RemovePenny(amount);
                }

            }
            else
            {
                Random rnd = new Random();
                //Note because of the way this is set up it COULD go on for infinity. but lets be honest, it wont.

                switch (rnd.Next(1, 8)) //This is the worst part. We need some sort of collection that expands as supported bill types increases.
                {
                    case 1:

                        if (amount >= 20)
                        {
                            amount = RemoveTwenty(amount);
                        }     
                                          
                        break;
                    case 2:

                        if (amount >= 10)
                        {
                            amount = RemoveTen(amount);
                        }        
                                
                        break;
                    case 3:

                        if (amount >= 5)
                        {
                            amount = RemoveFive(amount);
                        }      
                                         
                        break;
                    case 4:

                        if (amount >= 1)
                        {
                            amount = RemoveOne(amount);
                        }                        

                        break;
                    case 5:

                        if (amount >= 0.25m)
                        {
                            amount = RemoveQuarter(amount);
                        }             

                        break;
                    case 6:

                        if (amount >= 0.1m)
                        {
                            amount = RemoveDime(amount);
                        }
                        
                        break;
                    case 7:

                        if (amount >= .05m)
                        {
                            amount = RemoveNickel(amount);
                        }

                        break;
                    case 8:

                        if (amount >= .01m)
                        {
                            amount = RemovePenny(amount);
                        }

                            break;
                    default:
                        //this shouldnt happen but its good practice to toss this kid in here.
                        break;
                }

            }


            if (amount > 0)
            {
                selectCurrency(amount, randomly);
            }

            
        }

#region RemoveAmountFunctions
        //I"m not seeing it but there must be a better way.
        //error trapping could include making suer no negative number.
        //this honestly could be a class remove currency then go from there.
        decimal RemoveTwenty(decimal amount)
        {
            twentyDollarBills++;
            amount = amount - 20;
            return amount;
        }
        decimal RemoveTen(decimal amount)
        {
            tenDollarBills++;
            amount = amount - 10;
            return amount;
        }
        decimal RemoveFive(decimal amount)
        {
            fiveDollarBills++;
            amount = amount - 5;
            return amount;
        }
        decimal RemoveOne(decimal amount)
        {
            oneDollarBills++;
            amount = amount - 1;
            return amount;
        }
        decimal RemoveQuarter(decimal amount)
        {
            quarters++;
            amount = amount - 0.25m;
            return amount;
        }
        decimal RemoveDime(decimal amount)
        {
            dimes++;
            amount = amount - .1m;
            return amount;
        }
        decimal RemoveNickel(decimal amount)
        {
            nickels++;
            amount = amount - 0.05m;
            return amount;
        }
        decimal RemovePenny(decimal amount)
        {
            pennies++;
            amount = amount - .01m;
            return amount;
        }
        #endregion

    }//process


}
