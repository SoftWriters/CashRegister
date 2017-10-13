using System;
using Xunit;
using CashRegister.BL.Services;
using CashRegister.BL.Objects;
using CashRegister.BL;

namespace CashRegister.Tests
{
	public class ComputeTest
	{
		[Fact]
		public void TestMinComputeLessThanZero()
		{
			var service = new MinChangeGenerator();
			Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => service.ComputeChange(-1));
		}

		[Fact]
		public void TestMinComputePassOne()
		{
			var service = new MinChangeGenerator();
			var result = service.ComputeChange(103);
			Assert.Equal(result.TotalCoins, 4);
		}

		[Fact]
		public void TestGetGeneratorRandom() 
		{
			var mock = new MockFile();
			var register = new Register(mock, mock);
			var generator = register.GetGenerator(3);
			Assert.IsType<RandomChangeGenerator>(generator);
		}
		[Fact]
		public void TestGetGeneratorMin() 
		{
			var mock = new MockFile();
			var register = new Register(mock, mock);
			var generator = register.GetGenerator(1);
			Assert.IsType<MinChangeGenerator>(generator);
			
		}

	}
}
