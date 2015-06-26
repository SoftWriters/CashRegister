using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegisterProject;
using CashRegisterProject.Model;
using CashRegisterProject.Business;
using System.IO;
using System.Diagnostics;

namespace CashRegisterTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
       * . Accept a flat file as input
          +	1. Each line will contain the amount owed and the amount paid separated by a comma (for example: 2.13,3.00)
          +	2. Expect that there will be multiple lines
       */
        [TestMethod]
        public void A_ReadInputCSVFile_3ItemsRead()
        {
            // TODO: Fix this
            ICashRegisterInputMgr inputMgr = new CashRegisterInputMgrFactory(MoneyConstants.Infile).GetCashRegisterInputMgr();
            List<TransactionAmounts> transList = inputMgr.HandleInput("C:/Dev/CashRegister/input/crt-test-data.csv");
            Assert.AreEqual(transList.Count, 3);
        }
        /*
            2. Output the change the cashier should return to the customer
                +	1. The return string should look like: 1 dollar,2 quarters,1 nickel, etc ...
                +	2. Each new line in the input file should be a new line in the output file
         */
        [TestMethod]
        public void TestTranslatorFactoryForUSD()
        {
            AbsTranslator trans = new TranslatorFactory().GetTranslator(MoneyConstants.USD);
            Assert.IsInstanceOfType(trans, typeof(TranslatorUSD));
        }
       
        [TestMethod]
        public void B_TestCalculateChange()
        {
            var cr = new CashRegister();


            decimal d = cr.CalculateChange(
                new TransactionAmounts()
                {
                    AmountOwed = 2.12m,
                    AmountPaid = 3.00m
                });

            Assert.AreEqual(d,.88m);
        }

        [TestMethod]
        public void TestTranslatorForDimes()
        {
            AbsTranslator t = new TranslatorUSD();
           string amount = t.TranslateAmount(.2m).ToString();
           Assert.AreEqual(amount,"2 Dimes","The amount was incorrect");
        }

        [TestMethod]
        public void TestTranslatorForQuartersAndDimes()
        {
            AbsTranslator t = new TranslatorUSD();
            string amount = t.TranslateAmount(.7m).ToString();
            Assert.AreEqual(amount, "2 Quarters, 2 Dimes", "The amount was incorrect");
        }

        [TestMethod]
        public void TestTranslatorForDivisibleBy3()
        {
            AbsTranslator t = new TranslatorUSDRandom();
            string amount = t.TranslateAmount(.9m).ToString();
            Assert.AreEqual(amount, "2 Quarters, 2 Dimes", "The amount was incorrect");
        }

        [TestMethod]
        public void TestCRM()
        {
            CashRegisterManager crm = new CashRegisterManager();
            
            crm.ProcessAmounts(new TransactionAmounts()
            {
                AmountOwed = 3.33m,
                AmountPaid = 5m
            });
             
            //1 Dollar, 2 Quarters, 1 Dime, 1 Nickel, 2 Pennies
         }
       
        [TestMethod]
        public void TestTranslatorForMultiple()
        {
            AbsTranslator t = new TranslatorUSD();
            string amount = t.TranslateAmount(3.33m).ToString();
            Assert.AreEqual(amount, "3 Dollars, 1 Quarter, 1 Nickel, 3 Pennies", "The amount was incorrect");

        }
        
        [TestMethod]
        public void TestCashRegisterManagerProcessor_Overpayment()
         {
            CashRegisterManager crm = new CashRegisterManager();
            string str = crm.ProcessAmounts(new TransactionAmounts()
            {
                AmountOwed = 3.33m,
                AmountPaid = 5m
            });
            Assert.AreEqual(str, "1 Dollar, 2 Quarters, 1 Dime, 1 Nickel, 2 Pennies");
                               
         }
        
        [TestMethod]
        public void TestCashRegisterManagerProcessor__Underpayment()
         {
             CashRegisterManager crm = new CashRegisterManager();
             string str = crm.ProcessAmounts(new TransactionAmounts()
             {
                 AmountOwed = 5m,
                 AmountPaid = 3.3m
             });
             Assert.AreEqual(str, "You still owe 1 Dollar, 2 Quarters, 2 Dimes");
         }
        
        [TestMethod]
        public void TestCashRegisterManagerProcessor__Exact()
         {
             CashRegisterManager crm = new CashRegisterManager();
             string str = crm.ProcessAmounts(new TransactionAmounts()
             {
                 AmountOwed = 5m,
                 AmountPaid = 5m
             });
             Assert.AreEqual(str, "You have paid the exact amount");
         }

        [TestMethod]
        public void TestCashRegisterManagerWriteOutput()
        {
            string outFile = "C:/Dev/CashRegister/input/output.csv";
            ICashRegisterOutputMgr outMgr = new CashRegisterOutputMgrFactory(MoneyConstants.Outfile).GetCashRegisterOutputMgr();
            List<string> strList = new List<string>();
            strList.Add("Test1");
            strList.Add("Test2");
            strList.Add("Test3");
            try
            {
                outMgr.HandleOutput(outFile, strList);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            // the actual test...
            int count = 0;
            using (var rd = new StreamReader(outFile))
            {
                while (!rd.EndOfStream)
                {
                    rd.ReadLine();
                    count++;
                }
            }

            Assert.AreEqual(count, 3);
        }
        [TestMethod]
        public void TestTranslatorUSDRandom()
        {
            TranslatorUSDRandom ta = new TranslatorUSDRandom();
            string str = ta.TranslateAmount(6m);
           
            string[] denumAmts = str.Trim().Split(',');
            decimal sum = 0;
            foreach (string s in denumAmts)
            {
                string[] sep = s.Trim().Split(' ');
                decimal trans = 0;

                if (sep[1].Contains("Dollar"))
                {
                    trans = 1.00m * Decimal.Parse(sep[0]);
                }
                else if (sep[1].Contains("Quarter"))
                {
                    trans = .25m * Decimal.Parse(sep[0]);
                }
                else if (sep[1].Contains("Dime"))
                {
                    trans = .1m * Decimal.Parse(sep[0]);
                }
                else if (sep[1].Contains("Nickel"))
                {
                    trans = .05m * Decimal.Parse(sep[0]);
                }
                else
                {
                    trans = .01m * Decimal.Parse(sep[0]);
                }

                sum += trans;
            }
            
            Trace.WriteLine(str);
            Assert.AreEqual(sum,6);
        }
    }

         

         

}
