using System;
using System.Collections.Generic;

namespace ChangeCalculator
{
    public class ChangeCalculator
    {
        private IIOHandler _ioHandler;
        private ICalculateChange _minCalculator;
        private ICalculateChange _randomCalculator;

        public ChangeCalculator(IIOHandler ioHandler, ICalculateChange minCalculator, ICalculateChange randomCalculator)
        {
            _ioHandler = ioHandler;
            _minCalculator = minCalculator;
            _randomCalculator = randomCalculator;
        }

        public void CalculateChange()
        {
            string result = "";
            string inputData = _ioHandler.Load();
            List<Amount> amounts = Amount.ParseFromText(inputData);

            foreach (var amount in amounts)
            {
                Change changeAmount;

                if (amount.DivisableByThree())
                {
                    changeAmount = _randomCalculator.CalculateChange(amount);
                }
                else
                {
                    changeAmount = _minCalculator.CalculateChange(amount);
                }
                result = result + changeAmount.ToString() + Environment.NewLine;
            }

            _ioHandler.Save(result);
        }
    }
}
