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

        public Register() {
            
        }
        public Register(IInputSource inputSource, IOutputSource outputSource) {
            if(inputSource == null)
                throw new ArgumentNullException("inputSource");
            if(outputSource == null)
                throw new ArgumentNullException("outputSource");
            _input = inputSource;
            _output = outputSource;
        }

        public bool IsDivisbleByThree(int count) {
            return count > 0 && count % 3 == 0;
        }

        public IChangeGenerator GetGenerator(int count) 
        {
            if(IsDivisbleByThree(count)) {
                return new RandomChangeGenerator();    
            }
            return new MinChangeGenerator();
        }

        public int Process() 
        {
            var denList = new List<Denomination>();
            var inputData = _input.LoadData();
            foreach(var transaction in inputData) 
            {
                IChangeGenerator generator = GetGenerator((int)transaction.AmountOwed);
                var result = generator.ComputeChange(transaction.AmountChangeCents);
                denList.Add(result);
            }
            if(denList.Any())
                _output.SaveData(denList);

            return denList.Count;    
        }
	}
}
