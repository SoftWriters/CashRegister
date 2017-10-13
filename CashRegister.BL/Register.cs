using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.BL.Objects;
using CashRegister.BL.Services;
namespace CashRegister.BL
{
	public class Register 
	{
        private IInputSource _input;
        private IOutputSource _output;

        public Register(IInputSource inputSource, IOutputSource outputSource) {
            if(inputSource == null)
                throw new ArgumentNullException("inputSource");
            if(outputSource == null)
                throw new ArgumentNullException("outputSource");
            _input = inputSource;
            _output = outputSource;
        }

        private bool IsDivisbleByThree(int count) {
            return count > 0 && count % 3 == 0;
        }

        public void Process() 
        {
            var denList = new List<Denomination>();
            var inputData = _input.LoadData();
            foreach(var transaction in inputData) 
            {
                IChangeGenerator generator = null;
                if(IsDivisbleByThree((int)transaction.AmountOwed)) {
                    generator = new RandomChangeGenerator();    
                } else {
                    generator = new MinChangeGenerator();
                }
                var result = generator.ComputeChange(transaction.AmountChangeCents);
                denList.Add(result);
            }
            if(denList.Any())
                _output.SaveData(denList);
        }
	}
}
