using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileHelpers;

namespace CashRegister
{
    public interface ICashTransactionFileIOService
    {
        List<CashTransaction> ReadFile(string filename);
        void WriteFile(string filename, List<CashTransaction> cashTransactions);
    }

    // Class that handles file i/o. The interface it implements exposes two methods.
    //
    // The ReadFile method 
    public class CashTransactionFileIOService :ICashTransactionFileIOService
    {
        // Mapper class for the FileHelper engine for parsing the csv.
        [DelimitedRecord(",")]
        private class MappedCashTransaction
        {
            public decimal AmountOwed;
            public decimal AmountPaid;
        }

        public List<CashTransaction> ReadFile(string filename)
        {
            var engine = new FileHelperEngine<MappedCashTransaction>();
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            var records = engine.ReadFile(filename);

            int numberOfLines = records.Length + engine.ErrorManager.ErrorCount;
            List<bool> linesHaveErrors = new List<bool>();
            for (int i = 0; i < numberOfLines; ++i)
            {
                linesHaveErrors.Add(false);
            }

            foreach (var err in engine.ErrorManager.Errors)
            {
                linesHaveErrors[err.LineNumber - 1] = true;
                Console.WriteLine();
            }

            List<CashTransaction> result = new List<CashTransaction>();
            int errorsArrayIndex = 0;
            int recordsArrayIndex = 0;
            for (int i = 0; i < numberOfLines; ++i)
            {
                if (linesHaveErrors[i])
                {
                    var err = engine.ErrorManager.Errors[errorsArrayIndex];
                    errorsArrayIndex += 1;

                    Console.WriteLine("Error on Line number: {0}", err.LineNumber);
                    Console.WriteLine("Record causing the problem: {0}", err.RecordString);
                    Console.WriteLine("Complete exception information: {0}", err.ExceptionInfo.ToString());
                }
                else
                {
                    var record = records[recordsArrayIndex];
                    recordsArrayIndex += 1;

                    decimal amountOwed = record.AmountOwed, amountPaid = record.AmountPaid;
                    if (amountOwed <= 0.0m)
                    {
                        Console.WriteLine("Error on Line number: {0}", i + 1);
                        Console.WriteLine("Record causing the problem: amountOwed");
                        Console.WriteLine("Complete exception information: amountOwed is less than or equal to 0.0");
                    }
                    else if (amountPaid <= 0.0m)
                    {
                        Console.WriteLine("Error on Line number: {0}", i + 1);
                        Console.WriteLine("Record causing the problem: amountPaid");
                        Console.WriteLine("Complete exception information: amountPaid is less than or equal to 0.0");
                    }
                    else if (amountOwed > amountPaid)
                    {
                        Console.WriteLine("Error on Line number: {0}", i + 1);
                        Console.WriteLine("Record causing the problem: amountOwed");
                        Console.WriteLine("Complete exception information: amountOwed is greater than amountPaid");
                    }
                    else if (!HasLessThanThreeDecimalPlaces(amountOwed))
                    {
                        Console.WriteLine("Error on Line number: {0}", i + 1);
                        Console.WriteLine("Record causing the problem: amountOwed");
                        Console.WriteLine("Complete exception information: amountOwed has more than two decimal places");
                    }
                    else if (!HasLessThanThreeDecimalPlaces(amountPaid))
                    {
                        Console.WriteLine("Error on Line number: {0}", i + 1);
                        Console.WriteLine("Record causing the problem: amountPaid");
                        Console.WriteLine("Complete exception information: amountPaid has more than two decimal places");
                    }
                    else
                    {
                        result.Add(new CashTransaction(
                            ConvertToPenniesFrom(amountOwed),
                            ConvertToPenniesFrom(amountPaid)
                            ));
                    }
                }
            }
            return result;
        }

        public bool HasLessThanThreeDecimalPlaces(decimal moneyAsDollarsAsDecimal)
        {
            string s = moneyAsDollarsAsDecimal.ToString();
            return s.Substring(s.IndexOf(".") + 1).Length < 3;
        }

        public int ConvertToPenniesFrom(decimal moneyInDollarsAsDecimal)
        {
            string moneyAsString = moneyInDollarsAsDecimal.ToString();
            int indexOfDecimalPoint = moneyAsString.IndexOf('.');
            string centsAsString = "";
            int dollars = 0;
            if (indexOfDecimalPoint < 0)
            {
                dollars = int.Parse(moneyAsString);
            }
            else
            {
                dollars = int.Parse(moneyAsString.Substring(0, moneyAsString.IndexOf(".")));
                centsAsString = moneyAsString.Substring(moneyAsString.IndexOf(".") + 1);
            }

            int cents = 0;
            // Cents when converted from a decimal string don't always make "sense."
            // E.g. 0.2 dollars is 20 cents, but when directly converted to an int,
            // would be 2 cents. If the length of the decimal string is 1, it needs
            // to be multiplied by 10, otherwise it will be incorrect.
            if (centsAsString.Length == 2)
            {
                cents = int.Parse(centsAsString);
            }
            else if (centsAsString.Length == 1)
            {
                cents = int.Parse(centsAsString) * 10;
            }
            return dollars * 100 + cents;
        }

        public void WriteFile(string filename, List<CashTransaction> cashTransactions)
        {
            using (TextWriter tr = CreateWriter(filename))
            {
                foreach (var cashTransaction in cashTransactions)
                {
                    string change = cashTransaction.GetChangeAsString();
                    if (change.Length > 0)
                    {
                        tr.WriteLine(change);
                    }
                }
            }
        }

        public TextWriter CreateWriter(string filename)
        {
            return new StreamWriter(filename);
        }


    }

}

