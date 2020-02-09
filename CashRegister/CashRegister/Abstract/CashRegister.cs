using System;
using System.IO;
using System.Text;

namespace CashRegisterConsumer
{
    public abstract class CashRegister
    {
        private ICurrency _currency;
        private decimal _price, _tender;
        private int _transactionCount; // for future use and current exception handling
        private ITenderStrategy _tenderStrategy;

        public decimal PriceValue { get { return _price; } set { _price = value; } }
        public decimal TenderValue { get { return _tender; } set { _tender = value; } }

        public CashRegister(ICurrency currency, ITenderStrategy tenderStrategy)
        {
            RegisterCurrency(currency);
            RegisterTenderStrategy(tenderStrategy);
        }

        public virtual void RegisterCurrency(ICurrency currency)
        {
            if (currency == null)
                throw new NullReferenceException("Attempt to register a null currency is invalid.");
            if (currency.AllDenominations.Count == 0)
                throw new InvalidCurrencyException($"No denominations found in currency {currency.ToString()}");

            this._currency = currency;
        }

        public virtual void RegisterTenderStrategy(ITenderStrategy tenderStrategy)
        {
            if (tenderStrategy == null)
                throw new NullReferenceException("Attempt to register a null tender strategy is invalid.");

            this._tenderStrategy = tenderStrategy;
        }

        public string Tender(string path)
        {
            // ensure that the path is not null
            if (path == null || path == string.Empty)
                throw new FileNotFoundException("Input file not found.", path);

            // setup our stringbuilder for the response
            StringBuilder tenderedValues = new StringBuilder();
            try
            {
                // using to ensure stream closure
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    // if the file is empty, throw format excpetion with message
                    if (sr.EndOfStream)
                        throw new FormatException($"The file {path} was empty");

                    while (!sr.EndOfStream)
                    {
                        // log transaction count (for exception handling)
                        _transactionCount++;
                        // setup the _price and _tender for this transaction
                        SetTransactionAmounts(sr);
                        // add the transaction calculation based on the strategy to the return string
                        var results = _tenderStrategy.Calculate(_currency, _price, _tender);
                        tenderedValues.Append(_tenderStrategy.Display(_currency));
                    };
                }

                // return the tendered value string for all transactions
                return tenderedValues.ToString();
            }
            catch (FormatException e) // throw a generic message with a more specific inner message.
            {
                throw new FormatException($"The file {path} was not in the correct format", e);
            }
            catch (Exception e) // Is something missed?
            {
                throw e;
            }
        }

        private void SetTransactionAmounts(StreamReader sr)
        {
            try
            {
                // reset for new transaction
                _currency.Clear();
                _price = _tender = 0;

                // read the next line and set the _price and _tender
                // NOTE: I used the Parse over TryParse to ensure non-numeric values throw an exception
                var input = sr.ReadLine();
                _price = Decimal.Parse(input.Split(",")[0]);
                _tender = Decimal.Parse(input.Split(",")[1]);

                if (_tender <= 0 || _price <= 0)
                    throw new InvalidCurrencyException($"Invalid negative currency. Please review line {_transactionCount} for errors.");

                // ensure there is enough tender for the price. (they can be equal)
                if (_tender < _price)
                    throw new NotEnoughTenderException($"Tender value less than price. Deficiency: {_price - _tender} on line {_transactionCount}");
            }
            catch (OverflowException e)
            {
                throw new InvalidCurrencyException($"Invalid input. Please review line {_transactionCount} for errors.", e);
            }
            catch (NotEnoughTenderException e)
            {
                throw new NotEnoughTenderException($"Please review line {_transactionCount} for errors", e);
            }
            catch (Exception e)
            {
                throw new FormatException(String.Format("{0} : Line {1}", e.Message, _transactionCount));
            }
        }
    }
}