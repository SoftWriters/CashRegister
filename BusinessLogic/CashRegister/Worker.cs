using BusinessLogic.DTO.CashRegister;
using BusinessLogic.Extensions;
using DataAccess.Entity;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic.CashRegister
{
    public class Worker
    {
        #region Constructor
        public Worker (ICurrencyRepository curRepos, IDelimitedFileBasicValidationRepository delimitedFileValidationRepos)
        {
            this._currencyRepository = curRepos;
            this._delimitedFileValidationRepository = delimitedFileValidationRepos;
        }
        #endregion

        #region Variables/Events          
        private readonly ICurrencyRepository _currencyRepository = null;
        private readonly IDelimitedFileBasicValidationRepository _delimitedFileValidationRepository = null;
        #endregion

        #region Properties          
        #endregion

        #region Methods
        /// <summary>
        /// Import a transaction file.
        /// </summary>
        /// <param name="pathFile">Path and file name to import.</param>
        /// <param name="randomizeChangeWhenDivisibleBy">Null or a number.</param>
        /// <returns></returns>
        public CashTransactionImportResult LoadTransactionData(string pathFile, int? randomizeChangeWhenDivisibleBy)
        {
            CashTransactionImportResult res = new CashTransactionImportResult(pathFile);

            List<Currency> allCurrency = this._currencyRepository.LoadAll_SortedByValueDescending();
            Currency dollar = allCurrency.Where(x => x.Value == 1).FirstOrDefault();
            List<Currency> coins = allCurrency.Where(x => x.Value != 1).ToList();

            List<DelimitedFileValidationRule> valRules = this._delimitedFileValidationRepository.LoadAll_ByInputFileType("CashTransaction");

            //Process file
            string line = "";
            int lineNum = 0;

            using (StreamReader sr = new StreamReader(pathFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    lineNum++;

                    if (!String.IsNullOrEmpty(line))
                    {
                        string[] rawValues = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        List<string> lineErrors = this.ValidateRawTransaction(rawValues, lineNum, valRules);
                        if (lineErrors.Count == 0)
                        {
                            decimal owed = Convert.ToDecimal(rawValues[0]);
                            decimal paid = Convert.ToDecimal(rawValues[1]);
                            decimal changeDue = paid - owed;

                            if (changeDue < 0)
                            {
                                res.ErrorMessages.Add("Line: " + lineNum.ToString() + ". The change owed is less than zero.");
                            }
                            else
                            {
                                string changeVerbose = this.ConvertChange_ToVerbose(owed, changeDue, randomizeChangeWhenDivisibleBy, allCurrency, dollar, coins);
                                res.ValidTransactions.Add(new CashTransactionDTO(owed, paid, changeDue, changeVerbose));
                            }
                        }
                        else
                        {
                            res.ErrorMessages.AddRange(lineErrors);
                        }

                        Array.Clear(rawValues, 0, rawValues.Length);
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Validate a line of the input file.
        /// </summary>
        /// <param name="rawValues">Array of values from this line.</param>
        /// <param name="lineNum">Current line # (1 based)</param>
        /// <param name="valRules"></param>
        /// <returns>List of errors if invalid, empty list if valid.</returns>
        private List<string> ValidateRawTransaction(string[] rawValues, int lineNum, List<DelimitedFileValidationRule> valRules)
        {
            List<string> errList = new List<string>();

            if (rawValues.Length != valRules.Count)
            {
                errList.Add("Line: " + lineNum.ToString() + ". Invalid number of columns found. Expected: " + valRules.Count.ToString() + " found: " + rawValues.Length.ToString());
            }
            else
            {
                for (int x = 0; x < rawValues.Length; x++)
                {
                    DelimitedFileValidationRule rule = valRules.Where(y => y.ColIndex == x).SingleOrDefault();
                    if (rule != null)
                    {
                        string rawValue = rawValues[x].Trim();
                        if (String.IsNullOrEmpty(rawValue))
                        {
                            if (rule.Required)
                            {
                                errList.Add("Line: " + lineNum.ToString() + ". Missing required value in column " + (x + 1).ToString() + ".");
                            }
                        }
                        else
                        {
                            //Datatype
                            if (rule.ExpectedDataType == typeof(decimal))
                            {
                                decimal testValue = 0;
                                if (Decimal.TryParse(rawValue, out testValue))
                                {
                                    //Min Max
                                    if (rule.MinValue != null)
                                    {
                                        if (testValue < rule.MinValue)
                                        {
                                            errList.Add("Line: " + lineNum.ToString() + ". Data in column: " + (x + 1).ToString() + " is less than the minimum permitted value of " + rule.MinValue.ToString() + ".");
                                        }
                                    }

                                    if (rule.MaxValue != null)
                                    { 
                                        if (testValue > rule.MaxValue)
                                        {
                                            errList.Add("Line: " + lineNum.ToString() + ". Data in column: " + (x + 1).ToString() + " is greater than the maximum permitted value of " + rule.MaxValue.ToString() + ".");
                                        }
                                    }
                                }
                                else
                                {
                                    errList.Add("Line: " + lineNum.ToString() + ". Invalid data in column: " + (x + 1).ToString() + ".");
                                }
                            }
                            else
                            {
                                throw new NotImplementedException("Unhandled datatype found " + rule.ExpectedDataType.ToString());
                            }
                        }
                    }
                    else
                    {
                        errList.Add("Line: " + lineNum.ToString() + ". Unable to find validation rule for column index: " + (x + 1).ToString());
                    }
                }
            }

            return errList;
        }

        /// <summary>
        /// Convert the numerical change owed to a user friendly description. Ex: 3 quarters,1 dime,3 pennies
        /// </summary>
        /// <param name="owedAmount">Original amount owed.</param>
        /// <param name="changeAmount">Total change amount owed.</param>
        /// <param name="useRandomLogicDivisibleBy"></param>
        /// <param name="allCurrency">All currency types.</param>
        /// <param name="dollars">Dollar currency type if we have one setup.</param>
        /// <param name="coins">Coin currency types.</param>
        /// <returns></returns>
        private string ConvertChange_ToVerbose(decimal owedAmount, decimal changeAmount, int? useRandomLogicDivisibleBy,
            List<Currency> allCurrency, Currency dollar, List<Currency> coins)
        {
            List<Currency> appliedCurrencyList = new List<Currency>();  //Running tally of how we break the change down.

            if (useRandomLogicDivisibleBy != null && owedAmount.IsDivisibleByNum((int)useRandomLogicDivisibleBy))
            {
                //Exhaust whole dollars first.
                if (dollar != null)
                {
                    changeAmount = this.ApplyCurrency(changeAmount, dollar, appliedCurrencyList, true);
                }

                //Use random logic to randomly pick type of coins and the number of coins.
                if (changeAmount > 0)
                {
                    Random coinTypeR = new Random();
                    Random numCoinsR = new Random();

                    while (changeAmount > 0)
                    {
                        Currency coin = coins[coinTypeR.Next(0, coins.Count)];

                        int numCoins = numCoinsR.Next(1, coin.MaxPerDollar + 1);
                        for (int x = 1; x <= numCoins; x++)
                        {
                            changeAmount = this.ApplyCurrency(changeAmount, coin, appliedCurrencyList, false);
                            if (changeAmount <= 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                //Use standard logic.  (allCurrency is sorted by value descending)
                foreach(Currency c in allCurrency)
                {
                    changeAmount = this.ApplyCurrency(changeAmount, c, appliedCurrencyList, true);
                }
            }

            //We have a list of dollars and coins used to make change, now count them and convert to text.
            string formattedValue = "";

            var rolledUpList = appliedCurrencyList.GroupBy(x => x.Value)
                .Select(g => new { CurrTypeValue = g.Key, NumUsed = g.Count() })
                .OrderByDescending(x => x.CurrTypeValue).ToList();
            foreach (var currencyType_NumUsed in rolledUpList)
            {
                //Find matching currency type in our memory list.
                Currency cc = allCurrency.Where(x => x.Value == currencyType_NumUsed.CurrTypeValue).Single();

                if (String.IsNullOrEmpty(formattedValue))
                {
                    formattedValue = currencyType_NumUsed.NumUsed.ToString() + " " + (currencyType_NumUsed.NumUsed == 1 ? cc.SingularDescription : cc.PluralDescription);
                }
                else
                {
                    formattedValue += "," + currencyType_NumUsed.NumUsed.ToString() + " " + (currencyType_NumUsed.NumUsed == 1 ? cc.SingularDescription : cc.PluralDescription);
                }
            }

            return formattedValue;
        }

        /// <summary>
        /// Subtract the passed currency from the changed owed.
        /// </summary>
        /// <param name="changeOwed">Change owed we need to process until we hit zero.</param>
        /// <param name="currency">Type of currency to apply to change owed.</param>
        /// <param name="appliedCurrencyList">Running tally of the type of currency we've subtracted from the change owed.</param>
        /// <param name="runOut">Subtract as much money as possible using this currency type.</param>
        /// <returns>Changed owed less currency just applied.</returns>
        private decimal ApplyCurrency(decimal changeOwed, Currency currency, List<Currency> appliedCurrencyList, bool runOut)
        {
            if (runOut)
            {
                while (changeOwed >= currency.Value)
                {
                    appliedCurrencyList.Add(currency);
                    changeOwed -= currency.Value;
                }
            }
            else
            {
                if (changeOwed >= currency.Value)
                {
                    appliedCurrencyList.Add(currency);
                    changeOwed -= currency.Value;
                }
            }

            return changeOwed;
        }

        /// <summary>
        /// Export transaction results to flat file.
        /// </summary>
        /// <param name="path">Path to export to.</param>
        /// <param name="fileName">File name to create.</param>
        /// <param name="obj">Object containing transaction results.</param>
        /// <returns>Path + File created.</returns>
        public string ExportData(string path, string fileName, CashTransactionImportResult obj)
        {
            using (StreamWriter sw = new StreamWriter(path + fileName))
            {
                foreach (var t in obj.ValidTransactions)
                {
                    sw.WriteLine(t.Change_Formatted_Verbose);
                }
            }
            return path + fileName;
        }
        #endregion
    }
}